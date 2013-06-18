using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Configuration
{
    internal class AnswerConfiguration : EntityTypeConfiguration<Answer>
    {
        public AnswerConfiguration()
        {
            ToTable("academy_Answer");
            HasKey(x => x.AnswerId);
            Property(x => x.AnswerId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("AnswerId");
            Property(x => x.Text)
                .IsRequired()
                .HasColumnName("Text");
            Property(x => x.PostedDate)
                .IsRequired()
                .HasColumnName("PostedDate");
            //Property(x => x.UserId)
            //    .IsRequired()
            //    .HasColumnName("UserId");
            HasRequired(x => x.User)
                .WithMany(x => x.Answers)
                .HasForeignKey(x => x.UserId);
            //Property(x => x.QuestionId)
            //    .IsRequired()
            //    .HasColumnName("QuestionId");
            HasRequired(x => x.Question)
                .WithMany(x => x.Answers)
                .Map(x => x.MapKey("QuestionId"));
        }
    }
}
