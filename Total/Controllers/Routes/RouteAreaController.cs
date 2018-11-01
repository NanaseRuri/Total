using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Total.Controllers.Routes
{
    [RouteArea("AreaTest")]
    [RoutePrefix("Fuck")]
    public class RouteAreaController : Controller
    {
        // GET: RouteArea
        [Route("Test")]
        public ActionResult Index()
        {
            ViewBag.Controller = "Route";
            ViewBag.Action = "Index";
            return View("ActionName");
        }

        [Route("~/ForTest")]

        public ActionResult Index1()
        {
            ViewBag.Controller = "Route";
            ViewBag.Action = "Index";
            return View("ActionName");
        }
    }
}