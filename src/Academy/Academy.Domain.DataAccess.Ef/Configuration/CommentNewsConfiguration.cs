using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Configuration
{
    internal class CommentNewsConfiguration : EntityTypeConfiguration<CommentNews>
    {
        public CommentNewsConfiguration()
        {
            ToTable("academy_CommentNews");
            HasKey(x => x.Id);
            Property(x => x.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Read)
                .IsRequired()
                .HasColumnName("Read");
            HasRequired(x => x.User)
                .WithMany(x => x.CommentNewses)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);
            HasRequired(x => x.Comment)
                .WithMany(x => x.CommentNewses)
                .HasForeignKey(x => x.EntityId)
                .WillCascadeOnDelete(false);
        }
    }
}
