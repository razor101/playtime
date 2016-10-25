namespace PlayTime.Web.Models.Registration
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class RegistrationCreateModel
    {
        [Display(ResourceType = typeof(Resources_Registration), Name = "FieldLabel_Note")]
        [Required(ErrorMessageResourceType = typeof(Resources_Registration), ErrorMessageResourceName = "FieldRequired_Note")]
        public string Note { get; set; }

        [Display(ResourceType = typeof(Resources_Registration), Name = "FieldLabel_StartTime")]
        [Required(ErrorMessageResourceType = typeof(Resources_Registration), ErrorMessageResourceName = "FieldRequired_StartTime")]
        public DateTime? StartTime { get; set; }
        
        [Display(ResourceType = typeof(Resources_Registration), Name = "FieldLabel_EndTime")]
        [Required(ErrorMessageResourceType = typeof(Resources_Registration), ErrorMessageResourceName = "FieldRequired_EndTime")]
        public DateTime? EndTime { get; set; }
        
        [Display(ResourceType = typeof(Resources_Registration), Name = "FieldLabel_CustomerId")]
        [Required(ErrorMessageResourceType = typeof(Resources_Registration), ErrorMessageResourceName = "FieldRequired_CustomerId")]
        public Guid CustomerId { get; set; }
        public SelectList Customers { get; set; }

        [Display(ResourceType = typeof(Resources_Registration), Name = "FieldLabel_ProjectId")]
        [Required(ErrorMessageResourceType = typeof(Resources_Registration), ErrorMessageResourceName = "FieldRequired_ProjectId")]
        public Guid ProjectId { get; set; }
        public SelectList Projects { get; set; }
        
        [Display(ResourceType = typeof(Resources_Registration), Name = "FieldLabel_TaskId")]
        [Required(ErrorMessageResourceType = typeof(Resources_Registration), ErrorMessageResourceName = "FieldRequired_TaskId")]
        public Guid TaskId { get; set; }
        public SelectList Tasks { get; set; }
    }
}