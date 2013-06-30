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

        public IEnumerable<Answer> GetUserAnswers(int userId)
        {
            return Entities.Answers.Where(x => x.UserId == userId);
        }
    }
}
