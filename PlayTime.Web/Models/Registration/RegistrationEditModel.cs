namespace PlayTime.Web.Models.Registration
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RegistrationEditModel : RegistrationCreateModel
    {
        [Display(Name = "Id")]
        [Required]
        public Guid Id { get; set; }
    }
}