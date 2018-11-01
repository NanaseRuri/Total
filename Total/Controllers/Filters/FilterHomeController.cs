using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Total.Infrastructure.Filters;

namespace Total.Controllers.Filters
{
    public class FilterHomeController : Controller
    {
        private Stopwatch sw;

        [GoogleAuth]
        public string Google()
        {
            return "Google";
        }

        [RangeException]
        public string Range(int id)
        {
            if (id>450)
            {
                throw new ArgumentOutOfRangeException("id",id,"");
            }
            return "Range";
        }

        [RangeExceptionPage]
        public string RangePage(int id)
        {
            if (id>450)
            {
                throw new ArgumentOutOfRangeException("id",id,"");
            }

            return "RangePage";
        }


        [TimeActionTake]
        [TimeAllTake]
        [TimeResultTake]
        public string TimeTake()
        {
            return "TimeTake";
        }


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            sw=Stopwatch.StartNew();
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext.Exception==null||filterContext.ExceptionHandled)
            {
                sw.Stop();
                filterContext.HttpContext.Response.Write($"The class takes {sw.Elapsed.TotalSeconds:f6}");
            }
        }
    }
}