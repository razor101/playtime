namespace PlayTime.Infrastructure.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Task
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsDeactivated { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public Guid ProjectId { get; set; }

        public Project Project { get; set; }

        public IEnumerable<Registration> Registrations { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public Task(Data.Models.Task task)
        {
            Id = task.Id;
            Name = task.Name;
            IsDeactivated = task.IsDeactivated;
            CreatedDate = task.CreatedDate;
            LastModifiedDate = task.LastModifiedDate;

            ProjectId = task.ProjectId;
            if (task.Project != null)
            {
                Project = new Project(task.Project);
            }

            Registrations = task.Registrations != null ? task.Registrations.Select(x => new Registration(x)) : null;

            UserId = task.UserId;
            if (task.User != null)
            {
                User = new User(task.User);
            }
        }
    }
}