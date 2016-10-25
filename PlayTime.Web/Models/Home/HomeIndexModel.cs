using System.Collections.Generic;
using PlayTime.Infrastructure.Models;

namespace PlayTime.Web.Models.Home
{
    public class HomeIndexModel
    {
        public IEnumerable<Infrastructure.Models.Project> Projects { get; set; } 

        public IEnumerable<Task> Tasks { get; set; } 
    }
}