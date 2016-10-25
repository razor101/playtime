namespace PlayTime.Infrastructure.DomainServices
{
    using PlayTime.Infrastructure.Interfaces.DomainServices;
    using PlayTime.Infrastructure.Interfaces.Repository;

    public class InvoiceDomainService : IInvoiceDomainService
    {
        private IInvoiceRepository InvoiceRepository { get; set; }

        public InvoiceDomainService(IInvoiceRepository invoiceRepository)
        {
            InvoiceRepository = invoiceRepository;
        }
    }
}