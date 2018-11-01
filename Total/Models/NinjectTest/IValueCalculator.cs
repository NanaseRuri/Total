using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Total.Models.NinjectTest
{
    public interface IValueCalculator
    {
        decimal ValueProduct(IEnumerable<Product> products);
    }
}
