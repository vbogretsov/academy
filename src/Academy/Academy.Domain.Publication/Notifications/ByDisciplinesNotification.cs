using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.DataAccess;
using Academy.Domain.Objects;

namespace Academy.Domain.Services.Notifications
{
    internal abstract class ByDisciplinesNotification<T> where T : News
    {
        private readonly IByDisciplinesNotifiable notifiable;

        private readonly IDataContext context;

        private readonly INewsStorage<T> newsStorage;

        protected ByDisciplinesNotification(
            IByDisciplinesNotifiable notifiable,
            IDataContext context,
            INewsStorage<T> newsStorage)
        {
            this.notifiable = notifiable;
            this.context = context;
            this.newsStorage = newsStorage;
        }

        public void Send()
        {
            var disciplines = context.DisciplineStorage.Get(
                notifiable.Disciplines.Select(x => x.Id)).ToList();
            foreach (var discipline in disciplines)
            {
                var users = context.UserStorage.GetByDiscipline(discipline.Id).ToList();
                foreach (var user in users)
                {
                    CreateNews(user.Id, notifiable.Id);
                }
            }
        }

        private void CreateNews(int userId, int notifiableId)
        {
            if (!newsStorage.Exists(userId, notifiableId))
            {
                T news = CreateEmptyNews();
                news.UserId = userId;
                news.EntityId = notifiableId;
                newsStorage.Add(news);
            }
        }

        protected abstract T CreateEmptyNews();
    }
}
