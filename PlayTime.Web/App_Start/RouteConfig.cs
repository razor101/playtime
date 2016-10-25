namespace PlayTime.Web
{
    using System.Security.Policy;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ProjectTaskList",
                url: "Project/View/{projectId}/Tasks",
                defaults: new { controller = "Task", action = "ViewProjectTasks", projectId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ProjectTaskView",
                url: "Project/View/{projectId}/Tasks/{id}",
                defaults: new { controller = "Task", action = "View", projectId = UrlParameter.Optional, id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
