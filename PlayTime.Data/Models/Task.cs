namespace PlayTime.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Task : BaseDataModel
    {
        public string Name { get; set; }

        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public Guid TaskStatusId { get; set; }
        public virtual TaskStatus TaskStatus { get; set; }

        public string StatusText { get; set; }
        
        public virtual ICollection<Registration> Registrations { get; set; }

        public bool HasFlatEstimate { get; set; }

        public decimal EstimateFlat { get; set; }

        public decimal EstimateOptimistic { get; set; }
        
        public decimal EstimateRealistic { get; set; }

        public decimal EstimatePessimistic { get; set; }
    }
}