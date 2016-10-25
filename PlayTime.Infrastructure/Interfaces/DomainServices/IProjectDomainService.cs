namespace PlayTime.Infrastructure.Interfaces.DomainServices
{
    using System;
    using System.Collections.Generic;

    using PlayTime.Infrastructure.Models;

    public interface IProjectDomainService
    {
        Project Get(Guid id);

        IEnumerable<Project> All();

        IEnumerable<Project> All(Guid id);

        Project Create(string name, bool isFixed, double price, DateTime? startDate, DateTime? endDate, Guid customerId);

        void Update(Guid id, string name, bool isFixed, bool isDeactivated, double price, DateTime? startDate, DateTime? endDate);

        void AssignUser(Guid projectId, string userId);

        void RemoveUser(Guid projectId, string userId);
    }
}