﻿using System.Web.Optimization;

namespace Books.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                "~/Scripts/jquery-3.4.1.js",
                "~/Scripts/knockout-3.4.2.debug.js",
                "~/Scripts/knockout.validation.js",
                "~/Scripts/knockout.validation.ru-RU.js",
                "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/App/*.js",
                "~/Scripts/App/Configs/*.js",
                "~/Scripts/App/Resources/*.js",
                "~/Scripts/App/Services/*.js",
                "~/Scripts/App/ViewModels/*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));
        }
    }
}
