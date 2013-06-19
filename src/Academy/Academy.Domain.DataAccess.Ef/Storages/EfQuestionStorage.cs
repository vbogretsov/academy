using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal class EfQuestionStorage : QuestionStorage
    {
        private readonly AcademyEntities academyEntities;

        public EfQuestionStorage(AcademyEntities academyEntities)
        {
            this.academyEntities = academyEntities;
        }

        public override void Add(Question question)
        {
            try
            {
                academyEntities.Questions.Add(question);
                academyEntities.SaveChanges();
            }
            catch (Exception exception)
            {
                var s = exception.Message;
            }
        }
    }
}
