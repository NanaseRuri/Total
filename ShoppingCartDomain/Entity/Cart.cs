using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartDomain.Entity
{
    public class Cart
    {
         List<CartLine> ProductTotal=new List<CartLine>();

        public IEnumerable<CartLine> Lines { get=>ProductTotal; }

        public void Add(Product product, int quantity)
        {
            CartLine target = ProductTotal.FirstOrDefault(c => c.Product.ProductId == product.ProductId);
            if (target==null)
            {
                ProductTotal.Add(new CartLine(){Product = product,Quantity = quantity});
            }
            else
            {
                target.Quantity += quantity; 
            }
        }

        public void Remove(Product product)
        {
            ProductTotal.RemoveAll(c => c.Product.ProductId == product.ProductId);
        }

        public decimal ComputeToSum()
        {
            return ProductTotal.Sum(c => c.Product.Price * c.Quantity);
        }

        public void Clear()
        {
            ProductTotal.Clear();
        }

        public class CartLine
        {
            public Product Product;
            public int Quantity;
        }
    }
}