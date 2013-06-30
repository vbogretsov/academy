using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;
using Academy.Domain.Search;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal class EfQuestionStorage : EfEntityStorage, IQuestionStorage
    {
        public EfQuestionStorage(AcademyEntities academyEntities)
            :base(academyEntities)
        {
        }

        public Question Get(int questionId)
        {
            return Get(questionId, Entities.Questions);
        }

        public void Add(Question question)
        {
            Add(question, Entities.Questions);
        }

        public void Remove(int questionId)
        {
            Remove(questionId, Entities.Questions);
        }

        public IEnumerable<Question> GetUserQuestions(int userId)
        {
            return Entities.Questions.Where(x => x.UserId == userId);
        }

        public IEnumerable<Question> FindQuestions(QuestionSearchCriteria criteria)
        {
            return from question in Entities.Questions
                where question.Title.Contains(criteria.Keyword) &&
                    question.Disciplines.Any(d => criteria.Disciplines.Contains(d.Id))
                select question;
        }
    }
}
