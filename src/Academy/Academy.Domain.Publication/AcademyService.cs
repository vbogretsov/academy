using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.DataAccess;
using Academy.Domain.Interface;
using Academy.Security;

namespace Academy.Domain.Services
{
    public class AcademyService : IAcademyService
    {
        public AcademyService(IStorageFactory storageFactory)
        {
            var disciplineStorage = storageFactory.CreateDisciplineStorage();
            var userStorage = storageFactory.CreateUserStorage();
            var articleStorage = storageFactory.CreateArticleStorage();
            //Notifications = new NotificationService(disciplineStorage, userStorage);
            //Publications = new PublicationService(userStorage, articleStorage, disciplineStorage);
            //Account = new AccountService(roleManager, accountManager, userStorage);
            //Files = new FilesStore();
        }

        public IQuestionService QuestionServices
        {
            get;
            private set;
        }

        public INotificationService Notifications
        {
            get;
            private set;
        }

        public INoteService Notes
        {
            get;
            private set;
        }

        public IPublicationService Publications
        {
            get;
            private set;
        }

        //public AccountService Account
        //{
        //    get;
        //    set;
        //}

        //public FilesStore Files
        //{
        //    get;
        //    set;
        //}
    }
}
