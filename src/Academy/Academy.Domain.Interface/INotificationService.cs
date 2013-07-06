using System;
using System.Collections.Generic;
using Academy.Domain.DataAccess;
using Academy.Domain.Objects;

namespace Academy.Domain.Interface
{
    public interface INotificationService
    {
        void Subscribe(int userId, IEnumerable<int> disciplineIds);

        void NotifyAboutNewArticle(Article article);

        void NotifyAboutNewQuestion(Question question);

        void NotifyAboutNewComment(Comment comment);

        void NotifyAboutNewAnswer(Answer answer);

        IEnumerable<Discipline> GetDisciplines();

        IPageData<ArticleNews> GetArticleNews(int userId, int page, int size);

        IPageData<CommentNews> GetCommentNews(int userId, int page, int size);

        IPageData<QuestionNews> GetQuestionNews(int userId, int page, int size);

        IPageData<AnswerNews> GetAnswerNews(int userId, int page, int size);
    }
}
