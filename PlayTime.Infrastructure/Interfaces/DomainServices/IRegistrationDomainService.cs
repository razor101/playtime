namespace PlayTime.Infrastructure.Interfaces.DomainServices
{
    using System;
    using System.Collections.Generic;

    using PlayTime.Infrastructure.Models;

    public interface IRegistrationDomainService
    {
        Registration Get(Guid id);

        IEnumerable<Registration> All();

        IEnumerable<Registration> All(string userId);

        Registration Create(string note, string userId, Guid taskId, DateTime? startTime, DateTime? endTime, bool isInvoiced);

        void Update(Guid id, string note, bool isDeactivated, string userId, Guid taskId, DateTime? startTime, DateTime? endTime, bool isInvoiced);
    }
}