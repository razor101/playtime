namespace PlayTime.Infrastructure.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    using PlayTime.Data;
    using PlayTime.Data.Models;
    using PlayTime.Infrastructure.Interfaces;
    using PlayTime.Infrastructure.Interfaces.Repository;

    public class TaskEntityRepository : IBaseRepository<Task>, ITaskRepository
    {
        private PlayTimeContext Context { get; set; }
        private IUserRepository UserRepository { get; set; }
        private IProjectRepository ProjectRepository { get; set; }

        public TaskEntityRepository(PlayTimeContext context, IUserRepository userRepository, IProjectRepository projectRepository)
        {
            Context = context;
            UserRepository = userRepository;
            ProjectRepository = projectRepository;
        }

        public DbSet<Task> Table
        {
            get
            {
                return Context.TaskSet;
            }
        }

        public DbQuery<Task> JoinedTable
        {
            get
            {
                return Context.TaskSet.Include("Project");
            }
        }

        public Task Get(Guid id)
        {
            return JoinedTable.FirstOrDefault(x => x.Id == id);
        }
        
        public IEnumerable<Task> All(Guid projectId)
        {
            return JoinedTable.Where(x => x.ProjectId == projectId);
        }

        public IEnumerable<Task> AllByUserId(string userId)
        {
            return JoinedTable.Where(x => x.UserId == userId);
        }

        public Task Create(string name, Guid projectId, string userId)
        {
            Task newTask = new Task();
            newTask.Name = name;
            newTask.ProjectId = projectId;
            newTask.UserId = userId;
            newTask.CreatedDate = DateTime.UtcNow;

            Table.Add(newTask);
            Context.SaveChanges();

            return newTask;
        }

        public void Update(Guid id, string name, bool isDeactivated, Guid projectId, string userId)
        {
            Task newTask = Get(id);
            newTask.Name = name;
            newTask.ProjectId = projectId;
            newTask.LastModifiedDate = DateTime.UtcNow;
            newTask.IsDeactivated = isDeactivated;
            newTask.UserId = userId;
            
            Context.SaveChanges();
        }
    }
}