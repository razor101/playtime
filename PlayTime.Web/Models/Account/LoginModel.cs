namespace PlayTime.Web.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    public class LoginModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources_Account), ErrorMessageResourceName = "FieldRequired_UserName")]
        [Display(ResourceType = typeof(Resources_Account), Name = "FieldLabel_UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources_Account), ErrorMessageResourceName = "FieldRequired_Password")]
        [Display(ResourceType = typeof(Resources_Account), Name = "FieldLabel_Password")]
        public string Password { get; set; } 
    }
}