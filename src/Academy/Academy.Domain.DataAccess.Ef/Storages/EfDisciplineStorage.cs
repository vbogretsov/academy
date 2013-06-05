using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return academyEntities.Disciplines.ToList();
        }
    }
}
