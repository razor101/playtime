namespace PlayTime.Web.Models.Project
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using PlayTime.Infrastructure.Models;

    public class AssignUsersModel
    {
        public Guid ProjectId { get; set; }

        public MultiSelectList AllUsers { get; set; }

        public string[] AssignedUsers { get; set; }
    }
}