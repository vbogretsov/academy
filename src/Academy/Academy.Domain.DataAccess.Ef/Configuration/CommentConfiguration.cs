using System;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Configuration
{
    internal class CommentConfiguration : PostConfiguration<Comment>
    {
        public CommentConfiguration()
            : base("academy_Comment", "CommentId")
        {
            HasRequired(x => x.User)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.UserId);
            HasRequired(x => x.Article)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.ArticleId)
                .WillCascadeOnDelete(true);
        }
    }
}
