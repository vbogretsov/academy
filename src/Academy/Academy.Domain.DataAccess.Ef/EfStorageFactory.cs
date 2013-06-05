using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.DataAccess.Ef.Storages;

namespace Academy.Domain.DataAccess.Ef
{
    public class EfStorageFactory : IStorageFactory
    {
        private readonly AcademyEntities academyEntities;

        public EfStorageFactory()
        {
            academyEntities = new AcademyEntities();
        }

        public UserStorage CreateUserStorage()
        {
            return new EfUserStorage(academyEntities);
        }

        public CommentStorage CreateCommentStorage()
        {
            return new EfCommentStorage(academyEntities);
        }

        public ArticleStorage CreateArticleStorage()
        {
            return new EfArticleStorage(academyEntities);
        }

        public DisciplineStorage CreateDisciplineStorage()
        {
            return new EfDisciplineStorage(academyEntities);
        }
    }
}
