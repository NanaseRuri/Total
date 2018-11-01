using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Total.Infrastructure.Filters
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple = true,Inherited = true)]
    public class SimpleAttribute:FilterAttribute,IActionFilter
    {
        private string message;

        public SimpleAttribute(string message)
        {
            this.message = message;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write(
                $"<div>Before action execute {message}</div>");
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write(
                $"<div>After action execute {message}</div>");
        }
    }
}