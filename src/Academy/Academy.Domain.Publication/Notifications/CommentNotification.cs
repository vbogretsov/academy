using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.DataAccess;
using Academy.Domain.Objects;

namespace Academy.Domain.Services.Notifications
{
    internal class CommentNotification
    {
        private readonly Comment comment;

        private readonly IDataContext context;

        public CommentNotification(
            Comment comment,
            IDataContext context)
        {
            this.comment = comment;
            this.context = context;
        }

        public void Send()
        {
            var article = context.ArticleStorage.Get(comment.ArticleId);
            foreach (var author in article.Authors.ToList()) // dependency problems
            {
                CreateNews(author.Id, comment.Id);
            }
        }

        private void CreateNews(int userId, int commentId)
        {
            var news = new CommentNews();
            news.UserId = userId;
            news.EntityId = commentId;
            context.CommentNewsStorage.Add(news);
        }
    }
}
