using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Total.Models.HelperMethods;

namespace Total.Controllers.HelperMethod
{
    public class HelperMethodController : Controller
    {
        // GET: HelperMethod
        public ActionResult InnerOuterHelper()
        {
            ViewBag.Lovers = new[] {"Zhouyi", "GokouRuri", "IsshikiIroha"};
            ViewBag.Items = new[] {"Uncle Yuan", "Xie Ying", "Li Huaxin"};
            string text = "I love Gokou Ruri";
            return View((object)text);
        }

        public ActionResult CreatePerson()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult CreatePerson(Person person)
        {
            return View("DisplayPerson",person);
        }
    }
}