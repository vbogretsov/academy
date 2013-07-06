using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Academy.Domain.DataAccess;
using Academy.Domain.Interface;
using Academy.Domain.Objects;
using Academy.Domain.Services.Notifications;

namespace Academy.Domain.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IDataContext context;
        private readonly IDisciplineStorage disciplineStorage;
        private readonly IUserStorage userStorage;

        public NotificationService(IDataContext context)
        {
            this.context = context;
            disciplineStorage = context.DisciplineStorage;
            userStorage = context.UserStorage;
        }

        public void Subscribe(int userId, IEnumerable<int> disciplineIds)
        {
            var disciplines = disciplineStorage.Get(disciplineIds);
            userStorage.UpdateDisciplines(userId, disciplines.Select(x => x.Id));
        }

        public IEnumerable<Discipline> GetDisciplines()
        {
            return disciplineStorage.Get();
        }

        public IPageData<ArticleNews> GetArticleNews(int userId, int page, int size)
        {
            return context.ArticleNewsStorage.Get(userId, page, size);
        }

        public IPageData<CommentNews> GetCommentNews(int userId, int page, int size)
        {
            return context.CommentNewsStorage.Get(userId, page, size);
        }

        public IPageData<QuestionNews> GetQuestionNews(int userId, int page, int size)
        {
            return context.QuestionNewsStorage.Get(userId, page, size);
        }

        public IPageData<AnswerNews> GetAnswerNews(int userId, int page, int size)
        {
            return context.AnswerNewsStorage.Get(userId, page, size);
        }

        public void NotifyAboutNewArticle(Article article)
        {
            ThreadPool.QueueUserWorkItem(s => NotifyAboutNewsArticleAsync(article));
        }

        public void NotifyAboutNewQuestion(Question question)
        {
            ThreadPool.QueueUserWorkItem(s => NotifyAboutNewsQuestionAsync(question));
        }

        public void NotifyAboutNewComment(Comment comment)
        {
            ThreadPool.QueueUserWorkItem(s => NotifyAboutNewsCommentAsync(comment));
        }

        public void NotifyAboutNewAnswer(Answer answer)
        {
            ThreadPool.QueueUserWorkItem(s => NotifyAboutNewAnswerAsync(answer));
        }

        private void NotifyAboutNewsArticleAsync(Article article)
        {
            using (var threadContext = context.Fork())
            {
                new ArticleNotification(article,threadContext).Send();
            }
        }

        private void NotifyAboutNewsQuestionAsync(Question question)
        {
            using (var threadContext = context.Fork())
            {
                new QuestionNotification(question, threadContext).Send();
            }
        }

        private void NotifyAboutNewsCommentAsync(Comment comment)
        {
            using (var threadContext = context.Fork())
            {
                new CommentNotification(comment, threadContext).Send();
            }
        }

        private void NotifyAboutNewAnswerAsync(Answer answer)
        {
            using (var threadContext = context.Fork())
            {
                new AnswerNotification(answer, threadContext).Send();
            }
        }
    }
}
