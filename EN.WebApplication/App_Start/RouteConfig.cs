﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EN.WebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default1",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional }
            //);

            // routes.MapMvcAttributeRoutes();

            routes.MapRoute(name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "user", action = "sampletest", id = UrlParameter.Optional });

            routes.MapRoute(
             name: "login",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional }
             );
            routes.MapRoute(
                name: "contact",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );



            routes.MapRoute(
               "loginpage",
               "login",
                 defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapMvcAttributeRoutes();
        }
    }
}
