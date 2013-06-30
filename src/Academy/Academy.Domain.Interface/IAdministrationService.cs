using System;

namespace Academy.Domain.Interface
{
    public interface IAdministrationService
    {
        void RemoveArticle(int articleId);

        void RemoveComment(int commentId);

        void RemoveQuestion(int questionId);

        void RemoveAnswer(int answerId);
    }
}
