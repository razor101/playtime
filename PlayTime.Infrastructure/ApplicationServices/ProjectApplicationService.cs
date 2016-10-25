namespace PlayTime.Infrastructure.ApplicationServices
{
    using System;
    using System.Collections.Generic;

    using PlayTime.Infrastructure.Interfaces.ApplicationServices;
    using PlayTime.Infrastructure.Interfaces.DomainServices;
    using PlayTime.Infrastructure.Models;

    public class ProjectApplicationService : IProjectApplicationService
    {
        private IProjectDomainService ProjectDomainService { get; set; }

        public ProjectApplicationService(IProjectDomainService projectDomainService)
        {
            ProjectDomainService = projectDomainService;
        }

        public Project Get(Guid id)
        {
            return ProjectDomainService.Get(id);
        }

        public IEnumerable<Project> All()
        {
            return ProjectDomainService.All();
        }

        public IEnumerable<Project> All(Guid id)
        {
            return ProjectDomainService.All(id);
        }

        public Project Create(string name, bool isFixed, double price, DateTime? startDate, DateTime? endDate, Guid customerId)
        {
            return ProjectDomainService.Create(name, isFixed, price, startDate, endDate, customerId);
        }

        public void Update(Guid id, string name, bool isFixed, bool isDeactivated, double price, DateTime? startDate, DateTime? endDate)
        {
            ProjectDomainService.Update(id, name, isFixed, isDeactivated, price, startDate, endDate);
        }

        public void AssignUser(Guid projectId, string userId)
        {
            ProjectDomainService.AssignUser(projectId, userId);
        }

        public void RemoveUser(Guid projectId, string userId)
        {
            ProjectDomainService.RemoveUser(projectId, userId);
        }
    }
}