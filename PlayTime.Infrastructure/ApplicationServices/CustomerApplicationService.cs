namespace PlayTime.Infrastructure.ApplicationServices
{
    using System;
    using System.Collections.Generic;

    using PlayTime.Infrastructure.Interfaces.ApplicationServices;
    using PlayTime.Infrastructure.Interfaces.DomainServices;
    using PlayTime.Infrastructure.Models;

    public class CustomerApplicationService : ICustomerApplicationService
    {
        private ICustomerDomainService CustomerDomainService { get; set; }

        public CustomerApplicationService(ICustomerDomainService customerDomainService)
        {
            this.CustomerDomainService = customerDomainService;
        }

        public Customer Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("id paramter cannot be empty.");
            }

            return CustomerDomainService.Get(id);
        }

        public IEnumerable<Customer> All()
        {
            return CustomerDomainService.All();
        }

        public Customer Create(string name)
        {
            return CustomerDomainService.Create(name);
        }

        public void Update(Guid id, string name)
        {
            CustomerDomainService.Update(id, name);
        }
    }
}