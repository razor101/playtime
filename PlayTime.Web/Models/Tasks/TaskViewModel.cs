namespace PlayTime.Web.Models.Tasks
{
    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;

    using PlayTime.Infrastructure.Models;

    public class TaskViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid ProjectId { get; set; }

        [ScriptIgnore]
        public Project Project { get; set; }
        
        public IEnumerable<Registration> Registrations { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}