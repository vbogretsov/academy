using System;
using Academy.Domain.DataAccess;
using Academy.Domain.Objects;

namespace Academy.Domain.Services.Notifications
{
    internal class QuestionNotification :ByDisciplinesNotification<QuestionNews>
    {
        public QuestionNotification(
            IByDisciplinesNotifiable notifiable,
            IDataContext context)
            : base(notifiable, context, context.QuestionNewsStorage)
        {
        }

        protected override QuestionNews CreateEmptyNews()
        {
            return new QuestionNews();
        }
    }
}
