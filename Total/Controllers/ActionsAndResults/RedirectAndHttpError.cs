using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Total.Controllers.ActionsAndResults
{
    public class RedirectAndHttpErrorController:Controller
    {
        private static string ControllerName = "RedirectAndHttpError ";

        public ActionResult Index()
        {
            ViewBag.Title = ControllerName+"Index";
            return View();
        }

        //临时重定向
        public RedirectResult RedirectTemp()
        {
            ViewBag.Title = ControllerName + "RedirectTemp";
            return Redirect("/RedirectAndHttpError/Index");
        }

        public RedirectResult RedirectPermanent()
        {
            ViewBag.Title = ControllerName + "RedirectPermanent";
            TempData["Wao"] = "Surprised?";
            return RedirectPermanent("/RedirectAndHttpError/Index");
        }

        public HttpStatusCodeResult Status()
        {
            return new HttpStatusCodeResult(404,"Fucking Status not found");
        }

        public HttpStatusCodeResult Status2()
        {
            return new HttpUnauthorizedResult();
        }

        public HttpStatusCodeResult Status3()
        {
            return new HttpNotFoundResult();
        }
    }
}