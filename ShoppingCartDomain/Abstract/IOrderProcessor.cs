using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartDomain.Entity;

namespace ShoppingCartDomain.Abstract
{
    public interface IOrderProcessor
    {
        bool ProcessOrder(Cart cart, ShippingDetails shippingDetail);
        string ErrorMessage { get; set; }

    }
}