using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Configuration
{
    internal abstract class EntityConfiguration<T> : EntityTypeConfiguration<T> where T : Entity
    {
        protected EntityConfiguration(string tableName, string idName)
        {
            ToTable(tableName);
            HasKey(x => x.Id);
            Property(x => x.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName(idName);
        }
    }
}
