using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Total.Models.SportStore
{
    public class ProductListViewModel
    {
        public IEnumerable<ShoppingCartDomain.Entity.Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }

    }
}