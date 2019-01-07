using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebBanHang
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new {area="Admin" , controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    null,
            //    new {"WebBanHang.Areas.Admin.Controllers"}
            //).DataTokens.Add("area","Admin");
            routes.MapRoute(
                "Default1", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { area = "Store", controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                null,
                new[] { "WebBanHang.Areas.Admin.Controllers" }
            ).DataTokens.Add("area", "Admin");
        }
    }
}
