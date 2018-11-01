using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartDomain.Abstract;
using ShoppingCartDomain.Entity;

namespace Total.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult List()
        {
            return View(repository.Products);
        }

        public ViewResult Edit(int productId)
        {
            Product target = repository.Products.FirstOrDefault(p => p.ProductId == productId);
            return View(target);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase picData)
        {
            if (ModelState.IsValid)
            {
                if (picData!=null)
                {
                    product.ImageMimeType = picData.ContentType;
                    product.ImageData=new byte[picData.ContentLength];
                    picData.InputStream.Read(product.ImageData, 0, picData.ContentLength);
                }
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("List");
            }

            return View(product);
        }

        public ViewResult Create()
        {
            return View("Edit",new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {            
            Product product = repository.Delete(productId);
            if (product!=null)
            {
                TempData["message"] = $"{product.Name} has been deleted";
            }

            return RedirectToAction("List");
        }       
    }
}