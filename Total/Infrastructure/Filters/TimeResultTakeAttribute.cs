using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Total.Infrastructure.Filters
{
    public class TimeResultTakeAttribute:FilterAttribute,IResultFilter
    {
        private Stopwatch sw;
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            sw=Stopwatch.StartNew();            
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext.Exception==null)
            {
                sw.Stop();
                filterContext.HttpContext.Response.Write(
                    $"<div>Result takes {sw.Elapsed.TotalSeconds:f6}");
            }
        }
    }
}