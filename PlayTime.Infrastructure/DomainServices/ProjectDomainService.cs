namespace PlayTime.Infrastructure.DomainServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using PlayTime.Infrastructure.Interfaces.DomainServices;
    using PlayTime.Infrastructure.Interfaces.Repository;
    using PlayTime.Infrastructure.Models;

    public class ProjectDomainService : IProjectDomainService
    {
        private IProjectRepository ProjectRepository { get; set; }

        public ProjectDomainService(IProjectRepository projectRepository)
        {
            ProjectRepository = projectRepository;
        }

        public Project Get(Guid id)
        {
            return new Project(ProjectRepository.Get(id));
        }

        public IEnumerable<Project> All()
        {
            return ProjectRepository.All().ToList().Select(x => new Project(x));
        }

        public IEnumerable<Project> All(Guid id)
        {
            return ProjectRepository.All(id).ToList().Select(x => new Project(x));
        }

        public Project Create(string name, bool isFixed, double price, DateTime? startDate, DateTime? endDate, Guid customerId)
        {
            return new Project(ProjectRepository.Create(name, isFixed, price, startDate, endDate, customerId));
        }

        public void Update(Guid id, string name, bool isFixed, bool isDeactivated, double price, DateTime? startDate, DateTime? endDate)
        {
            ProjectRepository.Update(id, name, isFixed, isDeactivated, price, startDate, endDate);
        }

        public void AssignUser(Guid projectId, string userId)
        {
            ProjectRepository.AssignUser(projectId, userId);
        }

        public void RemoveUser(Guid projectId, string userId)
        {
            ProjectRepository.RemoveUser(projectId, userId);
        }
    }
}