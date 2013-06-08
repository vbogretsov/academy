using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess
{
    public abstract class DisciplineStorage
    {
        public abstract IEnumerable<Discipline> GetDisciplines();

        public abstract Discipline Get(int id);

        public abstract Discipline Get(string name);
    }
}
