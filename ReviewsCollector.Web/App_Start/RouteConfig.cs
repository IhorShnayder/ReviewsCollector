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
                url: "",
                defaults: new { controller = "Home", action = "Index"}
            );

            routes.MapRoute(
                name: "",
                url: "reviews",
                defaults: new { controller = "Home", action = "Reviews" });
        }
    }
}