using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Total.Controllers.ControllerExtensibility;

namespace Total.Infrastructure.ControllerExtensibility
{
    public class CustomControllerActivator:IControllerActivator
    {
        public IController Create(RequestContext requestContext, Type controllerType)
        {
            if (controllerType==typeof(ProductForChangeController))
            {
                controllerType = typeof(FastController);
            }
                
            return (IController) DependencyResolver.Current.GetService(controllerType);
        }
    }
}