using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Total.Models;

namespace Total.Controllers
{
    public class ViewStartController : Controller
    {
        Product myProduct = new Product()
        {
            Category = "Lover",
            Description = "A cute girl",
            Name = "Zhouyi",
            Price = 19980807m,
            ProductId = 54
        };

        // GET: ViewStart
        public ActionResult Index()
        {
            return View(myProduct);
        }

        public ViewResult DemoExpression()
        {
            ViewBag.IsGoodGirl = null;
            ViewBag.IsBeautiful = true;
            ViewBag.IsGenerous = true;
            ViewBag.IsSmart = false;
            ViewBag.Level = 2;
            return View(myProduct);
        }

        public ViewResult DemoArray()
        {
            List<Product> products = new List<Product>
            {
                new Product() {Name = "Kayak", Price = 275M},
                new Product() {Name = "Lifejacket", Price = 25M},
                new Product() {Name = "Soccer ball", Price = 120M},
                new Product() {Name = "Conner ball", Price = 600M},

            };

            return View(products);
        }
    }


}