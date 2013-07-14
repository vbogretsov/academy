using System;
using System.Collections.Generic;
using System.Linq;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal class EfAnswerStorage : EfEntityStorage, IAnswerStorage
    {
        public EfAnswerStorage(AcademyEntities academyEntities)
            :base(academyEntities)
        {
        }

        public void Add(Answer answer)
        {
            Add(answer, Entities.Answers);
        }

        public void Remove(int answerId)
        {
            Remove(answerId, Entities.Answers);
        }

        public IPageData<Answer> GetUserAnswers(int userId, int page, int size)
        {
            var query = GetUserAnserwsQuery(userId);
            return GetPage(query, page, size, GetUserAnswersCount(userId));
        }

        public IPageData<Answer> GetQuestionAnswers(int questionId, int page, int size)
        {
            var query = GetQuestionAnswersQuery(questionId);
            return GetPage(query, page, size, GetQuestionAnswersCount(questionId));
        }

        private IEnumerable<Answer> GetUserAnserwsQuery(int userId)
        {
            return from answer in Entities.Answers
                where answer.UserId == userId
                orderby answer.PostedDate descending
                select answer;
        }

        private int GetUserAnswersCount(int userId)
        {
            return GetUserAnserwsQuery(userId).Count();
        }

        private IEnumerable<Answer> GetQuestionAnswersQuery(int questionId)
        {
            return from answer in Entities.Answers
                    where answer.QuestionId == questionId
                   orderby answer.PostedDate descending
                select answer;
        }

        private int GetQuestionAnswersCount(int questionId)
        {
            return GetQuestionAnswersQuery(questionId).Count();
        }
    }
}
