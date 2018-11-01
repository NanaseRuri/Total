using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Total.Controllers.RazorViewEngine
{
    public class RazorViewController : Controller
    {
        // GET: RazorView
        public ActionResult Index()
        {
            string[] fruits = {"apple", "banana", "pear"};
            return View(fruits);
        }

        public ActionResult List()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Time()
        {
            return View(DateTime.Now);
        }

        [ChildActionOnly]
        public ActionResult Time2(DateTime dateTime)
        {
            return View("Time",dateTime);
        }
    }
}