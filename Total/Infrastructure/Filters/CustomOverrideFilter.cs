using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Total.Infrastructure.Filters
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple = false,Inherited = false)]
    public class CustomOverrideFilter:FilterAttribute,IOverrideFilter
    {
        public Type FiltersToOverride
        {
            get => typeof(IActionFilter);
        }
    }
}