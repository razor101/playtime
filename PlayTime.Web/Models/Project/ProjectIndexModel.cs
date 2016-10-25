namespace PlayTime.Web.Models.Project
{
    using System.Collections.Generic;

    using PlayTime.Infrastructure.Models;

    public class ProjectIndexModel
    {
        public IEnumerable<Project> Projects { get; set; } 
    }
}