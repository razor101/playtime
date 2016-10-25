namespace PlayTime.Infrastructure.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Customer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsDeactivated { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public IEnumerable<Project> Projects { get; set; }

        public Customer(Data.Models.Customer customer)
        {
            Id = customer.Id;

            Name = customer.Name;

            IsDeactivated = customer.IsDeactivated;

            CreatedDate = customer.CreatedDate;

            LastModifiedDate = customer.LastModifiedDate;

            if (customer.Projects != null)
            {
                Projects = customer.Projects.Select(x => new Project(x));
            }
        }
    }
}