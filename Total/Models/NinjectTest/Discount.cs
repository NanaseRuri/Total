using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Total.Models.NinjectTest
{
    public class DefaultDiscount:IDiscountHelper
    {
        public decimal Discount { get; set; }

        public decimal ApplyDiscount(decimal total)
        {
            return total - Discount / 100m * total;
        }
    }
}