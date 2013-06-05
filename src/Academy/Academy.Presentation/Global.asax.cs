using System;
using System.Globalization;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;
using Academy.Presentatio;
using Academy.Presentation.App_Start;
using Academy.Presentation.Unity;
using Academy.Presentation.Utils;
using Academy.Resources;

namespace Academy.Presentation
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ApplicationContainer.Instance.RegisterComponents();
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            SetLanguage(Session);
        }

        private static void SetLanguage(HttpSessionState session)
        {
            if (session["Language"] == null)
            {
                session["Language"] = "lang.eng";
            }
        }
    }
}