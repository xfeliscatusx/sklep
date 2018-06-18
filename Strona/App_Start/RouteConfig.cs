using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Strona
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "SkarpetkiSzczegoly",
               url: "skarpetki-{id}.html",
               defaults: new { controller = "Skarpetki", action = "Szczegoly" });
                        
            routes.MapRoute(
                name: "StronyStatyczne",
                url: "strona/{nazwa}.html",
                defaults: new { controller = "Home", action = "StronyStatyczne" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
