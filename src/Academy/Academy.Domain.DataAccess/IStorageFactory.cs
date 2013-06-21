using System;

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
    }
}
