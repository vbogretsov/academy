using System;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal class EfAnswerStorage : AnswerStorage
    {
        private readonly AcademyEntities academyEntities;

        public EfAnswerStorage(AcademyEntities academyEntities)
        {
            this.academyEntities = academyEntities;
        }

        public override void Add(Answer answer)
        {
            academyEntities.Answers.Add(answer);
            academyEntities.SaveChanges();
        }
    }
}
