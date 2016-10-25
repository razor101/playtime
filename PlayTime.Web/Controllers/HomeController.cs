namespace PlayTime.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using PlayTime.Infrastructure.Interfaces.ApplicationServices;
    using PlayTime.Security;
    using PlayTime.Web.Models.Home;

    [Authorize]
    public class HomeController : Controller
    {
        public ActiveDirectory ActiveDirectory { get; set; }
        public ICustomerApplicationService CustomerService { get; set; }
        public ITaskApplicationService TaskService { get; set; }
        public IUserApplicationService UserService { get; set; }
        public IProjectApplicationService ProjectService { get; set; }

        public HomeController(ActiveDirectory activeDirectory,
            ICustomerApplicationService customerService,
            ITaskApplicationService taskService,
            IUserApplicationService userService,
            IProjectApplicationService projectService)
        {
            ActiveDirectory = activeDirectory;
            CustomerService = customerService;
            TaskService = taskService;
            UserService = userService;
            ProjectService = projectService;
        }

        public ActionResult Index()
        {
            string userId = UserService.GetByName(User.Identity.Name).SID;
            
            HomeIndexModel viewModel = new HomeIndexModel();
            var data = TaskService.AllByUserId(userId).ToList();

            viewModel.Projects = ProjectService.All()
                                               .Where(project => project.AssignedUsers.All(user => user.SID == userId))
                                               .OrderBy(p => p.StartDate)
                                               .ThenBy(p => p.EndDate);

            viewModel.Tasks = data;

            return View(viewModel);
        }
    }
}