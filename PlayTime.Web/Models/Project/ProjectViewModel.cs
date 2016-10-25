using System.Web.Mvc;

namespace PlayTime.Web.Models.Project
{
    using PlayTime.Infrastructure.Models;

    public class ProjectViewModel
    {
        public Project Data { get; set; }

        public string UserId { get; set; }

        public SelectList Users { get; set; }
    }
}