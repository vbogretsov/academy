﻿using System;
using System.Collections.Generic;
using System.IO;
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

        public IPageData<Note> GetUserNotes(int userId, int page, int size)
        {
            return NoteService.GetUserNotes(userId, page, size);
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

        public IPageData<Question> GetUserQuestions(int userId, int page, int size)
        {
            return QuestionService.GetUserQuestions(userId, page, size);
        }

        public IPageData<Answer> GetUserAnswers(int userId, int page, int size)
        {
            return QuestionService.GetUserAnswers(userId, page, size);
        }

        public IPageData<Answer> GetQuestionAnswers(int questionId, int page, int size)
        {
            return QuestionService.GetQuestionAnswers(questionId, page, size);
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

        public IPageData<Article> GetUserArticles(int userId, int page, int size)
        {
            return PublicationService.GetUserArticles(userId, page, size);
        }

        public IPageData<Comment> GetUserComments(int userId, int page, int size)
        {
            return PublicationService.GetUserComments(userId, page, size);
        }

        public IPageData<Comment> GetArticleComments(int articleId, int page, int size)
        {
            return PublicationService.GetArticleComments(articleId, page, size);
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

        public IPageData<ArticleNews> GetArticleNews(int userId, int page, int size)
        {
            return NotificationService.GetArticleNews(userId, page, size);
        }

        public IPageData<CommentNews> GetCommentNews(int userId, int page, int size)
        {
            return NotificationService.GetCommentNews(userId, page, size);
        }

        public IPageData<QuestionNews> GetQuestionNews(int userId, int page, int size)
        {
            return NotificationService.GetQuestionNews(userId, page, size);
        }

        public IPageData<AnswerNews> GetAnswerNews(int userId, int page, int size)
        {
            return NotificationService.GetAnswerNews(userId, page, size);
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
