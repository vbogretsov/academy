using System;
using System.Collections.Generic;
using System.Linq;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal class EfArticleNewsStorage : EfNewsStorage<ArticleNews>
    {
        public EfArticleNewsStorage(AcademyEntities academyEntities)
            :base(academyEntities.ArticleNewses, academyEntities)
        {
        }
    }
}
