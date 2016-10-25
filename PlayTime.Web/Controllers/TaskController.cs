using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayTime.Web.Controllers
{
    using Newtonsoft.Json;

    using PlayTime.Infrastructure.Interfaces.ApplicationServices;
    using PlayTime.Infrastructure.Models;
    using PlayTime.Web.Models.Tasks;

    public class TaskController : Controller
    {
        private ITaskApplicationService TaskService { get; set; }
        private IProjectApplicationService ProjectService { get; set; }

        public TaskController(ITaskApplicationService taskService, IProjectApplicationService projectService)
        {
            TaskService = taskService;
            this.ProjectService = projectService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View(Guid id)
        {
            Task task = TaskService.Get(id);
            if (task == null)
            {
                return RedirectToAction("Index", "Task");
            }

            TaskViewModel viewModel = new TaskViewModel();
            viewModel.Id = task.Id;
            viewModel.Name = task.Name;
            viewModel.ProjectId = task.ProjectId;
            viewModel.Project = task.Project;
            viewModel.UserId = task.UserId;
            viewModel.User = task.User;

            return View(viewModel);
        }

        public ActionResult ViewProjectTasks(Guid projectId)
        {
            IEnumerable<Task> tasks = TaskService.All(projectId);
            Project project = ProjectService.Get(projectId);

            TaskViewManyModel viewModel = new TaskViewManyModel();
            viewModel.Tasks = tasks;
            viewModel.ProjectId = project.Id;
            viewModel.Project = project;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(TaskCreateModel model)
        {
            TaskService.Create(model.Name, model.ProjectId, model.UserId);

            return RedirectToAction("View", "Project", new { @id = model.ProjectId });
        }

        [HttpGet]
        public JsonResult GetProjectTasks(Guid id)
        {
            var data = TaskService.All(id).ToList().Select(x => new { x.Id, x.Name });

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetTaskModal(Guid id)
        {
            Task task = TaskService.Get(id);

            TaskViewModel viewModel = new TaskViewModel
            {
                Id = task.Id,
                Name = task.Name,
                ProjectId = task.ProjectId,
                Project = task.Project,
                UserId = task.UserId,
                User = task.User
            };
            
            return PartialView("../Shared/Task/_TaskModal", task);
        }

        public ActionResult SaveTaskChanges()
        {
            return null;
        }
    }
}