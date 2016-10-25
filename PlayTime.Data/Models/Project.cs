namespace PlayTime.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Project : BaseDataModel
    {
        public string Name { get; set; }
        
        public bool IsFixed { get; set; }

        public double Price { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public virtual ICollection<User> AssignedUsers { get; set; }
    }
}