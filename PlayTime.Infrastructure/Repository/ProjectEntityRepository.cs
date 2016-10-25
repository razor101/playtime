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

    public class ProjectEntityRepository : IBaseRepository<Project>, IProjectRepository
    {
        private PlayTimeContext Context { get; set; }

        private IUserRepository UserRepository { get; set; }

        public ProjectEntityRepository(PlayTimeContext context, IUserRepository userRepository)
        {
            Context = context;
            UserRepository = userRepository;
        }

        public DbSet<Project> Table
        {
            get
            {
                return Context.ProjectSet;
            }
        }

        public DbQuery<Project> JoinedTable
        {
            get
            {
                return Context.ProjectSet.Include("Customer").Include("Tasks").Include("AssignedUsers");
            }
        }

        public Project Get(Guid id)
        {
            return Context.ProjectSet.Include("Customer").Include("Tasks").FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Project> All()
        {
            return Context.ProjectSet.Include("Customer").Include("Tasks").AsEnumerable();
        }

        public IEnumerable<Project> All(Guid customerId)
        {
            return Context.ProjectSet.Include("Customer").Include("Tasks").Where(x => x.CustomerId == customerId);
        }

        public Project Create(string name, bool isFixed, double price, DateTime? startDate, DateTime? endDate, Guid customerId)
        {
            Project newProject = new Project
            {
                Name = name,
                IsFixed = isFixed,
                Price = price,
                StartDate = startDate,
                EndDate = endDate,
                CreatedDate = DateTime.UtcNow,
                CustomerId = customerId
            };

            Context.ProjectSet.Add(newProject);
            Context.SaveChanges();

            return newProject;
        }

        public void Update(Guid id, string name, bool isFixed, bool isDeactivated, double price, DateTime? startDate, DateTime? endDate)
        {
            Project exisitingProject = Get(id);
            exisitingProject.Name = name;
            exisitingProject.IsFixed = isFixed;
            exisitingProject.IsDeactivated = isDeactivated;
            exisitingProject.Price = price;
            exisitingProject.StartDate = startDate;
            exisitingProject.EndDate = endDate;
            exisitingProject.LastModifiedDate = DateTime.UtcNow;

            Context.SaveChanges();
        }

        public void AssignUser(Guid projectId, string userId)
        {
            Project foundProject = Get(projectId);

            User foundUser = UserRepository.Get(userId);

            foundProject.AssignedUsers.Add(foundUser); // Add

            Context.ProjectSet.Attach(foundProject);
            Context.SaveChanges();
        }

        public void RemoveUser(Guid projectId, string userId)
        {
            Project foundProject = Get(projectId);

            User foundUser = UserRepository.Get(userId);

            foundProject.AssignedUsers.Remove(foundUser); // Remove

            Context.SaveChanges();
        }
    }
}