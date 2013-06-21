using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess
{
    public interface ICommentStorage
    {
        void Add(Comment comment);

        void Remove(Comment comment);
    }
}
