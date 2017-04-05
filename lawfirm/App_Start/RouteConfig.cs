using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace lawfirm
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //name: "Root",
            //url: "",
            //defaults: new { controller = "Home", action = "Index" }
            //);


                routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "lawfirm.Controllers" }
                );

                //routes.MapRoute(
                //name: "Default_Admin",
                //url: "Admin/{controller}/{action}/{id}",
                //defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional },
                //namespaces: new[] { "lawfirm.Areas.Admin.Controllers" }

                //);
                //routes.MapRoute(
                //name: "Admin",
                //url: "{Admin/controller}/{action}/{id}",
                //defaults: new { controller = "Login", action = "Index", area = "Admin", id = UrlParameter.Optional },
                //namespaces: new[] { "lawfirm.Areas.Admin.Controllers" }
                //);
        }
    }
}
