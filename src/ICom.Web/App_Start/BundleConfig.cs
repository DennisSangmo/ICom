using System.Web.Optimization;

namespace ICom.Web.App_Start
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Assets/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Assets/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Assets/Scripts/jquery.unobtrusive*",
                        "~/Assets/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Assets/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Assets/Css/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Assets/Content/themes/base/jquery.ui.core.css",
                        "~/Assets/Content/themes/base/jquery.ui.resizable.css",
                        "~/Assets/Content/themes/base/jquery.ui.selectable.css",
                        "~/Assets/Content/themes/base/jquery.ui.accordion.css",
                        "~/Assets/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Assets/Content/themes/base/jquery.ui.button.css",
                        "~/Assets/Content/themes/base/jquery.ui.dialog.css",
                        "~/Assets/Content/themes/base/jquery.ui.slider.css",
                        "~/Assets/Content/themes/base/jquery.ui.tabs.css",
                        "~/Assets/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Assets/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Assets/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}