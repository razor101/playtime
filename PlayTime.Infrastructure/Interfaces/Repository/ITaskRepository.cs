namespace PlayTime.Infrastructure.Interfaces.Repository
{
    using System;
    using System.Collections.Generic;

    using PlayTime.Data.Models;

    public interface ITaskRepository
    {
        Task Get(Guid id);
        
        IEnumerable<Task> All(Guid projectId);

        IEnumerable<Task> AllByUserId(string userId);

        Task Create(string name, Guid projectId, string userId);

        void Update(Guid id, string name, bool isDeactivated, Guid projectId, string userId);
    }
}