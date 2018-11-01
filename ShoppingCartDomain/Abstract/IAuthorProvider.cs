using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartDomain.Abstract
{
    public interface IAuthorProvider
    {
        bool Authenticate(string userName, string password);
    }
}