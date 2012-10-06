using System.Web.Mvc;
using System.Web.Routing;

namespace ICom.Web.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Login", "login", new {controller = "Account", Action = "Login"});
            routes.MapRoute("Logout", "logout", new {controller = "Account", Action = "Logout"});

            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}