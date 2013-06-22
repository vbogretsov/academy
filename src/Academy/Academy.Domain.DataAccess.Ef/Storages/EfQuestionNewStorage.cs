using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal class EfQuestionNewStorage : EfNewsStorage<QuestionNews>
    {
        public EfQuestionNewStorage(AcademyEntities academyEntities)
            :base(academyEntities.QuestionNewses, academyEntities)
        {
        }
    }
}
