using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Total.Infrastructure.ControllerExtensibility
{
    public class CustomActionInvoker:IActionInvoker
    {
        public bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            if (actionName=="Index")
            {
                controllerContext.HttpContext.Response.Write("It's the return from invoke action");
                return true;
            }

            return false;

        }
    }
}