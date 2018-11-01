using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Total.AdditionalController
{
    public class UrlsAndRoutesHomeController : Controller
    {
        // GET: UrlsAndRoutesHome
        public ActionResult Index()
        {
            ViewBag.Controller = "Home-AdditionalController";
            ViewBag.Action = "Index";
            return View("ActionName");
        }
    }
}