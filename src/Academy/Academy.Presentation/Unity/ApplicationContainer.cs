using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Academy.Domain.DataAccess;
using Academy.Domain.DataAccess.Ef;
using Academy.Domain.Services;
using Academy.Security;
using Academy.Security.Simple;
using Microsoft.Practices.Unity;

namespace Academy.Presentation.Unity
{
    public class ApplicationContainer
    {
        private static ApplicationContainer instance;

        private readonly IUnityContainer unityContainer;

        public static ApplicationContainer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApplicationContainer();
                }
                return instance;
            }
        }

        private ApplicationContainer()
        {
            unityContainer = new UnityContainer();
        }

        public void RegisterComponents()
        {
            unityContainer.RegisterType<IStorageFactory, EfStorageFactory>();
            unityContainer.RegisterType<RoleManager, WebMatrixRoleManager>();
            unityContainer.RegisterType<AccountManager, WebMatrixAccountManager>();
            var storageFactry = unityContainer.Resolve<IStorageFactory>();
            unityContainer.RegisterInstance(new AcademyService(storageFactry));
            unityContainer.RegisterInstance(storageFactry.CreateDisciplineStorage());
            unityContainer.RegisterInstance(storageFactry.CreateUserStorage());
            unityContainer.RegisterInstance(storageFactry.CreateArticleStorage());
            unityContainer.RegisterInstance(storageFactry.CreateCommentStorage());
        }

        public T Resolve<T>()
        {
            return unityContainer.Resolve<T>();
        }

        public AcademyService Service
        {
            get
            {
                return unityContainer.Resolve<AcademyService>();
            }
        }

        public UserStorage UserStorage
        {
            get
            {
                return unityContainer.Resolve<UserStorage>();
            }
        }

        public DisciplineStorage DisciplineStorage
        {
            get
            {
                return unityContainer.Resolve<DisciplineStorage>();
            }
        }
    }
}