namespace PlayTime.Infrastructure.ApplicationServices
{
    using System;
    using System.Collections.Generic;

    using PlayTime.Infrastructure.Interfaces.ApplicationServices;
    using PlayTime.Infrastructure.Interfaces.DomainServices;
    using PlayTime.Infrastructure.Models;

    public class UserApplicationService : IUserApplicationService
    {
        private IUserDomainService UserDomainService { get; set; }

        public UserApplicationService(IUserDomainService userDomainService)
        {
            UserDomainService = userDomainService;
        }

        public IEnumerable<User> All()
        {
            return UserDomainService.All();
        }

        public User Get(string sId)
        {
            if (string.IsNullOrEmpty(sId))
            {
                throw new ArgumentNullException("sId");
            }

            return UserDomainService.Get(sId);
        }

        public User GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            return UserDomainService.GetByName(name);
        }

        public User Create(string sId, string name, string email, bool isDeactivated)
        {
            if (string.IsNullOrEmpty(sId))
            {
                throw new ArgumentNullException("sId");
            }

            if (Get(sId) != null)
            {
                throw new Exception("User with that SID already exist.");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("email");
            }

            return UserDomainService.Create(sId, name, email, isDeactivated);
        }

        public void SetLastLoginDate(string sId, DateTime date)
        {
            UserDomainService.SetLastLoginDate(sId, date);
        }
    }
}