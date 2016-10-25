namespace PlayTime.Data.Models
{
    using System;

    public class Registration : BaseDataModel
    {
        public string Note { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
        
        public Guid TaskId { get; set; }
        public virtual Task Task { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public bool IsInvoiced { get; set; }
    }
}