namespace PlayTime.Infrastructure.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using PlayTime.Data;
    using PlayTime.Data.Models;
    using PlayTime.Infrastructure.Interfaces.Repository;

    public class CustomerEntityRepository : ICustomerRepository
    {
        private PlayTimeContext Context { get; set; }

        public CustomerEntityRepository(PlayTimeContext context)
        {
            Context = context;
        }

        public Customer Get(Guid id)
        {
            return Context.CustomerSet.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Customer> All()
        {
            return Context.CustomerSet.AsEnumerable();
        }

        public Customer Create(string name)
        {
            Customer newCustomer = new Customer();
            newCustomer.Name = name;
            newCustomer.CreatedDate = DateTime.UtcNow;

            Context.CustomerSet.Add(newCustomer);
            Context.SaveChanges();

            return newCustomer;
        }

        public void Update(Guid id, string name)
        {
            Customer foundCustomer = Get(id);
            if (foundCustomer.Name == name)
            {
                return;
            }

            foundCustomer.Name = name;
            foundCustomer.LastModifiedDate = DateTime.UtcNow;

            Context.SaveChanges();
        }
    }
}