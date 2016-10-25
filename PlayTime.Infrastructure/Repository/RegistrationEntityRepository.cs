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

    public class RegistrationEntityRepository : IBaseRepository<Registration>, IRegistrationRepository
    {
        private PlayTimeContext Context { get; set; }

        public RegistrationEntityRepository(PlayTimeContext context)
        {
            Context = context;
        }

        public DbSet<Registration> Table
        {
            get { return Context.RegistrationSet; }
        }

        public DbQuery<Registration> JoinedTable
        {
            get { return Context.RegistrationSet.Include("User").Include("Task"); }
        }

        public Registration Get(Guid id)
        {
            return JoinedTable.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Registration> All()
        {
            return JoinedTable.AsEnumerable();
        }

        public IEnumerable<Registration> All(string userId)
        {
            return JoinedTable.Where(x => x.UserId == userId);
        }

        public Registration Create(string note, string userId, Guid taskId, DateTime? startTime, DateTime? endTime, bool isInvoiced)
        {
            Registration newRegistration = new Registration();
            newRegistration.Note = note;
            newRegistration.UserId = userId;
            newRegistration.TaskId = taskId;
            newRegistration.StartTime = startTime;
            newRegistration.EndTime = endTime;
            newRegistration.IsDeactivated = false;
            newRegistration.IsInvoiced = false;
            newRegistration.CreatedDate = DateTime.UtcNow;

            Table.Add(newRegistration);
            Context.SaveChanges();

            return newRegistration;
        }

        public void Update(Guid id, string name, bool isDeactivated, string userId, Guid taskId, DateTime? startTime, DateTime? endTime, bool isInvoiced)
        {
            Registration foundRegistration = Get(id);
            foundRegistration.Note = name;
            foundRegistration.UserId = userId;
            foundRegistration.TaskId = taskId;
            foundRegistration.StartTime = startTime;
            foundRegistration.EndTime = endTime;
            foundRegistration.IsDeactivated = isDeactivated;
            foundRegistration.IsInvoiced = isInvoiced;
            foundRegistration.LastModifiedDate = DateTime.UtcNow;

            Table.Add(foundRegistration);
            Context.SaveChanges();
        }
    }
}