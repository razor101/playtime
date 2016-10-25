namespace PlayTime.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public bool IsDeactivated { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }
        
        public virtual ICollection<Registration> Registrations { get; set; }
        
        public virtual ICollection<Preset> Presets { get; set; }

        public virtual ICollection<Project> AssignedProjects { get; set; }
    }
}