using System.Web.Optimization;

namespace IdentitySample
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                       "~/Scripts/vendor/purecounter/purecounter.js", "~/Scripts/vendor/aos/aos.js", "~/Scripts/vendor/bootstrap/js/bootstrap.bundle.min.js", "~/Scripts/vendor/swiper/swiper-bundle.min.js", "~/Scripts/vendor/php-email-form/validate.js", "~/Scripts/js/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/vendor/animate.css/animate.min.css", "~/Content/vendor/aos/aos.css", "~/Content/vendor/bootstrap/css/bootstrap.min.css", "~/Content/vendor/bootstrap-icons/bootstrap-icons.css", "~/Content/vendor/boxicons/css/boxicons.min.css", "~/Content/vendor/remixicon/remixicon.css", "~/Content/vendor/swiper/swiper-bundle.min.css", "~/Content/css/style.css"));
        }
    }
}
