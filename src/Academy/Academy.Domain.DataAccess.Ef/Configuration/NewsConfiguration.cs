using System;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Configuration
{
    internal abstract class NewsConfiguration<T> : EntityConfiguration<T> where T: News
    {
        protected NewsConfiguration(string tableName, string idName)
            : base(tableName, idName)
        {
            Property(x => x.Read)
                .IsRequired()
                .HasColumnName("Read");
        }
    }
}
