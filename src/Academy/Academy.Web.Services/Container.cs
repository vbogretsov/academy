using System;
using Academy.Security;
using Academy.Security.Simple;
using Microsoft.Practices.Unity;

namespace Academy.Web.Services
{
    public class Container
    {
        private static readonly Container instance = new Container();

        private readonly IUnityContainer unityContainer;

        public static Container Instance
        {
            get
            {
                return instance;
            }
        }

        private Container()
        {
            unityContainer = new UnityContainer();
            unityContainer.RegisterType<AccountManager, WebMatrixAccountManager>();
            unityContainer.RegisterType<RoleManager, WebMatrixRoleManager>();
        }

        public T Resolve<T>()
        {
            return unityContainer.Resolve<T>();
        }
    }
}
