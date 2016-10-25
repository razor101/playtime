using System.Web.Mvc;

namespace PlayTime.Web.Controllers
{
    using System;
    using System.Linq;

    using PlayTime.Infrastructure.Interfaces.ApplicationServices;
    using PlayTime.Infrastructure.Models;
    using PlayTime.Web.Models.Customer;

    [Authorize]
    public class CustomerController : Controller
    {
        private ICustomerApplicationService CustomerService { get; set; }

        public IProjectApplicationService ProjectService { get; set; }

        public CustomerController(ICustomerApplicationService customerService, IProjectApplicationService projectService)
        {
            CustomerService = customerService;
            ProjectService = projectService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            CustomerIndexModel model = new CustomerIndexModel();

            model.Customers = CustomerService.All().OrderBy(x => x.Name);

            return View(model);
        }

        [HttpGet]
        public ActionResult View(Guid id)
        {
            try
            {
                Customer customer = CustomerService.Get(id);

                CustomerCRUDModel model = new CustomerCRUDModel();
                model.Id = customer.Id;
                model.Name = customer.Name;
                model.CreatedDate = customer.CreatedDate;
                model.LastModifiedDate = customer.LastModifiedDate;
                model.Projects = ProjectService.All(model.Id);

                return View(model);
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            CustomerCRUDModel model = new CustomerCRUDModel();
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CustomerCRUDModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                CustomerService.Create(model.Name);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(model);
            }

            return RedirectToAction("Index", "Customer");
        }
        
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            try
            {
                Customer customer = CustomerService.Get(id);

                CustomerCRUDModel model = new CustomerCRUDModel();
                model.Id = customer.Id;
                model.Name = customer.Name;
                model.CreatedDate = customer.CreatedDate;
                model.LastModifiedDate = customer.LastModifiedDate;

                return View(model);
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(CustomerCRUDModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                CustomerService.Update(model.Id, model.Name);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(model);
            }
            
            return RedirectToAction("Index", "Customer");
        }
    }
}