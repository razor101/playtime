namespace PlayTime.Infrastructure.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Script.Serialization;

    public class Project
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsDeactivated { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public bool IsFixed { get; set; }

        public double Price { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }

        [ScriptIgnore]
        public IEnumerable<Task> Tasks { get; set; }

        [ScriptIgnore]
        public IEnumerable<User> AssignedUsers { get; set; }

        public Project(Data.Models.Project project)
        {
            Id = project.Id;

            Name = project.Name;

            Price = project.Price;

            IsDeactivated = project.IsDeactivated;

            CreatedDate = project.CreatedDate;

            LastModifiedDate = project.LastModifiedDate;

            IsFixed = project.IsFixed;

            StartDate = project.StartDate;

            EndDate = project.EndDate;

            CustomerId = project.CustomerId;

            if (project.Customer != null)
            {
                Customer = new Customer(project.Customer);
            }

            if (project.Tasks != null)
            {
                Tasks = project.Tasks.Select(x => new Task(x));
            }

            if (project.AssignedUsers != null)
            {
                AssignedUsers = project.AssignedUsers.Select(x => new User(x));
            }
        }
    }
}