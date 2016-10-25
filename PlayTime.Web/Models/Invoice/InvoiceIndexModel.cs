namespace PlayTime.Web.Models.Invoice
{
    using System.Collections.Generic;

    public class InvoiceIndexModel
    {
        public IEnumerable<InvoiceIndexGroupModel> InvoiceGroups { get; set; }
    }

    public class InvoiceIndexGroupModel
    {
        public Infrastructure.Models.Customer Customer { get; set; }

        public IEnumerable<InvoiceIndexProjectGroupModel> Projects { get; set; }
    }

    public class InvoiceIndexProjectGroupModel
    {
        public Infrastructure.Models.Project Project { get; set; }

        public decimal InvoicableHours { get; set; }
    }
}