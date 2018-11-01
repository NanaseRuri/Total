using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;
using Total.Infrastructure;
using Total.Infrastructure.Routes;

namespace Total
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.RouteExistingFiles = true;
            routes.MapMvcAttributeRoutes();
            //routes.Add(new Route("SayHello", new CustomRouteHandler()));
            //routes.MapMvcAttributeRoutes();

            //routes.MapRoute("", "{*catchall}", new {controller = "UrlsAndRoutesHome", action = "Index"},
            //    new UserAgentConstraint("Chrome"), new[] {"Total.AdditionalController"});

            //Route myRoute=new Route("{controller}/{action}",new MvcRouteHandler());
            //routes.Add("MyRoute",myRoute);

            //routes.MapRoute("MyRoute", "{controller}/{action}", new { controller = "Home", action = "Index" },null,new []{"Total.AdditionalController"});
            routes.MapRoute("MyRoute", "{controller}/{action}", new { controller = "Home", action = "Index" });
            routes.MapRoute("AddControllerRoute", "{controller}/{action}/{id}/{*catchall}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, new { controller = "^H.*", action = "^Index$|^About$" }, new[] { "UrlsAndRoutes.AdditionalControllers" });

            //给 URL 上别名
            routes.MapRoute("Changed", "New/{action}", new { controller = "UrlsAndRoutesHome", action = "Index", }
                , null, new[] { "Total.Controllers" });
            routes.MapRoute("SurprisedChanged", "Surprised{controller}/{action}", new { controller = "UrlsAndRoutesHome", action = "Index", }
                , null, new[] { "Total.Controllers" });
            //routes.MapRoute("SurprisedChanged", "{controller}/{action}/{*catchAll}", new {controller = "UrlsAndRoutesHome", action = "Index",}
            //    , null, new[] {"Total.Controllers"});

            //加正则
            //routes.MapRoute("AddRegular", "Regular/{controller}/{action}/{id}",
            //    new { controller = "Account", action = "login", id = UrlParameter.Optional },
            //    new { controller = "^A.*$", action = "^Login$|^List$" },
            //    new[] { "Total.Controllers" });

            //HTTP 方法约束路由  强制将这条路由限制到GET请求
            routes.MapRoute("AddRegular", "Regular/{controller}/{action}/{id}",
                new { controller = "Account", action = "login", id = UrlParameter.Optional },
                new
                {
                    controller = "^A.*$",
                    action = "^Login$|^List$",
                    httpMethod = new HttpMethodConstraint("GET"),
                    //id=new RangeRouteConstraint(10,20)
                    id = new CompoundRouteConstraint(new List<IRouteConstraint>()
                    {
                        new AlphaRouteConstraint(),
                        new MinLengthRouteConstraint(6)
                    })
                },
                new[] { "Total.Controllers" });

            Route myRoute = routes.MapRoute("All", "Final/{controller}/{action}/{*c}", null, null, new[] { "Total.Controllers" });
            //myRoute.DataTokens["UseNamespaceFallback"] = false;

            ////老旧 routes
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(null, "",
            //    new {controller = "Product", action = "List", category = (string) null, page = 1});

            //routes.MapRoute(null, "Page{Page}",
            //    new {controller = "Product", action = "List", category = (string) null});

            //routes.MapRoute(null, "{category}", new {controller = "Product", action = "List"});

            //routes.MapRoute(null, "{controller}/{action}");



        }
    }
}
