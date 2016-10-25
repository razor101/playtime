namespace PlayTime.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Invoice : BaseDataModel
    {
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}