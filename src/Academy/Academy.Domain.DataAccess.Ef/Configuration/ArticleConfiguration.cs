using System;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Configuration
{
    internal class ArticleConfiguration : TitledPostConfiguration<Article>
    {
        public ArticleConfiguration()
            : base("academy_Article", "ArticleId")
        {
            Property(x => x.Source)
                .IsRequired()
                .HasColumnName("Source");
            HasMany(x => x.Authors)
                .WithMany(x => x.Articles)
                .Map(x =>
                    {
                        x.ToTable("academy_User_Article");
                        x.MapLeftKey("ArticleId");
                        x.MapRightKey("UserId");
                    });
        }
    }
}
