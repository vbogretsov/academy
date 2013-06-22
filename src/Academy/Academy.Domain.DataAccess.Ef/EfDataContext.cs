using System;
using Academy.Domain.DataAccess.Ef.Storages;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef
{
    public class EfDataContext : IDataContext
    {
        private readonly AcademyEntities academyEntities;

        private IUserStorage userStorage;

        private IArticleStorage articleStorage;

        private IDisciplineStorage disciplineStorage;

        private ICommentStorage commentStorage;

        private IQuestionStorage questionStorage;

        private IAnswerStorage answerStorage;

        private INewsStorage<ArticleNews> artcileNewsStorage;

        private INewsStorage<CommentNews> commentNewsStorage;

        private INewsStorage<QuestionNews> questionNewsStorage;

        private INewsStorage<AnswerNews> answerNewsStorage;

        public EfDataContext()
        {
            academyEntities = new AcademyEntities();
        }

        public IDataContext Fork()
        {
            return new EfDataContext();
        }

        public void Dispose()
        {
            academyEntities.Dispose();
        }

        public IUserStorage UserStorage
        {
            get
            {
                if (userStorage == null)
                {
                    userStorage = new EfUserStorage(academyEntities);
                }
                return userStorage;
            }
        }

        public IDisciplineStorage DisciplineStorage
        {
            get
            {
                if (disciplineStorage == null)
                {
                    disciplineStorage = new EfDisciplineStorage(academyEntities);
                }
                return disciplineStorage;
            }
        }

        public IArticleStorage ArticleStorage
        {
            get
            {
                if (articleStorage == null)
                {
                    articleStorage = new EfArticleStorage(academyEntities);
                }
                return articleStorage;
            }
        }

        public ICommentStorage CommentStorage
        {
            get
            {
                if (commentStorage == null)
                {
                    commentStorage = new EfCommentStorage(academyEntities);
                }
                return commentStorage;
            }
        }

        public IQuestionStorage QuestionStorage
        {
            get
            {
                if (questionStorage == null)
                {
                    questionStorage = new EfQuestionStorage(academyEntities);
                }
                return questionStorage;
            }
        }

        public IAnswerStorage AnswerStorage
        {
            get
            {
                if (answerStorage == null)
                {
                    answerStorage = new EfAnswerStorage(academyEntities);
                }
                return answerStorage;
            }
        }

        public INewsStorage<ArticleNews> ArticleNewsStorage
        {
            get
            {
                if (artcileNewsStorage == null)
                {
                    artcileNewsStorage = new EfArticleNewsStorage(academyEntities);
                }
                return artcileNewsStorage;
            }
        }

        public INewsStorage<CommentNews> CommentNewsStorage
        {
            get
            {
                if (commentNewsStorage == null)
                {
                    commentNewsStorage = new EfCommentNewsStorage(academyEntities);
                }
                return commentNewsStorage;
            }
        }

        public INewsStorage<QuestionNews> QuestionNewsStorage
        {
            get
            {
                if (questionNewsStorage == null)
                {
                    questionNewsStorage = new EfQuestionNewStorage(academyEntities);
                }
                return questionNewsStorage;
            }
        }

        public INewsStorage<AnswerNews> AnswerNewsStorage
        {
            get
            {
                if (answerNewsStorage == null)
                {
                    answerNewsStorage = new EfAnswerNewsStorage(academyEntities);
                }
                return answerNewsStorage;
            }
        }
    }
}
