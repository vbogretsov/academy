using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Configuration
{
    internal class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration()
        {
            ToTable("academy_Question");
            HasKey(x => x.QuestionId);
            Property(x => x.QuestionId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("QuestionId");
            Property(x => x.Title)
                .IsRequired()
                .HasColumnName("Title");
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
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);
            
            //.Map(x => x.MapKey("UserId"));
            HasMany(x => x.Disciplines)
                .WithMany(x => x.Questions)
                .Map(x =>
                    {
                        x.ToTable("academy_Discipline_Question");
                        x.MapLeftKey("QuestionId");
                        x.MapRightKey("DisciplineId");
                    });
        }
    }
}
