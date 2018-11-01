using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Total.Controllers.ActionsAndResults
{
    public class BasicController : ControllerBase,IController
    {
        public new void Execute(RequestContext requestContext)
        {
            string controller = (string)requestContext.RouteData.Values["controller"];
            string action = (string)requestContext.RouteData.Values["action"];

            if (action.ToLower() == "redirect")
            {
                requestContext.HttpContext.Response.Redirect("/Derived/Index");
            }
            else
            {
                requestContext.HttpContext.Response.Write($"Controller: {controller}, Action: {action}");
            }
        }

        protected override void ExecuteCore()
        {            
        }
    }
}