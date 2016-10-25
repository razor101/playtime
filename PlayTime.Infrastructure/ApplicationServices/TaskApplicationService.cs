namespace PlayTime.Infrastructure.ApplicationServices
{
    using System;
    using System.Collections.Generic;

    using PlayTime.Infrastructure.Interfaces.ApplicationServices;
    using PlayTime.Infrastructure.Interfaces.DomainServices;
    using PlayTime.Infrastructure.Models;

    public class TaskApplicationService : ITaskApplicationService
    {
        private ITaskDomainService TaskDomainService { get; set; }

        public TaskApplicationService(ITaskDomainService taskDomainService)
        {
            TaskDomainService = taskDomainService;
        }

        public Task Get(Guid id)
        {
            return TaskDomainService.Get(id);
        }
        
        public IEnumerable<Task> All(Guid projectId)
        {
            return TaskDomainService.All(projectId);
        }

        public IEnumerable<Task> AllByUserId(string userId)
        {
            return TaskDomainService.AllByUserId(userId);
        }

        public Task Create(string name, Guid projectId, string userId)
        {
            return TaskDomainService.Create(name, projectId, userId);
        }

        public void Update(Guid id, string name, bool isDeactivated, Guid projectId, string userId)
        {
            TaskDomainService.Update(id, name, isDeactivated, projectId, userId);
        }
    }
}