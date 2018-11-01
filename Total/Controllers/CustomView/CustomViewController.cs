using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Total.Controllers.CustomView
{
    public class CustomViewController : Controller
    {
        // GET: CustomView
        public ActionResult Index()
        {
            ViewBag.Message = "Hello world";
            ViewBag.Time = DateTime.Now;
            return View("CustomView");
        }

        public ActionResult List()
        {
            return View();
        }
    }
}