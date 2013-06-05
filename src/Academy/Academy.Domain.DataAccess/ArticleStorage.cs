using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess
{
    public abstract class ArticleStorage
    {
        public abstract void Add(Article article);

        public abstract void Update(Article article);

        public abstract void Remove(Article article);
    }
}
