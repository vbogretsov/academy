using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal class EfCommentNewsStorage : EfNewsStorage<CommentNews>
    {
        public EfCommentNewsStorage(AcademyEntities academyEntities)
            :base(academyEntities.CommentNewses, academyEntities)
        {
        }
    }
}
