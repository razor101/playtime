namespace PlayTime.Infrastructure.Interfaces.ApplicationServices
{
    using System;
    using System.Collections.Generic;

    public interface IUserApplicationService
    {
        IEnumerable<Models.User> All();

        Models.User Get(string sId);

        Models.User GetByName(string name);

        Models.User Create(string sId, string name, string email, bool isDeactivated);

        void SetLastLoginDate(string sId, DateTime date);
    }
}