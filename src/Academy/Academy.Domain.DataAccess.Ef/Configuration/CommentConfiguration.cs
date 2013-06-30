using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Configuration
{
    internal class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            ToTable("academy_Comment");
            HasKey(x => x.Id);
            Property(x => x.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("CommentId");
            Property(x => x.Text)
                .IsRequired()
                .HasColumnName("Text");
            Property(x => x.PostedDate)
                .IsRequired()
                .HasColumnName("PostedDate");
            HasRequired(x => x.User)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.UserId);
            HasRequired(x => x.Article)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.ArticleId)
                .WillCascadeOnDelete(true);
        }
    }
}
