using System.ComponentModel.DataAnnotations;

namespace PlayTime.Web.Models.Registration
{
    using System.Collections.Generic;

    using PlayTime.Infrastructure.Models;

    public class RegistrationIndexModel
    {
        public IEnumerable<Registration> Registrations { get; set; }
    }
}