namespace PlayTime.Data.Models
{
    using System;

    public class Preset : BaseDataModel
    {
        public string Name { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}