namespace PlayTime.Web.Models.Project
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;

    using PlayTime.Infrastructure.Models;

    public class ProjectCreateOrUpdateModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsFixed { get; set; }

        [Required]
        public double Price { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsDeactivated { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        public SelectList Customers { get; set; }

        public Customer MatchingCustomer { get; set; }
    }
}