using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Configuration
{
    internal class ArticleConfiguration : EntityTypeConfiguration<Article>
    {
        public ArticleConfiguration()
        {
            ToTable("academy_Article");
            HasKey(x => x.ArticleId);
            Property(x => x.ArticleId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("ArticleId");
            Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description");
            Property(x => x.Source)
                .IsRequired()
                .HasColumnName("Source");
            HasMany(x => x.Authors)
                .WithMany(x => x.Articles)
                .Map(x =>
                    {
                        x.ToTable("academy_User_Article");
                        x.MapLeftKey("UserId");
                        x.MapRightKey("ArticleId");
                    });
        }
    }
}
