using System;
using Academy.Domain.DataAccess.Ef.Storages;

namespace Academy.Domain.DataAccess.Ef
{
    public class EfStorageFactory : IStorageFactory
    {
        //private static readonly AcademyEntities academyEntities = new AcademyEntities();

        private readonly AcademyEntities academyEntities;

        public EfStorageFactory(AcademyEntities academyEntities)
        {
            this.academyEntities = academyEntities;
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

        public QuestionStorage CreateQuestionStorage()
        {
            return new EfQuestionStorage(academyEntities);
        }
    }
}
