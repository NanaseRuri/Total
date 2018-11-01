using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Total.Models;
using Total.Models.ExtensionMethod;

namespace Total.Controllers
{
    public class CustomExtensionController : Controller
    {
        private List<Product> products = new List<Product>()
        {
            new Product() {Name = "Kayak",Category = "Watersports",Price = 270m},
            new Product() {Name = "Lifejacket",Category = "Watersports",Price = 2270m},
            new Product() {Name = "Soccer drinks",Category = "Soccer",Price = 2170m},
            new Product() {Name = "Corner flag",Category = "Soccer",Price = 450m}
        };

        // GET: CustomExtension
        public string Index()
        {
            return "First page";
        }

        public string ExtensionByString()
        {
            IEnumerable<Product> target=products.Filter("Soccer");
            decimal sum = 0;
            foreach (var product in target)
            {
                sum += product.Price;
            }

            return $"The total price is {sum:C0}";
        }

        public string ExtensionByFunc()
        {
            IEnumerable<Product> target = products.Filter(m => m.Category == "Soccer");
            decimal sum = 0;
            foreach (var product in target)
            {
                sum += product.Price;
            }

            return $"The func total price is {sum}";
        }
    }
}