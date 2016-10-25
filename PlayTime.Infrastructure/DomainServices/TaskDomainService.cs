namespace PlayTime.Infrastructure.DomainServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using PlayTime.Infrastructure.Interfaces.DomainServices;
    using PlayTime.Infrastructure.Interfaces.Repository;
    using PlayTime.Infrastructure.Models;

    public class TaskDomainService : ITaskDomainService
    {
        private ITaskRepository TaskRepository { get; set; }

        public TaskDomainService(ITaskRepository taskRepository)
        {
            TaskRepository = taskRepository;
        }

        public Task Get(Guid id)
        {
            Data.Models.Task foundTask = TaskRepository.Get(id);
            if (foundTask == null)
            {
                return null;
            }

            return new Task(foundTask);
        }
        
        public IEnumerable<Task> All(Guid projectId)
        {
            return TaskRepository.All(projectId).ToList().Select(x => new Task(x));
        }

        public IEnumerable<Task> AllByUserId(string userId)
        {
            return TaskRepository.AllByUserId(userId).ToList().Select(x => new Task(x));
        }

        public Task Create(string name, Guid projectId, string userId)
        {
            return new Task(TaskRepository.Create(name, projectId, userId));
        }

        public void Update(Guid id, string name, bool isDeactivated, Guid projectId, string userId)
        {
            TaskRepository.Update(id, name, isDeactivated, projectId, userId);
        }
    }
}