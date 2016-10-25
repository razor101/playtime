namespace PlayTime.Web.Models.Customer
{
    using System.Collections.Generic;

    public class CustomerIndexModel
    {
        public IEnumerable<Infrastructure.Models.Customer> Customers { get; set; }
    }
}