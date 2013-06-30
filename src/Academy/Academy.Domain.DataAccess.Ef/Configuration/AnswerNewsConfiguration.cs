using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Configuration
{
    internal class AnswerNewsConfiguration : EntityTypeConfiguration<AnswerNews>
    {
        public AnswerNewsConfiguration()
        {
            ToTable("academy_AnswerNews");
            HasKey(x => x.Id);
            Property(x => x.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Read)
                .IsRequired()
                .HasColumnName("Read");
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
