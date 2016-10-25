namespace PlayTime.Infrastructure.DomainServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using PlayTime.Infrastructure.Interfaces.DomainServices;
    using PlayTime.Infrastructure.Interfaces.Repository;
    using PlayTime.Infrastructure.Models;

    public class CustomerDomainService : ICustomerDomainService
    {
        private ICustomerRepository CustomerRepository { get; set; }

        public CustomerDomainService(ICustomerRepository customerRepository)
        {
            CustomerRepository = customerRepository;
        }

        public Customer Get(Guid id)
        {
            Data.Models.Customer foundCustomer = CustomerRepository.Get(id);

            return new Customer(foundCustomer);
        }

        public IEnumerable<Customer> All()
        {
            IEnumerable<Data.Models.Customer> all = CustomerRepository.All().ToList();

            return all.Select(x => new Customer(x));
        }

        public Customer Create(string name)
        {
            return new Customer(CustomerRepository.Create(name));
        }

        public void Update(Guid id, string name)
        {
            CustomerRepository.Update(id, name);
        }
    }
}