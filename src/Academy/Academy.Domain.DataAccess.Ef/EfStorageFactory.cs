using System;
using Academy.Domain.DataAccess.Ef.Storages;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef
{
    internal class EfStorageFactory : IStorageFactory
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

        public INewsStorage<ArticleNews> CreateArticleNewsStorage()
        {
            return new EfArticleNewsStorage(academyEntities);
        }

        public INewsStorage<QuestionNews> CreateQuestionNewsStorage()
        {
            return new EfQuestionNewStorage(academyEntities);
        }

        public INewsStorage<CommentNews> CreateCommentNewsStorage()
        {
            return new EfCommentNewsStorage(academyEntities);
        }

        public INewsStorage<AnswerNews> CreateAnswerNewsStorage()
        {
            return new EfAnswerNewsStorage(academyEntities);
        }
    }
}
