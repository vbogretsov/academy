using System;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess
{
    public interface IDataContext : IDisposable
    {
        IDataContext Fork();

        IUserStorage UserStorage
        {
            get;
        }

        IDisciplineStorage DisciplineStorage
        {
            get;
        }

        IArticleStorage ArticleStorage
        {
            get;
        }

        ICommentStorage CommentStorage
        {
            get;
        }

        IQuestionStorage QuestionStorage
        {
            get;
        }

        IAnswerStorage AnswerStorage
        {
            get;
        }

        INewsStorage<ArticleNews> ArticleNewsStorage
        {
            get;
        }

        INewsStorage<CommentNews> CommentNewsStorage
        {
            get;
        }

        INewsStorage<QuestionNews> QuestionNewsStorage
        {
            get;
        }

        INewsStorage<AnswerNews> AnswerNewsStorage
        {
            get;
        }
    }
}
