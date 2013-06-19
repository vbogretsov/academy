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

        public NotificationService(IStorageFactory storageFactory)
        {
            disciplineStorage = storageFactory.CreateDisciplineStorage();
            userStorage = storageFactory.CreateUserStorage();
        }

        public NotificationService(
            DisciplineStorage disciplineStorage,
            UserStorage userStorage)
        {
            this.disciplineStorage = disciplineStorage;
            this.userStorage = userStorage;
        }

        public void Subscribe(User user)
        {
            user.Disciplines = disciplineStorage.Resolve(
                user.Disciplines.Select(x => x.DisciplineId)).ToList();
            userStorage.Update(user);
        }

        public IEnumerable<Discipline> GetDisciplines()
        {
            return disciplineStorage.GetDisciplines();
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
