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

        private readonly IDataContext context;

        private AccountService accountService;

        private IPublicationService publicationService;

        private INoteService noteService;

        private INotificationService notificationService;

        private ISearchService searchService;

        private IQuestionService questionService;

        private IFileService fileService;

        public AcademyContext()
        {
            context = new EfDataContext();
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
                        context);
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
                    publicationService = new PublicationService(context);
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
                    notificationService = new NotificationService(context);
                }
                return notificationService;
            }
        }

        public ISearchService SearchService
        {
            get
            {
                if (searchService == null)
                {
                    searchService = new SearchService(context);
                }
                return searchService;
            }
        }

        public INoteService NoteService
        {
            get
            {
                if (noteService == null)
                {
                    noteService = new NoteService(context);
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
                    questionService = new QuestionService(context);
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
            context.Dispose();
        }
    }
}
