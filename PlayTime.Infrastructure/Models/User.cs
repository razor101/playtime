namespace PlayTime.Infrastructure.Models
{
    using System;

    public class User
    {
        public string SID { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }
        
        public bool IsAdmin { get; set; }

        public bool IsDeactivated { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public User(Data.Models.User user)
        {
            SID = user.Id;

            DisplayName = user.Name;

            Email = user.Email;
            
            IsDeactivated = user.IsDeactivated;

            LastLoginDate = user.LastLoginDate;

            CreatedDate = user.CreatedDate;
        }
    }
}