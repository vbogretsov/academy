using System;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess
{
    public interface IStorageFactory
    {
        IUserStorage CreateUserStorage();

        ICommentStorage CreateCommentStorage();

        IArticleStorage CreateArticleStorage();

        IDisciplineStorage CreateDisciplineStorage();

        IQuestionStorage CreateQuestionStorage();

        IAnswerStorage CreateAnswerStorage();

        INoteStorage CreateNoteStorage();

        INewsStorage<ArticleNews> CreateArticleNewsStorage();

        INewsStorage<QuestionNews> CreateQuestionNewsStorage();

        INewsStorage<CommentNews> CreateCommentNewsStorage();

        INewsStorage<AnswerNews> CreateAnswerNewsStorage();
    }
}
