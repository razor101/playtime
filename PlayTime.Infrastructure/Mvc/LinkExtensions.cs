namespace PlayTime.Infrastructure.Mvc
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using PlayTime.Infrastructure.Models;

    public static class LinkExtensions
    {
        public static string CustomerView(this UrlHelper urlHelper, Guid customerId)
        {
            return urlHelper.Action("View", "Customer", new { @id = customerId });
        }

        public static string ProjectView(this UrlHelper urlHelper, Guid projectId)
        {
            return urlHelper.Action("View", "Project", new { @id = projectId });
        }

        public static IHtmlString ProjectTasks(this HtmlHelper htmlHelper, Guid projectId)
        {
            return htmlHelper.ActionLink("Tasks", "ViewProjectTasks", "Task", new { @projectId = projectId }, null);
        }

        public static IHtmlString TaskView(this HtmlHelper htmlHelper, Guid projectId, Task task)
        {
            return htmlHelper.ActionLink(task.Name ?? "(empty)", "View", "Task", new { @projectId = projectId, @id = task.Id }, null);
        }
    }
}