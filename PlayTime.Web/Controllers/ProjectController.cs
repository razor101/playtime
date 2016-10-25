using System;
using System.Linq;
using System.Web.Mvc;

namespace PlayTime.Web.Controllers
{
    using System.Collections.Generic;

    using PlayTime.Infrastructure.Interfaces.ApplicationServices;
    using PlayTime.Infrastructure.Models;
    using PlayTime.Web.Models.Project;

    public class ProjectController : Controller
    {
        private IProjectApplicationService ProjectService { get; set; }

        private ICustomerApplicationService CustomerService { get; set; }

        private IUserApplicationService UserService { get; set; }
        public ITaskApplicationService TaskService { get; set; }

        public ProjectController(IProjectApplicationService projectService,
                                ICustomerApplicationService customerService,
                                IUserApplicationService userService,
                                ITaskApplicationService taskService)
        {
            ProjectService = projectService;
            CustomerService = customerService;
            UserService = userService;
            TaskService = taskService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ProjectIndexModel viewModel = new ProjectIndexModel();
            viewModel.Projects = ProjectService.All().OrderBy(x => x.Name);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult View(Guid id)
        {
            try
            {
                var dbProject = ProjectService.Get(id);
                if (dbProject == null)
                {
                    return RedirectToAction("Index");
                }

                ProjectViewModel project = new ProjectViewModel();
                project.Data = dbProject;
                project.Users = new SelectList(UserService.All(), "SID", "DisplayName", null);

                return View(project);
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create(Guid? id)
        {
            List<Customer> allCustomers = CustomerService.All().ToList();

            ProjectCreateOrUpdateModel model = new ProjectCreateOrUpdateModel();
            model.Customers = new SelectList(allCustomers, "Id", "Name");

            if (id.HasValue)
            {
                Customer matchingCustomer = allCustomers.FirstOrDefault(x => x.Id.Equals(id.Value));
                if (id.Value == Guid.Empty || matchingCustomer == null)
                {
                    return RedirectToAction("Create", "Project", new { @id = (Guid?) null });
                }

                model.CustomerId = matchingCustomer.Id;
                model.MatchingCustomer = matchingCustomer;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ProjectCreateOrUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                //model.Customers = new SelectList(CustomerService.All(), "Id", "Name");
                return View(model);
            }

            try
            {
                ProjectService.Create(model.Name, model.IsFixed, model.Price, model.StartDate, model.EndDate, model.CustomerId);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(model);
            }

            return RedirectToAction("Index", "Project");
        }

        

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            try
            {
                Project data = ProjectService.Get(id);

                ProjectCreateOrUpdateModel viewModel = new ProjectCreateOrUpdateModel();
                viewModel.Id = data.Id;
                viewModel.Name = data.Name;
                viewModel.Price = data.Price;
                viewModel.IsFixed = data.IsFixed;
                viewModel.IsDeactivated = data.IsDeactivated;
                viewModel.StartDate = data.StartDate;
                viewModel.EndDate = data.EndDate;

                return View(viewModel);
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(ProjectCreateOrUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                ProjectService.Update(model.Id, model.Name, model.IsFixed, model.IsDeactivated, model.Price, model.StartDate, model.EndDate);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(model);
            }
            
            return RedirectToAction("Index", "Project");
        }

        [HttpGet]
        public JsonResult GetCustomerProjects(Guid id)
        {
            var data = ProjectService.All(id).ToList().Select(x => new
            {
                x.Id,
                x.Name
            });

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AssignUsers(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index", "Project");
            }

            Project foundProject = ProjectService.Get(id);
            if (foundProject == null)
            {
                return RedirectToAction("Index", "Project");
            }

            AssignUsersModel viewModel = new AssignUsersModel();
            viewModel.ProjectId = foundProject.Id;
            viewModel.AllUsers = new MultiSelectList(UserService.All(), "SID", "DisplayName");
            viewModel.AssignedUsers = foundProject.AssignedUsers.Select(x => x.SID).ToArray();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AssignUsers(AssignUsersModel model)
        {
            model.AllUsers = new MultiSelectList(UserService.All(), "SID", "DisplayName");

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.AssignedUsers == null)
            {
                model.AssignedUsers = new string[0];

                Project foundProject = ProjectService.Get(model.ProjectId);
                foreach (User user in foundProject.AssignedUsers.ToList())
                {
                    ProjectService.RemoveUser(foundProject.Id, user.SID);
                }

                return RedirectToAction("View", "Project", new { @id = model.ProjectId });
            }

            var usersToRemove = model.AllUsers.Select(x => x.Value).Intersect(model.AssignedUsers);

            foreach (string userId in model.AssignedUsers)
            {
                ProjectService.AssignUser(model.ProjectId, userId);
            }

            return RedirectToAction("View", "Project", new { @id = model.ProjectId });
        }
    }
}