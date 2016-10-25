namespace PlayTime.Infrastructure.Interfaces.Repository
{
    using System;
    using System.Collections.Generic;

    using PlayTime.Data.Models;

    public interface IUserRepository
    {
        IEnumerable<User> All();

        User Get(string sId);

        User GetByName(string name);

        User Create(string sId, string name, string email, bool isDeactivated);

        void SetLastLoginDate(string sId, DateTime date);
    }
}