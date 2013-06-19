using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.DataAccess;
using Academy.Domain.DataAccess.Ef;
using Academy.Domain.Interface;
using Academy.Domain.Services;
using Academy.Security;
using Academy.Security.Simple;

namespace Academy.Web.Services
{
    public class AcademyContext : IDisposable
    {
        private static readonly AccountManager accountManager;

        private static readonly RoleManager roleManager;

        static AcademyContext()
        {
            accountManager = new WebMatrixAccountManager();
            roleManager = new WebMatrixRoleManager();
        }

        private readonly AcademyEntities academyEntities;

        private readonly IStorageFactory storageFactory;

        private AccountService accountService;

        private IPublicationService publicationService;

        private INoteService noteService;

        private INotificationService notificationService;

        private IQuestionService questionService;

        private IFileService fileService;

        public AcademyContext()
        {
            academyEntities = new AcademyEntities();
            storageFactory = new EfStorageFactory(academyEntities);
        }

        public AccountService Account
        {
            get
            {
                if (accountService == null)
                {
                    accountService = new AccountService(
                        roleManager,
                        accountManager,
                        storageFactory.CreateUserStorage());
                }
                return accountService;
            }
        }

        public IPublicationService PublicationService
        {
            get
            {
                if (publicationService == null)
                {
                    publicationService = new PublicationService(storageFactory);
                }
                return publicationService;
            }
        }

        public INotificationService NotificationService
        {
            get
            {
                if (notificationService == null)
                {
                    notificationService = new NotificationService(storageFactory);
                }
                return notificationService;
            }
        }

        public INoteService NoteService
        {
            get
            {
                if (noteService == null)
                {
                    noteService = new NoteService(storageFactory);
                }
                return noteService;
            }
        }

        public IQuestionService QuestionService
        {
            get
            {
                if (questionService == null)
                {
                    questionService = new QuestionService(storageFactory);
                }
                return questionService;
            }
        }

        public IFileService FileService
        {
            get
            {
                if (fileService == null)
                {
                    fileService = new FileService();
                }
                return fileService;
            }
        }

        public void Dispose()
        {
            academyEntities.Dispose();
        }
    }
}
