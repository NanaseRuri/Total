using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartDomain.Abstract;
using ShoppingCartDomain.Entity;
using Total.Models.SportStore;

namespace Total.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private IProductRepository reposity;
        private IOrderProcessor processor;

        public CartController(IProductRepository reposity, IOrderProcessor processor)
        {
            this.reposity = reposity;
            this.processor = processor;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel() {ReturnUrl = returnUrl, Cart = cart});
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = reposity.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product!=null)
            {
                cart.Add(product,1);
            }

            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = reposity.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product!=null)
            {
                cart.Remove(product);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetail)
        {
            if (cart.Lines.Count()==0)
            {
                ModelState.AddModelError("","Sorry, but your cart is empty");                
            }

            if (ModelState.IsValid)
            {
                if (processor.ProcessOrder(cart, shippingDetail))
                {
                    cart.Clear();
                    return View("Completed");
                }
                ModelState.AddModelError("","Sorry, the mail failed to deliver "+processor.ErrorMessage);
            }

            return View(shippingDetail);
        }
    }
}