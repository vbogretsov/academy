using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Configuration
{
    internal class ArticleNewsConfiguration : EntityTypeConfiguration<ArticleNews>
    {
        public ArticleNewsConfiguration()
        {
            ToTable("academy_ArticleNews");
            HasKey(x => x.ArticleNewsId);
            Property(x => x.ArticleNewsId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Read)
                .IsRequired()
                .HasColumnName("Read");
            HasRequired(x => x.User)
                .WithMany(x => x.ArticleNewses)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);
            HasRequired(x => x.Article)
                .WithMany(x => x.ArticleNewses)
                .HasForeignKey(x => x.ArticleId)
                .WillCascadeOnDelete(false);
        }
    }
}
