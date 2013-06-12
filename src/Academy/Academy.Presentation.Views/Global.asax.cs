using System;
using System.Globalization;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;
using Academy.Presentation.Views;
using Academy.Presentation.Views.App_Start;
using Academy.Presentation.Views.Unity;
using Academy.Security;

namespace Academy.Presentation
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
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
            ApplicationContainer.Instance.RegisterComponents();
            InitializeSecurity();
            InitializeRoles();
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            try
            {
                SetLanguage(Session);
            }
            catch
            {
                
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
            AccountManager accountManager = ApplicationContainer
                .Instance.Resolve<AccountManager>();
            try
            {
                accountManager.InitializeDatabaseConnection(
                    "AcademyEntities",
                    "academy_User",
                    "UserId",
                    "Email", true);
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
            RoleManager roleManager = ApplicationContainer.Instance
                .Resolve<RoleManager>();
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