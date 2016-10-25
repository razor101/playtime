namespace PlayTime.Infrastructure.Interfaces.Repository
{
    using System;
    using System.Collections.Generic;

    using PlayTime.Data.Models;

    public interface ICustomerRepository
    {
        Customer Get(Guid id);

        IEnumerable<Customer> All();

        Customer Create(string name);

        void Update(Guid id, string name);
    }
}