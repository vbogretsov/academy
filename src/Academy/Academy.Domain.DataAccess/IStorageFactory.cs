using System;

namespace Academy.Domain.DataAccess
{
    public interface IStorageFactory
    {
        UserStorage CreateUserStorage();

        CommentStorage CreateCommentStorage();

        ArticleStorage CreateArticleStorage();

        DisciplineStorage CreateDisciplineStorage();
    }
}
