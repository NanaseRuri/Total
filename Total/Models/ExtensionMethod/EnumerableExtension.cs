using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Total.Models.ExtensionMethod
{
    public static class EnumerableExtension
    {
        public static IEnumerable<Product> Filter(this IEnumerable<Product>products,string categoryName)
        {
            foreach (var product in products)
            {
                if (product.Category==categoryName)
                {
                    yield return product;
                }
            }
        }

        public static IEnumerable<Product> Filter(this IEnumerable<Product> products, Func<Product, bool> judgement)
        {
            foreach (var product in products)
            {
                if (judgement(product))
                {
                    yield return product;
                }
            }
        }
    }
}