using System.Web.Mvc;

namespace Total.Controllers.Routes
{
    [RoutePrefix("Customer")]
    public class UrlsCustomerController : Controller
    {
        // GET: UrlsCustomer
        [Route("~/Index")]
        public ActionResult Index()
        {
            ViewBag.Controller = "Customer";
            ViewBag.Action = "Index";
            return View("ActionName");
        }

        [Route("Create/{user}/{id:int}")]
        public string CreateAccount(string user,int id)
        {
            return $"Surprised, Create User: {user}, Id: {id}";
        }

        [Route("Create/{user}/{password:alpha:length(6)}")]
        public string ChangePassword(string user, string password)
        {
            return $"{user} change {password}";
        }
    }
}