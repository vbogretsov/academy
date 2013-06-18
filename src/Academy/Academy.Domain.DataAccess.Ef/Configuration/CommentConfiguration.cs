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
            HasKey(x => x.CommentId);
            Property(x => x.CommentId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("CommentId");
            Property(x => x.Text)
                .IsRequired()
                .HasColumnName("Text");
            //Property(x => x.Rating) // not supported in .net 4.0
            //    .IsRequired()
            //    .HasColumnName("Rating");
            Property(x => x.PostedDate)
                .IsRequired()
                .HasColumnName("CreationDate");
            HasRequired(x => x.User)
                .WithMany(x => x.Comments)
                .Map(x => x.MapKey("UserId"));
            HasRequired(x => x.Article)
                .WithMany(x => x.Comments)
                .Map(x => x.MapKey("ArticleId"));
        }
    }
}
