using System.Web.Mvc;

namespace Total.Controllers.Routes
{
    public class UrlsAndRoutesHomeController : Controller
    {
        // GET: UrlsAndRoutes
        public ActionResult Index()
        {
            ViewBag.Controller = "Admin";
            ViewBag.Action = "Index";
            return View("ActionName");
        }

        public ActionResult CompareVariable(string id = "default")
        {

            ViewBag.Controller = "Admin";
            ViewBag.Action = "CompareVariable";
            ViewBag.Id = id;
            return View("ActionName");
        }
    }
}