using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayTime.Web.Controllers
{
    using PlayTime.Infrastructure.Interfaces.ApplicationServices;
    using PlayTime.Infrastructure.Models;
    using PlayTime.Web.Models.Registration;
    
    public class RegistrationController : Controller
    {
        private IUserApplicationService UserService { get; set; }
        private IRegistrationApplicationService RegistrationService { get; set; }
        private ICustomerApplicationService CustomerService { get; set; }
        private IProjectApplicationService ProjectService { get; set; }
        private ITaskApplicationService TaskService { get; set; }

        private string CurrentUserId { get; set; }

        public RegistrationController(IUserApplicationService userService,
            IRegistrationApplicationService registrationService,
            ICustomerApplicationService customerService,
            IProjectApplicationService projectService,
            ITaskApplicationService taskService)
        {
            UserService = userService;
            RegistrationService = registrationService;
            CustomerService = customerService;
            ProjectService = projectService;
            TaskService = taskService;
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            CurrentUserId = UserService.GetByName(User.Identity.Name).SID;

            RegistrationIndexModel viewModel = new RegistrationIndexModel();
            viewModel.Registrations = RegistrationService
                .All(CurrentUserId)
                .Where(x => false == x.IsDeactivated)
                .OrderByDescending(x => x.StartTime)
                .ThenByDescending(x => x.EndTime);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            RegistrationCreateModel viewModel = new RegistrationCreateModel();
            
            ReBindCreateModel(viewModel);
            
            return View(viewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(RegistrationCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                ReBindCreateModel(model);

                return View(model);
            }
            
            try
            {
                CurrentUserId = UserService.GetByName(User.Identity.Name).SID;

                RegistrationService.Create(model.Note, CurrentUserId, model.TaskId, model.StartTime, model.EndTime, false);
                
                return RedirectToAction("Index", "Registration");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                ModelState.AddModelError("", ex.StackTrace);
            }

            ReBindCreateModel(model);

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(RegistrationEditModel model)
        {
            ReBindCreateModel(model);

            return PartialView("_Edit", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SaveChanges(Registration model)
        {
            return View(model);
        }

        private void ReBindCreateModel(RegistrationCreateModel viewModel)
        {
            List<Customer> allCustomers = CustomerService.All().ToList();
            List<Project> projectsOfFirstCustomer = new List<Project>();
            if (allCustomers.Any())
            {
                if (viewModel.CustomerId != Guid.Empty)
                {
                    projectsOfFirstCustomer = ProjectService.All(viewModel.CustomerId).ToList();
                }
                else
                {
                    projectsOfFirstCustomer = ProjectService.All(allCustomers.First().Id).ToList();
                }
            }
            List<Task> tasksOfFirstProject = new List<Task>();
            if (projectsOfFirstCustomer.Any())
            {
                if (viewModel.ProjectId != Guid.Empty)
                {
                    tasksOfFirstProject = TaskService.All(viewModel.ProjectId).ToList();
                }
                else
                {
                    tasksOfFirstProject = TaskService.All(projectsOfFirstCustomer.First().Id).ToList();
                }
            }

            viewModel.Customers = new SelectList(allCustomers, "Id", "Name", viewModel.CustomerId);
            viewModel.Projects = new SelectList(projectsOfFirstCustomer, "Id", "Name", viewModel.ProjectId);
            viewModel.Tasks = new SelectList(tasksOfFirstProject, "Id", "Name", viewModel.TaskId);
        }
    }
}