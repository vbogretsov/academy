using System;
using Academy.Domain.DataAccess;
using Academy.Domain.Objects;

namespace Academy.Domain.Services.Notifications
{
    internal class ArticleNotification : ByDisciplinesNotification<ArticleNews>
    {
        public ArticleNotification(
            IByDisciplinesNotifiable notifiable,
            IDataContext context)
            :base(notifiable, context, context.ArticleNewsStorage)
        {
        }

        protected override ArticleNews CreateEmptyNews()
        {
            return new ArticleNews();
        }
    }
}
