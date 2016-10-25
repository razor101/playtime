namespace PlayTime.Infrastructure.ApplicationServices
{
    using PlayTime.Infrastructure.Interfaces.ApplicationServices;
    using PlayTime.Infrastructure.Interfaces.DomainServices;

    public class InvoiceApplicationService : IInvoiceApplicationService
    {
        private IInvoiceDomainService InvoiceDomainService { get; set; }

        public InvoiceApplicationService(IInvoiceDomainService invoiceDomainService)
        {
            InvoiceDomainService = invoiceDomainService;
        }
    }
}