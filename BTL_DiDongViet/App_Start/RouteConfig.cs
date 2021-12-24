﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BTL_DiDongViet
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Information", action = "Contact", id = UrlParameter.Optional }
            );
            // dang nhap
            routes.MapRoute(
                name: "DangNhap",
                url: "Users/Login",
                defaults: new { controller = "Users", action = "Login", id = UrlParameter.Optional },
                namespaces: new[] { "BTL_DiDongViet.Controllers" }
            );
            // dang ky
            routes.MapRoute(
               name: "DangKy",
               url: "Users/Register",
               defaults: new { controller = "Users", action = "Register", id = UrlParameter.Optional },
               namespaces: new[] { "FoodShopOnline.Controllers" }
           );

            routes.MapRoute(
                name: "Home",
                url: "Users/Create",
                defaults: new { controller = "Users", action = "Create", id = UrlParameter.Optional },
                namespaces: new[] { "BTL_DiDongViet.Controllers" }
            );

            routes.MapRoute(
                name: "Search",
                url: "Users/Search",
                defaults: new { controller = "Users", action = "Search", id = UrlParameter.Optional },
                namespaces: new[] { "BTL_DiDongViet.Controllers" }
            );
        }
    }
}
