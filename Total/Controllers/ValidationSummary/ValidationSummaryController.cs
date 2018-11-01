using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Total.Infrastructure.ValidationSummary;
using Total.Models.ValidationSummary;

namespace Total.Controllers.ValidationSummary
{

    public class ValidationSummaryController : Controller
    {
        public ActionResult MakePointing()
        {
            Appointment appointment=new Appointment(){Date = DateTime.Now};
            return View(appointment);
        }

        [HttpPost]
        public ActionResult MakePointing(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                return View("Complete",appointment);
            }
            return View();
        }

        public JsonResult RemoteValidate(string Date)
        {
            DateTime parsedDate;
            if (!DateTime.TryParse(Date,out parsedDate))
            {
                return Json("Please enter a valie date (yyyy/mm/dd)",JsonRequestBehavior.AllowGet);
            }

            if (parsedDate<DateTime.Now)
            {
                return Json("Your appointed date must be in the future", JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}