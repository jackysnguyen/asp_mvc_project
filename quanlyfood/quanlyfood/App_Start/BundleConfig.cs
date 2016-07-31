using System.Web;
using System.Web.Optimization;

namespace quanlyfood
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.easing.1.3.js",
                        "~/Scripts/jquery.carouFredSel-6.2.0-packed.js",
                        "~/Scripts/jquery.prettyPhoto.js",
                        "~/Scripts/jquery.wookmark.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.backup.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/camera.min.js",
                      "~/Scripts/default.js",
                      "~/Scripts/app.js"
                      ))
                      ;

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.backup.css",
                      "~/Content/bootstrap-responsive.css",
                      "~/Content/custom.css",
                      "~/Content/font-awesome.4.3.css",
                      "~/Content/general-foundicons.css",
                      "~/Content/social_foundicons.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/carousel-css").Include(
                "~/Content/carousel-style.css",
                "~/Content/camera.css"
                      ));
            bundles.Add(new StyleBundle("~/Content/wookmark-css").Include(
                "~/Content/prettyPhoto.css",
                "~/Content/wookmark-style.css"
                      ));
        }
    }
}
