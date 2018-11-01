using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Total.Models.NinjectTest
{
    public class FlexibleDiscount:IDiscountHelper
    {
        public decimal ApplyDiscount(decimal total)
        {
            decimal discount = total > 100 ? 70 : 25;
            return total - discount / 100 * total;
        }
    }
}