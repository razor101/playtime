namespace PlayTime.Infrastructure.Interfaces.ApplicationServices
{
    using System;
    using System.Collections.Generic;

    public interface ICustomerApplicationService
    {
        Models.Customer Get(Guid id);

        IEnumerable<Models.Customer> All();

        Models.Customer Create(string name);

        void Update(Guid id, string name);
    }
}