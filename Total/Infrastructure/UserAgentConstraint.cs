using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Total.Infrastructure
{
    public class UserAgentConstraint:IRouteConstraint
    {
        private string constraint;

        public UserAgentConstraint(string constraint)
        {
            this.constraint = constraint;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            return httpContext.Request.UserAgent != null && httpContext.Request.UserAgent.Contains(constraint);
        }
    }
}