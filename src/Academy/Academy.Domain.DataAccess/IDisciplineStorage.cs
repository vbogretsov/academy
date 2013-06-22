using System;
using System.Collections.Generic;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess
{
    public interface IDisciplineStorage
    {
        IEnumerable<Discipline> Get();

        IEnumerable<Discipline> Get(IEnumerable<int> disciplinesIds);

        Discipline Get(int id);

        Discipline Get(string name);

        //IEnumerable<Discipline> Resolve(IEnumerable<int> disciplineIds);
    }
}
