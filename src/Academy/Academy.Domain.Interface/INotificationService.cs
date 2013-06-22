using System;
using System.Collections.Generic;
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

        //TODO: add paging
        IEnumerable<ArticleNews> GetArticleNews(User user);

        //TODO: add paging
        IEnumerable<CommentNews> GetCommentNews(User user);

        //TODO: add paging
        IEnumerable<QuestionNews> GetQuestionNews(User user);

        //TODO: add paging
        IEnumerable<QuestionNews> GetAnswerNews(User user);
    }
}
