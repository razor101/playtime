namespace PlayTime.Infrastructure.DomainServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using PlayTime.Infrastructure.Interfaces.DomainServices;
    using PlayTime.Infrastructure.Interfaces.Repository;
    using PlayTime.Infrastructure.Models;

    public class UserDomainService : IUserDomainService
    {
        private IUserRepository UserRepository { get; set; }

        public UserDomainService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public IEnumerable<User> All()
        {
            return UserRepository.All().ToList().Select(x => new User(x));
        }

        public User Get(string sId)
        {
            Data.Models.User foundUser = UserRepository.Get(sId);
            if (foundUser == null)
            {
                return null;
            }

            return new User(foundUser);
        }

        public User GetByName(string name)
        {
            Data.Models.User foundUser = UserRepository.GetByName(name);
            if (foundUser == null)
            {
                return null;
            }

            return new User(foundUser);
        }

        public User Create(string sId, string name, string email, bool isDeactivated)
        {
            return new User(UserRepository.Create(sId, name, email, isDeactivated));
        }

        public void SetLastLoginDate(string sId, DateTime date)
        {
            UserRepository.SetLastLoginDate(sId, date);
        }
    }
}