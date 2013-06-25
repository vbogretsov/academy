using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Configuration
{
    internal class NoteConfiguration : EntityTypeConfiguration<Note>
    {
        public NoteConfiguration()
        {
            ToTable("academy_Note");
            HasKey(x => x.Id);
            Property(x => x.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("NoteId");
            Property(x => x.PostedDate)
                .IsRequired()
                .HasColumnName("PostedDate");
            Property(x => x.Text)
                .IsRequired()
                .HasColumnName("Text");
            Property(x => x.Title)
                .IsRequired()
                .HasColumnName("Title");
            HasRequired(x => x.User)
                .WithMany(x => x.Notes)
                .HasForeignKey(x => x.UserId);
        }
    }
}
