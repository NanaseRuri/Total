using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Total.Infrastructure.Routes
{
    public class CustomHttpHandler:IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("Hello");
        }

        public bool IsReusable { get=>false; }
    }
}