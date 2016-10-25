namespace PlayTime.Web.Controllers
{
    using System.Web.Mvc;

    using PlayTime.Infrastructure.Interfaces.ApplicationServices;
    using PlayTime.Web.Models.Invoice;

    public class InvoicingController : Controller
    {
        private IInvoiceApplicationService InvoiceService { get; set; }
        private ICustomerApplicationService CustomerService { get; set; }
        private IProjectApplicationService ProjectService { get; set; }

        public InvoicingController(IInvoiceApplicationService invoiceService,
            ICustomerApplicationService customerService,
            IProjectApplicationService projectService)
        {
            InvoiceService = invoiceService;
            CustomerService = customerService;
            ProjectService = projectService;
        }

        public ActionResult Index()
        {
            InvoiceIndexModel viewModel = new InvoiceIndexModel();

            //IEnumerable<Customer> activeCustomers = CustomerService.All().Where(x => !x.IsDeactivated);

            //viewModel.InvoiceGroups = activeCustomers.Select(x => new InvoiceIndexGroupModel
            //{
            //    Customer = x,
            //    Projects = x.Projects.Select(x => new InvoiceIndexProjectGroupModel
            //    {
            //        Project = x,
            //        InvoicableHours = x.Tasks.SelectMany(t => t.Registrations).SelectMany(r => r.StartTime - r.EndTime).Select(x => x.)
            //    })
            //});

            return View(viewModel);
        }
    }
}