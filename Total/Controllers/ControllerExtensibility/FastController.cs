using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace Total.Controllers.ControllerExtensibility
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class FastController : Controller
    {        
        // GET: Fast
        public ActionResult Index()
        {
            ViewBag.Controller = RouteData.Values["controller"].ToString();
            ViewBag.Action = RouteData.Values["action"];
            return View("ActionName");
        }
    }
}