using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CateringApplication.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // ----------------------- CUSTOM ROUTES ----------------------------------------
            //routes.MapRoute(
            //    "Restaurant",
            //    "Town/View/{id}",
            //    new { controller = "Restaurant", action = "View", id = UrlParameter.Optional }
            //);

            //routes.MapRoute(
            //    "Food",
            //    "Restaurant/View/{id}",
            //    new { controller = "Food", action = "View", id = UrlParameter.Optional }
            //);
            // -------------------------------------------------------------------------------

            // Default route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}