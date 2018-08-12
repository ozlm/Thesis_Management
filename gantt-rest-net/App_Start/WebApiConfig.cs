using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace gantt_rest_net
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Task",
                routeTemplate: "api/data/task/{id}",
                defaults: new { controller = "Task", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Link",
                routeTemplate: "api/data/link/{id}",
                defaults: new { controller = "Link", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Data",
                routeTemplate: "api/data",
                defaults: new { controller = "Data" }
            );

            config.Routes.MapHttpRoute(
                name: "StudentGant",
            routeTemplate: "api/StudentGant",
            defaults: new { controller = "StudentGant" }
                );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}