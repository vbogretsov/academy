using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess
{
    public abstract class CommentStorage
    {
        public abstract void Add(Comment comment);

        public abstract void Remove(Comment comment);
    }
}
