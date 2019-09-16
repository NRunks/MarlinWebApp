using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MarlinWebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "search",
                url: "{controller}/{action}/{category}/{subcategory}",
                new { controller = "Search", action = "Category", category = "", subcategory = "" }
            );

            routes.MapRoute(
                    name: "login",
                    url: "login",
                    defaults: new { controller = "Login", action = "Index" }
             );
            routes.MapRoute(
                   name: "product",
                   url: "product",
                   defaults: new { controller = "Product", action = "Index" }
            );
            routes.MapRoute(
               name: "ProductPage",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Product", action = "Show", id = UrlParameter.Optional }
           );

        }
    }
}
