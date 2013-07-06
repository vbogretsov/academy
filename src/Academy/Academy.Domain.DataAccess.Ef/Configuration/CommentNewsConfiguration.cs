using System;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Configuration
{
    internal class CommentNewsConfiguration : NewsConfiguration<CommentNews>
    {
        public CommentNewsConfiguration()
            : base("academy_CommentNews", "NewsId")
        {
            HasRequired(x => x.User)
                .WithMany(x => x.CommentNewses)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);
            HasRequired(x => x.Comment)
                .WithMany(x => x.CommentNewses)
                .HasForeignKey(x => x.EntityId)
                .WillCascadeOnDelete(true);
        }
    }
}
