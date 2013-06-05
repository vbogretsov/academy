using System;
using System.Threading;
using System.Web.Mvc;
using Academy.Presentation.Unity;
using Academy.Security;

namespace Academy.Presentation.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private const string SecurityInitializationFailed =
            "The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588";

        //private static SimpleMembershipInitializer initializer;
        //private static object initializerLock = new object();
        //private static bool isInitialized;

        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    // Ensure ASP.NET Simple Membership is initialized only once per app start
        //    LazyInitializer.EnsureInitialized(
        //        ref initializer,
        //        ref isInitialized,
        //        ref initializerLock);
        //}

        //private class SimpleMembershipInitializer
        //{
        //    public SimpleMembershipInitializer()
        //    {
        //        InitializeSecurity();
        //        InitializeRoles();
        //    }
        //}

        //private static void InitializeSecurity()
        //{
        //    AccountManager accountManager = ApplicationContainer
        //        .Instance.Resolve<AccountManager>();
        //    try
        //    {
        //        accountManager.InitializeDatabaseConnection(
        //            "AcademyEntities",
        //            "academy_User",
        //            "UserId",
        //            "Email", true);
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new InvalidOperationException(
        //            SecurityInitializationFailed,
        //            exception);
        //    }
        //}

        //private static void InitializeRoles()
        //{
        //    RoleManager roleManager = ApplicationContainer.Instance
        //        .Resolve<RoleManager>();
        //    if (!roleManager.RoleExists("User"))
        //    {
        //        roleManager.CreateRole("User");
        //    }
        //    if (!roleManager.RoleExists("Admin"))
        //    {
        //        roleManager.CreateRole("Admin");
        //    }
        //}
    }
}