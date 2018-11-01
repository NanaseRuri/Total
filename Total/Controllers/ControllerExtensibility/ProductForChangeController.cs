using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Total.Controllers.ControllerExtensibility
{
    public class ProductForChangeController : Controller
    {
        public string Index()
        {
            ViewBag.Controller = RouteData.Values["controller"].ToString();
            ViewBag.Action = RouteData.Values["action"];
            return "hello";
        }
    }
}