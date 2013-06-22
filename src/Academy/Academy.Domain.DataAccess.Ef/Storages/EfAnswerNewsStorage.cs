using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal class EfAnswerNewsStorage : EfNewsStorage<AnswerNews>
    {
        public EfAnswerNewsStorage(AcademyEntities academyEntities)
            :base(academyEntities.AnswerNewses, academyEntities)
        {
        }
    }
}
