using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Total.Models.NinjectTest
{
    public class ShoppingCart
    {
        private IValueCalculator valueCalculator;

        public ShoppingCart(IValueCalculator valueCalculator)
        {
            this.valueCalculator = valueCalculator;
        }

        public IEnumerable<Product> Products { get; set; }

        public decimal Sum()
        {
            return valueCalculator.ValueProduct(Products);
        }
    }
}