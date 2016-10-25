namespace PlayTime.Web.Models.Tasks
{
    using System;
    using System.Collections.Generic;

    using PlayTime.Infrastructure.Models;

    public class TaskViewManyModel
    {
        public Guid ProjectId { get; set; }

        public Project Project { get; set; }

        public IEnumerable<Task> Tasks { get; set; }
    }
}