using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Total.Infrastructure;

namespace Total.Controllers.ActionsAndResults
{
    public class DerivedController : Controller
    {
        // GET: Derived
        public ActionResult Index()
        {
            ViewBag.Message = "Isshiki Iroha";
            return View();
        }

        public ActionResult Product()
        {
            if (Server.MachineName=="Nanase")
            {
                //return Redirect("/Basic/Index");

                return new CustomRedirect(){Url = "Basic/Index"};

            }
            
            Response.Write(Server.MachineName);
            return null;
        }
    }
}