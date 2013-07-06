using System;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Configuration
{
    internal abstract class TitledPostConfiguration<T> : PostConfiguration<T> where T : TitledPost
    {
        protected TitledPostConfiguration(string tableName, string idName)
            : base(tableName, idName)
        {
            Property(x => x.Title)
                .IsRequired()
                .HasColumnName("Title");
        }
    }
}
