using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Total.Models.Home;

namespace Total.Controllers
{
    public class HomeController : Controller
    {


        // GET: Home
        public ViewResult Index()
        {
            ViewBag.Greeting = DateTime.Now.Hour < 12 ? "Good morning!" : "Good evening";
            return View();
        }

        [HttpPost]
        public ViewResult Rsvp(Guest guest)
        {
            if (ModelState.IsValid)
            {
                return View("Completed",guest);
            }

            return View();
        }

        [HttpGet]
        public ViewResult Rsvp()
        {
            return View();
        }
    }
}