using System;
using System.Collections.Generic;
using System.Linq;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal class EfDisciplineStorage : IDisciplineStorage
    {
        private readonly AcademyEntities academyEntities;

        public EfDisciplineStorage(AcademyEntities academyEntities)
        {
            this.academyEntities = academyEntities;
        }

        public IEnumerable<Discipline> GetDisciplines()
        {
            return academyEntities.Disciplines;
        }

        public Discipline Get(int id)
        {
            return academyEntities.Disciplines.SingleOrDefault(
                x => x.DisciplineId == id);
        }

        public Discipline Get(string name)
        {
            return academyEntities.Disciplines.SingleOrDefault(
                x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        }

        public IEnumerable<Discipline> Resolve(IEnumerable<int> disciplineIds)
        {
            return disciplineIds.Select(Get).Where(x => x != null);
        }
    }
}
