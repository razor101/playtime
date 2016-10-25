namespace PlayTime.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BaseDataModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public bool IsDeactivated { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public BaseDataModel()
        {
            this.Id = Guid.NewGuid();
            this.CreatedDate = DateTime.UtcNow;
        }
    }
}