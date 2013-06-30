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

        public IEnumerable<ArticleNews> GetArticleNews(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentNews> GetCommentNews(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QuestionNews> GetQuestionNews(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AnswerNews> GetAnswerNews(User user)
        {
            throw new NotImplementedException();
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
