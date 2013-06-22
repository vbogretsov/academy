using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Configuration
{
    internal class DisciplineConfiguration : EntityTypeConfiguration<Discipline>
    {
        public DisciplineConfiguration()
        {
            ToTable("academy_Discipline");
            HasKey(x => x.Id);
            Property(x => x.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("DisciplineId");
            HasOptional(x => x.Parent)
                .WithMany()
                .HasForeignKey(x => x.ParentId);
            Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name");
            HasMany(x => x.Articles)
                .WithMany(x => x.Disciplines)
                .Map(x =>
                    {
                        x.ToTable("academy_Discipline_Article");
                        x.MapLeftKey("DisciplineId");
                        x.MapRightKey("ArticleId");
                    });
        }
    }
}
