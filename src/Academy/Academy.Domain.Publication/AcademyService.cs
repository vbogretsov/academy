using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.DataAccess;
using Academy.Security;

namespace Academy.Domain.Services
{
    public class AcademyService
    {
        public AcademyService(
            IStorageFactory storageFactory,
            RoleManager roleManager,
            AccountManager accountManager)
        {
            var disciplineStorage = storageFactory.CreateDisciplineStorage();
            var userStorage = storageFactory.CreateUserStorage();
            var articleStorage = storageFactory.CreateArticleStorage();
            Notification = new NotificationService(disciplineStorage, userStorage);
            Publication = new PublicationService(userStorage, articleStorage, disciplineStorage);
            Account = new AccountService(roleManager, accountManager, userStorage);
            Files = new FilesStore();
        }

        public NotificationService Notification
        {
            get;
            private set;
        }

        public PublicationService Publication
        {
            get;
            private set;
        }

        public AccountService Account
        {
            get;
            set;
        }

        public FilesStore Files
        {
            get;
            set;
        }
    }
}
