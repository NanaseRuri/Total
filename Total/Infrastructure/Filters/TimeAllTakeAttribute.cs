using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace Total.Infrastructure.Filters
{
    public class TimeAllTakeAttribute:ActionFilterAttribute
    {
        Stopwatch sw;

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            sw = Stopwatch.StartNew();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext.Exception==null)
            {
                sw.Stop();
                filterContext.HttpContext.Response.Write(
                    $"<div>Total takes {sw.Elapsed.TotalSeconds:f6} </div>");
            }
        }
    }
}