using System;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Configuration
{
    internal abstract class PostConfiguration<T> : EntityConfiguration<T> where T : Post
    {
        protected PostConfiguration(string tableName, string idName)
            :base(tableName, idName)
        {
            Property(x => x.Text)
                .IsRequired()
                .HasColumnName("Text");
            Property(x => x.PostedDate)
                .IsRequired()
                .HasColumnName("PostedDate");
        }
    }
}
