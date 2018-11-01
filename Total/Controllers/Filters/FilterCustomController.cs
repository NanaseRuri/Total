using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Total.Infrastructure.Filters;

namespace Total.Controllers.Filters
{
    [Simple("A")]
    public class FilterCustomController : Controller
    {       
        [Simple("B")]
        public string Normal()
        {            
            return "Index";
        }

        [Simple("B", Order = 2)]
        [Simple("A1", Order = 1)]
        public string UseOrder()
        {
            return "UseOrder";
        }

        [Simple("B")]
        [Simple("A1")]
        public string NotUseOrder()
        {
            return "UseOrder";
        }

        [Simple("B")]
        [CustomOverrideFilter]
        public string Override()
        {
            return "UseOverride";
        }


        [CustomAction]
        public string IsLocal()
        {
            return "IsNotLocal";
        }
    }
}