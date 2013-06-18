using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.DataAccess;
using Academy.Domain.DataAccess.Ef;
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
            unityContainer.RegisterType<IStorageFactory, EfStorageFactory>();
            
        }
    }
}
