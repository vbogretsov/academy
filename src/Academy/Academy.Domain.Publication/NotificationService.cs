using System;
using System.Collections.Generic;
using System.Linq;
using Academy.Domain.DataAccess;
using Academy.Domain.Interface;
using Academy.Domain.Objects;

namespace Academy.Domain.Services
{
    public class NotificationService : INotificationService
    {
        private readonly DisciplineStorage disciplineStorage;
        private readonly UserStorage userStorage;

        public NotificationService(
            DisciplineStorage disciplineStorage,
            UserStorage userStorage)
        {
            this.disciplineStorage = disciplineStorage;
            this.userStorage = userStorage;
        }

        public void AssigneDisciplines(User user, IEnumerable<int> disciplineIds)
        {
            user.Disciplines = disciplineStorage.Resolve(disciplineIds).ToList();
            userStorage.Update();
        }

        public void Subscribe(User user)
        {
            throw new NotImplementedException();
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

        public IEnumerable<QuestionNews> GetAnswerNews(User user)
        {
            throw new NotImplementedException();
        }
    }
}
