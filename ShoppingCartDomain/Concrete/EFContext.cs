using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ShoppingCartDomain.Entity;

namespace ShoppingCartDomain.Concrete
{
    public class EFContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

    }
}