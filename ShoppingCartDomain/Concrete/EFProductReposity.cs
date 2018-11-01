using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartDomain.Abstract;
using ShoppingCartDomain.Entity;

namespace ShoppingCartDomain.Concrete
{
    public class EFProductRepository:IProductRepository
    {
        private EFContext context=new EFContext();
        public IEnumerable<Product> Products { get=>context.Products; }

        public void SaveProduct(Product product)
        {
            if (product.ProductId==0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product target = context.Products.Find(product.ProductId);
                if (target!=null)
                {
                    target.Name = product.Name;
                    target.Description = product.Description;
                    target.Price = product.Price;
                    target.Category = product.Category;
                    target.ImageData = product.ImageData;
                    target.ImageMimeType = product.ImageMimeType;
                }
            }

            context.SaveChanges();
        }

        public Product Delete(int productId)
        {
            Product target = context.Products.Find(productId);
            if (target!=null)
            {
                context.Products.Remove(target);
            }

            context.SaveChanges();
            return target;
        }
    }
}