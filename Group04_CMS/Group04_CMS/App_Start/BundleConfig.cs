using System.Web;
using System.Web.Optimization;

namespace Group04_CMS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.4.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/tweekbootstrapvalidation.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.min.js"));

           bundles.Add(new ScriptBundle("~/bundles/Account").Include(
                        "~/Scripts/Group04_CMS/Account/account.module.js",
                        "~/Scripts/Group04_CMS/Account/account.controller.js",
                        "~/Scripts/Group04_CMS/Account/accountService.js"
                    ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/AdminLTE.css",
                      "~/Content/site.css"));


            bundles.Add(new ScriptBundle("~/EducationManager/bundles/jquery").Include(
            "~/Scripts/jquery-2.1.4.js"));

            bundles.Add(new ScriptBundle("~/EducationManager/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/EducationManager/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/EducationManager/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/EducationManager/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/AdminLTE.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/Teacher/bundles/jquery").Include(
                    "~/Scripts/jquery-2.1.4.js"));

            bundles.Add(new ScriptBundle("~/Teacher/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/Teacher/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/Teacher/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Teacher/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/AdminLTE.css",
                      "~/Content/site.css"));
        }
    }
}
