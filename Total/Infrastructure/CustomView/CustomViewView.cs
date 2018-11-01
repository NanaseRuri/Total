using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Total.Infrastructure.CustomView
{
    public class CustomViewView:IView
    {
        public void Render(ViewContext viewContext, TextWriter writer)
        {
            Write(writer,"---Route Data---");
            foreach (var valuesKey in viewContext.RouteData.Values.Keys)
            {
                Write(writer,"Key: {0}, Value: {1}",valuesKey,viewContext.RouteData.Values[valuesKey]);
            }

            Write(writer,"---View Data---");
            foreach (var key in viewContext.ViewData.Keys) 
            {
                Write(writer,"Key: {0}, Value: {1}",key,viewContext.ViewData[key]);
            }
        }

        private void Write(TextWriter writer, string template,params object[] values)
        {
            writer.Write(string.Format(template,values)+"<p/>");
        }
    }
}