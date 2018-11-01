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
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;


        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        // GET: Product
        //public ActionResult List()
        //{
        //    return View(repository.Products);
        //}

        //public ViewResult List(int page=1)
        //{
        //    return View(repository.Products.OrderBy(p => p.
        // ).Skip((page - 1) * PageSize).Take(PageSize));
        //}

        public ViewResult List(string category, int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel()
            {
                Products = repository.Products.Where(p => category == null || p.Category == category).OrderBy(p => p.ProductId).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(e => e.Category == category).Count(),
                },
                CurrentCategory = category
            };

            return View(model);
        }

        public FileContentResult GetImage(int productId)
        {
            Product target = repository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (target!=null)
            {
                return File(target.ImageData, target.ImageMimeType);
            }

            return null;
        }
    }
}