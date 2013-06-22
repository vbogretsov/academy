using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

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
            //return Entities.Questions.SingleOrDefault(x => x.Id == questionId);
            return Get(questionId, Entities.Questions);
        }

        public void Add(Question question)
        {
            Add(question, Entities.Questions);
            //try
            //{
            //    Entities.Questions.Add(question);
            //    Entities.SaveChanges();
            //}
            //catch (Exception exception)
            //{
            //    var s = exception.Message;
            //}
        }

        public IEnumerable<Question> GetUserQuestions(int userId)
        {
            return Entities.Questions.Where(x => x.UserId == userId);
        }
    }
}
