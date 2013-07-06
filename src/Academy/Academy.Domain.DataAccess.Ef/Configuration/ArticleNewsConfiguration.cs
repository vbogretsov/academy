using System;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Configuration
{
    internal class ArticleNewsConfiguration : NewsConfiguration<ArticleNews>
    {
        public ArticleNewsConfiguration()
            : base("academy_ArticleNews", "NewsId")
        {
            HasRequired(x => x.User)
                .WithMany(x => x.ArticleNewses)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);
            HasRequired(x => x.Article)
                .WithMany(x => x.ArticleNewses)
                .HasForeignKey(x => x.EntityId)
                .WillCascadeOnDelete(true);
        }
    }
}
