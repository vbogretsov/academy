using System;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Configuration
{
    internal class QuestionNewsConfiguration : NewsConfiguration<QuestionNews>
    {
        public QuestionNewsConfiguration()
            : base("academy_QuestionNews", "NewsId")
        {
            HasRequired(x => x.User)
                .WithMany(x => x.QuestionNewses)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);
            HasRequired(x => x.Question)
                .WithMany(x => x.QuestionNewses)
                .HasForeignKey(x => x.EntityId)
                .WillCascadeOnDelete(true);
        }
    }
}
