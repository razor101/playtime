namespace PlayTime.Infrastructure.Interfaces.Repository
{
    using System.Collections.Generic;

    using PlayTime.Data.Models;
    using System;

    public interface IRegistrationRepository
    {
        Registration Get(Guid id);

        IEnumerable<Registration> All();

        IEnumerable<Registration> All(string userId);

        Registration Create(string note, string userId, Guid taskId, DateTime? startTime, DateTime? endTime, bool isInvoiced);

        void Update(Guid id, string name, bool isDeactivated, string userId, Guid taskId, DateTime? startTime, DateTime? endTime, bool isInvoiced);
    }
}