using System.Web.Mvc;

namespace PlayTime.Web.Controllers
{
    using System;
    using System.Web;
    using System.Web.Security;

    using PlayTime.Infrastructure.Interfaces.ApplicationServices;
    using PlayTime.Infrastructure.Models;
    using PlayTime.Security;
    using PlayTime.Web.Models.Account;

    [Authorize]
    public class AccountController : Controller
    {
        private ActiveDirectory ActiveDirectory { get; set; }

        private IUserApplicationService UserApplicationService { get; set; }

        public AccountController(ActiveDirectory activeDirectory, IUserApplicationService userApplicationService)
        {
            ActiveDirectory = activeDirectory;
            UserApplicationService = userApplicationService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous, HttpGet]
        public ActionResult Login(string returnUrl)
        {
            return View();
        }

        [AllowAnonymous, HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Attempt to log in via Active Directory.
            ActiveDirectoryUser adUser;
            if (!ActiveDirectory.Authenticate("DIS", model.UserName, model.Password, out adUser))
            {
                ModelState.AddModelError("", Resources_Account.Error_Account_Login_AuthorizationFailed);

                return View(model);
            }

            // Make sure the user is created in the DB.
            User createdOrExistingUser;
            
            try
            {
                createdOrExistingUser = UserApplicationService.Get(adUser.UserSID);

                if (createdOrExistingUser == null)
                {
                    createdOrExistingUser = UserApplicationService.Create(adUser.UserSID,
                                                                          adUser.DisplayName,
                                                                          string.Format("{0}@dis-play.dk", model.UserName.ToLower()),
                                                                          false);
                }

                UserApplicationService.SetLastLoginDate(createdOrExistingUser.SID, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(model);
            }

            // Handling authorization
            HttpCookie authCookie = FormsAuthentication.GetAuthCookie(createdOrExistingUser.DisplayName, true);

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            if (ticket == null)
            {
                return View(model);
            }

            FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version,
                                                                                ticket.Name,
                                                                                ticket.IssueDate,
                                                                                ticket.Expiration,
                                                                                ticket.IsPersistent,
                                                                                string.Empty);

            authCookie.Value = FormsAuthentication.Encrypt(newTicket);
            Response.Cookies.Add(authCookie);

            // Handling ReturnURL
            string decodedUrl = string.Empty;
            if (!string.IsNullOrEmpty(returnUrl))
            {
                decodedUrl = Server.UrlDecode(returnUrl);
            }
            
            if (Url.IsLocalUrl(decodedUrl))
            {
                return Redirect(decodedUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }
    }
}