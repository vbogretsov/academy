using System;
using System.Collections.Generic;
using System.Linq;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal class EfDisciplineStorage : DisciplineStorage
    {
        private readonly AcademyEntities academyEntities;

        public EfDisciplineStorage(AcademyEntities academyEntities)
        {
            this.academyEntities = academyEntities;
        }

        public override IEnumerable<Discipline> GetDisciplines()
        {
            return academyEntities.Disciplines;
        }

        public override Discipline Get(int id)
        {
            return academyEntities.Disciplines.SingleOrDefault(
                x => x.DisciplineId == id);
        }

        public override Discipline Get(string name)
        {
            return academyEntities.Disciplines.SingleOrDefault(
                x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        }

        public override IEnumerable<Discipline> Resolve(IEnumerable<int> disciplineIds)
        {
            return disciplineIds.Select(Get).Where(x => x != null);
        }
    }
}
