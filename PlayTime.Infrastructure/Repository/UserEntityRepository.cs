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

    public class UserEntityRepository : IBaseRepository<User>, IUserRepository
    {
        private PlayTimeContext Context { get; set; }

        public UserEntityRepository(PlayTimeContext context)
        {
            Context = context;
        }

        public DbSet<User> Table
        {
            get
            {
                return Context.UserSet;
            }
        }

        public DbQuery<User> JoinedTable
        {
            get
            {
                return Context.UserSet.Include("Registrations").Include("Presets").Include("AssignedProjects");
            }
        }

        public IEnumerable<User> All()
        {
            return Table.AsEnumerable();
        }

        public User Get(string sId)
        {
            return Context.UserSet.FirstOrDefault(x => x.Id == sId);
        }

        public User GetByName(string name)
        {
            return Context.UserSet.FirstOrDefault(x => x.Name == name);
        }

        public User Create(string sId, string name, string email, bool isDeactivated)
        {
            User newUser = new User
            {
                Id = sId,
                Name = name,
                Email = email,
                IsDeactivated = isDeactivated
            };

            Context.UserSet.Add(newUser);
            Context.SaveChanges();

            return newUser;
        }

        public void SetLastLoginDate(string sId, DateTime date)
        {
            Get(sId).LastLoginDate = date;

            Context.SaveChanges();
        }
    }
}