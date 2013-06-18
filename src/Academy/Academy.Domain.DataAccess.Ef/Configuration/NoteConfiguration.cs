using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Configuration
{
    internal class NoteConfiguration : EntityTypeConfiguration<Note>
    {
        public NoteConfiguration()
        {
            ToTable("academy_Note");
            HasKey(x => x.NoteId);
            Property(x => x.NoteId)
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
            Property(x => x.UserId)
                .IsRequired()
                .HasColumnName("UserId");
            HasRequired(x => x.User)
                .WithMany(x => x.Notes)
                .Map(x => x.MapKey("UserId"));
        }
    }
}
