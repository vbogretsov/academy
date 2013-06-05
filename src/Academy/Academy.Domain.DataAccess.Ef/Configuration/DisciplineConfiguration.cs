﻿using System;
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
            HasKey(x => x.DisciplineId);
            Property(x => x.DisciplineId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("DisciplineId");
            HasOptional(x => x.Parent)
                .WithMany()
                .Map(x => x.MapKey("ParentId"));
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
