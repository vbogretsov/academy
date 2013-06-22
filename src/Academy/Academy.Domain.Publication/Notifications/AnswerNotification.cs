using System;
using Academy.Domain.DataAccess;
using Academy.Domain.Objects;

namespace Academy.Domain.Services.Notifications
{
    internal class AnswerNotification
    {
        private readonly Answer answer;

        private readonly IDataContext context;

        public AnswerNotification(Answer answer, IDataContext context)
        {
            this.answer = answer;
            this.context = context;
        }

        public void Send()
        {
            var question = context.QuestionStorage.Get(answer.QuestionId);
            var user = context.UserStorage.Get(question.UserId);
            CreateNews(user.Id, answer.Id);
        }

        private void CreateNews(int userId, int answerId)
        {
            var news = new AnswerNews();
            news.UserId = userId;
            news.EntityId = answerId;
            context.AnswerNewsStorage.Add(news);
        }
    }
}
