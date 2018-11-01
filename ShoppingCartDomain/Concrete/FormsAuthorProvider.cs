using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using ShoppingCartDomain.Abstract;

namespace ShoppingCartDomain.Concrete
{
    public class FormsAuthorProvider:IAuthorProvider
    {
        public bool Authenticate(string userName, string password)
        {
            //bool result = FormsAuthentication.Authenticate(userName, password);
            bool result=Membership.ValidateUser(userName, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(userName,false);
            }

            return result;
        }
    }
}