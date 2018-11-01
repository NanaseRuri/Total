using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartDomain.Abstract;

namespace Total.Controllers
{
    public class CartNavigationController : Controller
    {
        private IProductRepository repo;

        // GET: Nav
        //public string Menu()
        //{
        //    return "Hello from navController";
        //}

        public CartNavigationController(IProductRepository repo)
        {
            this.repo = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repo.Products.Select(x => x.Category).Distinct().OrderBy(x => x);
            //return PartialView(categories);
            return PartialView("FlexibleLayout", categories);
        }
    }
}