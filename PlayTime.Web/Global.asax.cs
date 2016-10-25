namespace PlayTime.Web
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using PlayTime.Data;
    using PlayTime.Data.Models;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            IoC.Container.Build(typeof(MvcApplication));

            // Call DB when application starts to trigger pending DB migrations to be applied.
            using (var db = new PlayTimeContext())
            {
                User first = db.UserSet.First();
            }
        }
    }
}
