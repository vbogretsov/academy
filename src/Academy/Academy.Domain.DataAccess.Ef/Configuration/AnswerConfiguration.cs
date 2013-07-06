using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Configuration
{
    internal class AnswerConfiguration : PostConfiguration<Answer>
    {
        public AnswerConfiguration()
            : base("academy_Answer", "AnswerId")
        {
            HasRequired(x => x.User)
                .WithMany(x => x.Answers)
                .HasForeignKey(x => x.UserId);
        }
    }
}
