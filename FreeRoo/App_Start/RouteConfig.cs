﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FreeRoo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                }
            );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}.do",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                }
            );

            routes.MapRoute(
                name: "Category",
                url: "category-{categoryName}/",
                defaults: new
                {
                    controller = "Home",
                    action = "Category",
                }
            );                      

            routes.MapRoute(
                name: "Article",
                url: "article-{categoryName}/{articleName}.html",
                defaults: new
                {
                    controller = "Home",
                    action = "Article",
                }
            );


        }
    }
}