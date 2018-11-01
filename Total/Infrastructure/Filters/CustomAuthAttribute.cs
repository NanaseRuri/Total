using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Total.Infrastructure.Filters
{
    public class CustomAuthAttribute:AuthorizeAttribute
    {
        private bool canEnter;

        public CustomAuthAttribute(bool canEnter)
        {
            this.canEnter = canEnter;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Request.IsLocal)
            {
                return canEnter;
            }

            return true;
        }
    }
}