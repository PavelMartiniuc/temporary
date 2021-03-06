﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Gitarist.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{idc}",
                defaults: new { controller = "Start", action = "Index", id = UrlParameter.Optional, idc = UrlParameter.Optional },
                namespaces: new string[] { "Gitarist.Controllers" }
            );
       }
    }
}