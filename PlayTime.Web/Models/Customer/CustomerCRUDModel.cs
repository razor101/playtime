namespace PlayTime.Web.Models.Customer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PlayTime.Infrastructure.Models;

    public class CustomerCRUDModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public IEnumerable<Project> Projects { get; set; }
    }
}