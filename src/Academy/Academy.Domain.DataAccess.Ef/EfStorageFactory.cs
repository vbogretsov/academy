using System;
using Academy.Domain.DataAccess.Ef.Storages;

namespace Academy.Domain.DataAccess.Ef
{
    public class EfStorageFactory : IStorageFactory
    {
        private readonly AcademyEntities academyEntities;

        public EfStorageFactory(AcademyEntities academyEntities)
        {
            this.academyEntities = academyEntities;
        }

        public IUserStorage CreateUserStorage()
        {
            return new EfUserStorage(academyEntities);
        }

        public ICommentStorage CreateCommentStorage()
        {
            return new EfCommentStorage(academyEntities);
        }

        public IArticleStorage CreateArticleStorage()
        {
            return new EfArticleStorage(academyEntities);
        }

        public IDisciplineStorage CreateDisciplineStorage()
        {
            return new EfDisciplineStorage(academyEntities);
        }

        public IQuestionStorage CreateQuestionStorage()
        {
            return new EfQuestionStorage(academyEntities);
        }

        public IAnswerStorage CreateAnswerStorage()
        {
            return new EfAnswerStorage(academyEntities);
        }

        public INoteStorage CreateNoteStorage()
        {
            return new EfNoteStorage(academyEntities);
        }
    }
}
