using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Academy.Domain.DataAccess;
using Academy.Domain.DataAccess.Ef;
using Academy.Domain.Interface;
using Academy.Domain.Interface.Facade;
using Academy.Domain.Objects;
using Academy.Domain.Search;
using Academy.Domain.Services;
using Academy.Security;
using Academy.Security.Simple;

namespace Academy.Web.Services
{
    public class AcademyService : IAcademyService, IDisposable
    {
        private static readonly AccountManager accountManager;

        private static readonly RoleManager roleManager;

        private readonly IDataContext context;

        private AccountService accountService;

        private IPublicationService publicationService;

        private INoteService noteService;

        private INotificationService notificationService;

        private ISearchService searchService;

        private IQuestionService questionService;

        private IFileService fileService;

        private IAdministrationService administrationService;

        static AcademyService()
        {
            accountManager = new WebMatrixAccountManager();
            roleManager = new WebMatrixRoleManager();
        }

        public AcademyService()
        {
            context = new EfDataContext();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Update(User user)
        {
            Account.Update(user);
        }

        public User GetCurrentUser()
        {
            return Account.GetCurrentUser();
        }

        public bool IsUserExists(string userName)
        {
            return Account.IsUserExists(userName);
        }

        public bool Login(string username, string password, bool remember = false)
        {
            return Account.Login(username, password, remember);
        }

        public void Logout()
        {
            Account.Logout();
        }

        public void Register(User user, string password)
        {
            Account.Register(user, password);
        }

        public void RemoveArticle(int articleId)
        {
            AdministrationService.RemoveArticle(articleId);
        }

        public void RemoveComment(int commentId)
        {
            AdministrationService.RemoveComment(commentId);
        }

        public void RemoveQuestion(int questionId)
        {
            AdministrationService.RemoveQuestion(questionId);
        }

        public void RemoveAnswer(int answerId)
        {
            AdministrationService.RemoveAnswer(answerId);
        }

        public void Add(Note note)
        {
            NoteService.Add(note);
        }

        public void Remove(int noteId)
        {
            // TODO: add note owner check
            NoteService.Remove(noteId);
        }

        public IEnumerable<Note> GetNotes(int userId)
        {
            return NoteService.GetNotes(userId);
        }

        public void Ask(Question question)
        {
            QuestionService.Ask(question);
            NotificationService.NotifyAboutNewQuestion(question);
        }

        public void Answer(Answer answer)
        {
            answer.UserId = GetCurrentUser().Id;
            QuestionService.Answer(answer);
            NotificationService.NotifyAboutNewAnswer(answer);
        }

        public Question GetQuestion(int questionId)
        {
            return QuestionService.GetQuestion(questionId);
        }

        // TODO: use userId
        public IEnumerable<Answer> GetAnswers(User user)
        {
            return QuestionService.GetAnswers(user);
        }

        // TODO: use userId
        public IEnumerable<Question> GetQuestions(User user)
        {
            return QuestionService.GetQuestions(user);
        }

        public void Publish(Article article)
        {
            article.Authors.Add(GetCurrentUser());
            PublicationService.Publish(article);
            NotificationService.NotifyAboutNewArticle(article);
        }

        public void Comment(Comment comment)
        {
            comment.UserId = GetCurrentUser().Id;
            PublicationService.Comment(comment);
            NotificationService.NotifyAboutNewComment(comment);
        }

        public Article GetArticle(int articleId)
        {
            return PublicationService.GetArticle(articleId);
        }

        // TODO: use userId
        public IEnumerable<Comment> GetComments(User user)
        {
            return PublicationService.GetComments(user);
        }

        // TODO: use userId
        public IEnumerable<Article> GetArticles(User user)
        {
            return PublicationService.GetArticles(user);
        }

        public SearchResult<Article> FindArticles(ArticleSearchCriteria criteria)
        {
            return SearchService.FindArticles(criteria);
        }

        public SearchResult<Question> FindQuestions(QuestionSearchCriteria criteria)
        {
            return SearchService.FindQuestions(criteria);
        }

        public void Subscribe(int userId, IEnumerable<int> disciplineIds)
        {
            NotificationService.Subscribe(userId, disciplineIds);
        }

        public IEnumerable<Discipline> GetDisciplines()
        {
            return NotificationService.GetDisciplines();
        }

        // TODO: use userId
        public IEnumerable<AnswerNews> GetAnswerNews(User user)
        {
            return NotificationService.GetAnswerNews(user);
        }

        // TODO: use userId
        public IEnumerable<QuestionNews> GetQuestionNews(User user)
        {
            return NotificationService.GetQuestionNews(user);
        }

        // TODO: use userId
        public IEnumerable<CommentNews> GetCommentNews(User user)
        {
            return NotificationService.GetCommentNews(user);
        }

        // TODO: use userId
        public IEnumerable<ArticleNews> GetArticleNews(User user)
        {
            return NotificationService.GetArticleNews(user);
        }

        public void NotifyAboutNewAnswer(Answer answer)
        {
            throw new NotSupportedException();
        }

        public void NotifyAboutNewComment(Comment comment)
        {
            throw new NotSupportedException();
        }

        public void NotifyAboutNewQuestion(Question question)
        {
            throw new NotSupportedException();
        }

        public void NotifyAboutNewArticle(Article article)
        {
            throw new NotSupportedException();
        }

        public string Upload(Stream fileStream, string folderName, string fileName)
        {
            return FileService.Upload(fileStream, folderName, fileName);
        }

        private AccountService Account
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

        private IPublicationService PublicationService
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

        private INotificationService NotificationService
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

        private ISearchService SearchService
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

        private INoteService NoteService
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

        private IQuestionService QuestionService
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

        private IFileService FileService
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

        private IAdministrationService AdministrationService
        {
            get
            {
                if (administrationService == null)
                {
                    administrationService = new AdministrationService(context);
                }
                return administrationService;
            }
        }
    }
}
