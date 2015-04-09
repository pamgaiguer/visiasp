using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VisiProj
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "GetSlideShow",
                url: "projetos/GetSlideShow",
                defaults: new { controller = "Projetos", action = "GetSlideShow" }
            );

            routes.MapRoute(
                name: "GetThumb",
                url: "projetos/GetThumb",
                defaults: new { controller = "Projetos", action = "GetThumb" }
            );

            routes.MapRoute(
                name: "ProjetosWithoutProj",
                url: "projetos/{catId}",
                defaults: new { controller = "Projetos", action = "Index", catId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Projetos",
                url: "projetos/{catId}/projeto/{projId}",
                defaults: new { controller = "Projetos", action = "Index", projId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Welcome", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
