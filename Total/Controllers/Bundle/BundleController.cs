using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Total.Models.Bundle;

namespace Total.Controllers.Bundle
{
    public class BundleController : Controller
    {
        // GET: Bundle
        public ActionResult MakeBooking()
        {
            Appointment appointment=new Appointment(){ClientName = "wao",TermsAccepted = true};
            return View(appointment);
        }

        [HttpPost]
        public JsonResult MakeBooking(Appointment appointment)
        {
            return Json(appointment, JsonRequestBehavior.AllowGet);
        }
    }
}