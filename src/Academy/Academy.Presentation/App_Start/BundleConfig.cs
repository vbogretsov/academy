using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Academy.Presentation.App_Start
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-dropdown").Include(
                "~/Scripts/bootstrap-dropdown.js"));

            bundles.Add(new ScriptBundle("~/bundles/tree").Include(
                "~/Scripts/tree.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                    .Include("~/Content/bootstrap*")
                    .Include("~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/Content/tree")
                .Include("~/Content/tree.css"));
        }
    }
}