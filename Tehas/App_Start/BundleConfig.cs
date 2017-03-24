using System.Web;
using System.Web.Optimization;

namespace Tehas.Frontend
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/ajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/addtocart").Include(
                        "~/Scripts/addtocart.js"));

            bundles.Add(new ScriptBundle("~/bundles/deleteImage").Include(
                        "~/Scripts/deleteImage.js"));

            bundles.Add(new ScriptBundle("~/bundles/lazyload").Include(
                        "~/Scripts/lazyload.js"));

            bundles.Add(new ScriptBundle("~/bundles/jcarousellite").Include(
                        "~/Scripts/jcarousellite_1.0.1c5.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/fancybox").Include(
                        "~/Scripts/jquery.easing.1.3.js",
                        "~/Scripts/jquery.fancybox-1.2.1.pack.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/Scripts/jqueryval").Include(
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js"));

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
