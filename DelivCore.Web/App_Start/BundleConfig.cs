using System.Web;
using System.Web.Optimization;

namespace DelivCore.Web
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

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/moment.js",
                      "~/Scripts/globals.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/metisMenu/metisMenu.js",
                      "~/Scripts/raphael/raphael.js",
                      "~/Scripts/morrisjs/morris.js",
                      "~/Scripts/sb-admin-2.js",
                      "~/Scripts/datatables/jQuery.dataTables.js",
                      "~/Scripts/datatables/dataTables.bootstrap.js",
                      "~/Scripts/datatables-plugins/dataTables.boostrap.js",
                      "~/Scripts/datatables-responsive/dataTables.responsive.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/metisMenu/metisMenu.css",
                      "~/Content/sb-admin-2.css",
                      "~/Content/datatables/dataTables.bootstrap.css",
                      "~/Content/datatables-plugins/dataTables.bootstrap.css",
                      "~/Content/datatables-responsive/dataTables.responsive.css",
                      "~/Content/morrisjs/morris.css",
                      "~/Content/font-awesome.css",
                      "~/Content/site.css"));
        }
    }
}
