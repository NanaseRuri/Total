using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Total.Infrastructure.ControllerExtensibility;

namespace Total.Controllers.ControllerExtensibility
{
    public class CustomerController : Controller
    {
        // GET: Customer
        [ActionName("wao")]
        public ActionResult Index()
        {
            ViewBag.Id = 567;
            return View("ActionName");
        }

        [NonAction]
        public ActionResult NotAnAction()
        {
            return View("ActionName");
        }

        protected override void HandleUnknownAction(string actionName)
        {
            Response.Write(actionName+" is not found.");
        }

        [Local]
        public ActionResult LocalAction()
        {
            return View("ActionName");
        }
    }
}