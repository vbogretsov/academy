using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;
using Academy.Domain.DataAccess.Ef;
using Academy.Presentation.Views;
using Academy.Presentation.Views.App_Start;
using Academy.Security;
using Academy.Test.DataGenerating;
using Academy.Web.Services;

namespace Academy.Presentation
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 5
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private const string SecurityInitializationFailed =
            "The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588";

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitializeSecurity();
            InitializeRoles();
            GenerateTestData();
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            try
            {
                SetLanguage(Session);
            }
            catch
            {
                //TODO: add something :)
            }
        }

        private static void GenerateTestData()
        {
            bool generateTestData = Convert.ToBoolean(
                ConfigurationManager.AppSettings["TestDataGenerationMode"]);
            if (generateTestData)
            {
                var testDataPath = ConfigurationManager.AppSettings["TestDataPath"];
                var generator = new TestDataGenerator(
                    testDataPath,
                    new AcademyService());
                generator.GenerateTestData();
            }
        }

        private static void SetLanguage(HttpSessionState session)
        {
            if (session != null && session["Language"] == null)
            {
                session["Language"] = "lang.eng";
            }
        }

        private static void InitializeSecurity()
        {
            var accountManager = Container.Instance.Resolve<AccountManager>();
            try
            {
                accountManager.InitializeDatabaseConnection(
                    "AcademyEntities",
                    "academy_User",
                    "UserId",
                    "Email",
                    true);
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException(
                    SecurityInitializationFailed,
                    exception);
            }
        }

        private static void InitializeRoles()
        {
            var roleManager = Container.Instance.Resolve<RoleManager>();
            if (!roleManager.RoleExists("User"))
            {
                roleManager.CreateRole("User");
            }
            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.CreateRole("Admin");
            }
        }
    }
}