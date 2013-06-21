using System;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal class EfAnswerStorage : IAnswerStorage
    {
        private readonly AcademyEntities academyEntities;

        public EfAnswerStorage(AcademyEntities academyEntities)
        {
            this.academyEntities = academyEntities;
        }

        public void Add(Answer answer)
        {
            academyEntities.Answers.Add(answer);
            academyEntities.SaveChanges();
        }
    }
}
