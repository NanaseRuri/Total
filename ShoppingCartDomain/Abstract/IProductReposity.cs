using ShoppingCartDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartDomain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        void SaveProduct(Product product);

        Product Delete(int productId);
    }
}