﻿using System.Web;
using System.Web.Optimization;

namespace Tehas.Frontend
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.3.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jcarousellite").Include(
                        "~/Scripts/jcarousellite_1.0.1c5.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/fancybox").Include(
                        "~/Scripts/jquery.easing.1.3.js",
                        "~/Scripts/jquery.fancybox-1.2.1.pack.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                //"~/Content/bootstrap.css",
                      "~/Content/style.css",
                      "~/Content/reset.css",
                      "~/Content/jquery.fancybox.css",
                      "~/Content/tabtastic.css"
                      ));
        }
    }
}
