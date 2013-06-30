using System;
using Academy.Domain.DataAccess;
using Academy.Domain.Interface;

namespace Academy.Domain.Services
{
    public class AdministrationService : IAdministrationService
    {
        private readonly IDataContext context;

        public AdministrationService(IDataContext context)
        {
            this.context = context;
        }

        public void RemoveArticle(int articleId)
        {
            context.ArticleStorage.Remove(articleId);
        }

        public void RemoveComment(int commentId)
        {
            context.CommentStorage.Remove(commentId);
        }

        public void RemoveQuestion(int questionId)
        {
            context.QuestionStorage.Remove(questionId);
        }

        public void RemoveAnswer(int answerId)
        {
            context.AnswerStorage.Remove(answerId);
        }
    }
}
