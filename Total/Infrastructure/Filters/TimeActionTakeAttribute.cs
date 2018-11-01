using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Total.Infrastructure.Filters
{
    public class TimeActionTakeAttribute:FilterAttribute,IActionFilter
    {
        Stopwatch sw;

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            sw=Stopwatch.StartNew();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            sw.Stop();
            if (filterContext.Exception==null)
            {
                filterContext.HttpContext.Response.Write(
                    $"<div>The action takes {sw.Elapsed.TotalSeconds:F6}</div>");
            }            
        }
    }
}