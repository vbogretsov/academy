using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Domain.Objects
{
    public interface IByDisciplinesNotifiable : IEntity
    {
        ICollection<Discipline> Disciplines
        {
            get;
        }
    }
}
