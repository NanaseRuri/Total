using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Total.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundleCollection)
        {
            bundleCollection.Add(new StyleBundle("~/Content/css").Include("~/Content/*.css"));
            bundleCollection.Add(new ScriptBundle("~/Bundles/ClientFeatureScripts").
                Include("~/Scripts/jquery-{version}.js","~/Scripts/jquery.validate.js",
                    "~/Scripts/jquery.validate.unobtrusive.js","~/Scripts/jquery.unobtrusive-ajax.js"));
        }
    }
}