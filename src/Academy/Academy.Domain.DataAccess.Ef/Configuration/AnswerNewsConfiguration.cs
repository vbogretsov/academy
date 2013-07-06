using System;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Configuration
{
    internal class AnswerNewsConfiguration : NewsConfiguration<AnswerNews>
    {
        public AnswerNewsConfiguration()
            : base("academy_AnswerNews", "NewsId")
        {
            HasRequired(x => x.User)
                .WithMany(x => x.AnswerNewses)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);
            HasRequired(x => x.Answer)
                .WithMany(x => x.AnswerNewses)
                .HasForeignKey(x => x.EntityId)
                .WillCascadeOnDelete(true);
        }
    }
}
