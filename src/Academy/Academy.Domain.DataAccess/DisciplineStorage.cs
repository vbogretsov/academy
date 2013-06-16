using System;
using System.Collections.Generic;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess
{
    public abstract class DisciplineStorage
    {
        public abstract IEnumerable<Discipline> GetDisciplines();

        public abstract Discipline Get(int id);

        public abstract Discipline Get(string name);

        public abstract IEnumerable<Discipline> Resolve(IEnumerable<int> disciplineIds);
    }
}
