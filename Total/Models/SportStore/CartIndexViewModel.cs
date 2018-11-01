using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartDomain.Entity;

namespace Total.Models.SportStore
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}