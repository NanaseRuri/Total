using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Web.Optimization;
using ShoppingCartDomain.Entity;
using Total.App_Start;
using Total.Infrastructure.Binders;
using Total.Infrastructure.ControllerExtensibility;
using Total.Infrastructure.CustomView;
using Total.Infrastructure.ModelBinding;
using Total.Infrastructure.RazorView;
using Total.Models.ModelBinding;

namespace Total
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            ControllerBuilder.Current.SetControllerFactory(new DefaultControllerFactory(new CustomControllerActivator()));

            //ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new CustomViewEngine());
            ViewEngines.Engines.Add(new CustomLocationViewEngine());

            //ValueProviderFactories.Factories.Insert(0,new CustomValueProviderFactory());
            ModelBinders.Binders.Add(typeof(AddressSummaryBinder),new AddressSummaryBinder());

            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }
    }
}