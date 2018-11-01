using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Total.Models.NinjectTest
{
    public class LinqValueCalculator:IValueCalculator
    {
        private IDiscountHelper discountHelper;

        public LinqValueCalculator(IDiscountHelper discountHelper)
        {
            this.discountHelper = discountHelper;
        }

        public decimal ValueProduct(IEnumerable<Product> products)
        {
            return discountHelper.ApplyDiscount(products.Sum(m => m.Price));
        }
    }
}