using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Total.Models;
using Total.Models.NinjectTest;

namespace Total.Controllers
{
    public class NinjectController : Controller
    {
        private IValueCalculator valueCalculator;
        private Product[] products = {
            new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
            new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
            new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
            new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
        };

        //public NinjectController(IValueCalculator valueCalculator)
        //{
        //    this.valueCalculator = valueCalculator;
        //}

        public NinjectController(IValueCalculator valueCalculator1, IValueCalculator iValueCalculator2)
        {
            this.valueCalculator = valueCalculator1;
        }
         
        // GET: Ninject
        public ActionResult Index()
        {
            //IKernel ninjectKernel = new StandardKernel();
            //ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            //IValueCalculator valueCalculator = ninjectKernel.Get<IValueCalculator>();
            
            ShoppingCart cart=new ShoppingCart(valueCalculator){Products = products};
            decimal totalValue = cart.Sum();
            return View(totalValue);
        }
    }
}