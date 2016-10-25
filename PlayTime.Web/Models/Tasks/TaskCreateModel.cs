using System.Web.Mvc;

namespace PlayTime.Web.Models.Tasks
{
    using System;

    public class TaskCreateModel
    {
        public string Name { get; set; }

        public Guid ProjectId { get; set; }

        public string UserId { get; set; }
    }
}