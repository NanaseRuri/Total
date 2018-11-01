using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using System.Web.Security;

namespace Total.Infrastructure.Filters
{
    public class GoogleAuthAttribute : AuthorizeAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            IIdentity identity = filterContext.Principal.Identity;
            if (!identity.Name.EndsWith("@google.com") || !identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary()
                {
                    {"controller","Account" },
                    { "action","Login"},
                    {"returnUrl",filterContext.HttpContext.Request.RawUrl }
                });
            }

            else
            {
                FormsAuthentication.SignOut();
            }

        }
    }
}