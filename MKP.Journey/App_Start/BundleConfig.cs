using System.Web;
using System.Web.Optimization;

namespace MKP.Journey
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap/bootstrap.min.css",
                        "~/Content/site.css",
                        "~/SPA/Less/MyStyleSheet.css"));

            bundles.Add(new ScriptBundle("~/js/app").Include(
                        "~/Scripts/jquery-3.3.1.min.js",
                        "~/Scripts/angular.min.js",
                        "~/Scripts/angular-route.min.js",
                        "~/Scripts/bootstrap.min.js.js",
                        "~/Scripts/Chart.min.js.js",
                        "~/Scripts/angular-chart.min.js",
                        "~/Scripts/jquery.signalR-2.2.3.min.js",
                        "~/SPA/App.js",
                        "~/SPA/Controller/ChatSupportController.js",
                        "~/SPA/Controller/CreateAccountController.js",
                        "~/SPA/Controller/HandleVehicleController.js",
                        "~/SPA/Controller/JourneyReportController.js",
                        "~/SPA/Controller/LoginController.js",
                        "~/SPA/Controller/LogoutController.js",
                        "~/SPA/Controller/NewJourneyController.js",
                        "~/SPA/Controller/SummaryController.js"
                ));
        }
    }
}
