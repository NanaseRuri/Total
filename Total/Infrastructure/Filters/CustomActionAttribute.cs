using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace Total.Infrastructure.Filters
{
    public class CustomActionAttribute:FilterAttribute,IActionFilter
    {       
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsLocal)
            {
                filterContext.Result=new HttpNotFoundResult();
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
    }
}