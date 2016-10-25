namespace PlayTime.Infrastructure.Interfaces.DomainServices
{
    using System;
    using System.Collections.Generic;

    public interface ICustomerDomainService
    {
        Models.Customer Get(Guid id);

        IEnumerable<Models.Customer> All();

        Models.Customer Create(string name);

        void Update(Guid id, string name);
    }
}