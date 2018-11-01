using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Total.Infrastructure.CustomView
{
    public class CustomViewEngine:IViewEngine
    {
        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            return new ViewEngineResult(new string[]{"No such engine"});
        }

        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            if (viewName=="CustomView")
            {
                return new ViewEngineResult(new CustomViewView(),this);
            }return new ViewEngineResult(new string[]{"No view engine"});
        }

        public void ReleaseView(ControllerContext controllerContext, IView view)
        {            
        }
    }
}