using System.Web.Mvc;
using System.Web.Routing;

namespace ReviewsCollector.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "",
                url: "Reviews",
                defaults: new { controller = "Reviews", action = "ReviewsList" });

            routes.MapRoute(
                name: "",
                url: "Login",
                defaults: new { controller = "Account", action = "Login" });

            routes.MapRoute(
                name: "",
                url: "Users",
                defaults: new { controller = "Account", action = "UsersList" });

            routes.MapRoute(
                name: "",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });


        }
    }
}