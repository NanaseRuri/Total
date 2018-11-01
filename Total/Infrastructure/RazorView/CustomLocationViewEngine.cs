using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Total.Infrastructure.RazorView
{
    public class CustomLocationViewEngine:RazorViewEngine
    {
        public CustomLocationViewEngine()
        {
            ViewLocationFormats = new[]
            {
                "~/Views/{1}/{0}.cshtml", "~/Views/Time/{0}.cshtml"
            };
        }
    }
}