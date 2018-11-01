using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Total.Models.NinjectTest
{
    public interface IDiscountHelper
    {
        decimal ApplyDiscount(decimal total);
    }
}
