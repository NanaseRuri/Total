using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Total.Infrastructure.ControllerExtensibility;

namespace Total.Controllers.ControllerExtensibility
{
    public class ActionInvokerController : Controller
    {
        public ActionInvokerController()
        {
            this.ActionInvoker=new CustomActionInvoker();
        }
    }
}