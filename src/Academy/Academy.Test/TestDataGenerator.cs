using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.DataAccess.Ef;
using Academy.Domain.Objects;

namespace Academy.Test
{
    public class TestDataGenerator
    {
        private readonly AcademyEntities academyEntities;

        public TestDataGenerator(AcademyEntities academyEntities)
        {
            this.academyEntities = academyEntities;
        }

        public void GenerateDisciplines()
        {
            IEnumerable<Discipline> disciplines = GetTestDisciplines();
            foreach (Discipline discipline in disciplines)
            {
                academyEntities.Disciplines.Add(discipline);
            }
            academyEntities.SaveChanges();
        }

        private static IEnumerable<Discipline> GetTestDisciplines()
        {
            Discipline math = new Discipline
                {
                    Name = "Math"
                };
            Discipline algebra = new Discipline
                {
                    Name = "Algebra",
                    Parent = math
                };
            Discipline groupTheory = new Discipline
                {
                    Name = "Group theory",
                    Parent = algebra
                };
            Discipline finiteFields = new Discipline
                {
                    Name = "Finite fields",
                    Parent = algebra
                };
            Discipline geometry = new Discipline
                {
                    Name = "Geometry",
                    Parent = math
                };
            Discipline analyticGeometry = new Discipline
                {
                    Name = "Analytic geometry",
                    Parent = geometry
                };
            Discipline differentialGeometry = new Discipline
                {
                    Name = "Differential geometry",
                    Parent = geometry
                };

            yield return math;
            yield return algebra;
            yield return groupTheory;
            yield return finiteFields;
            yield return geometry;
            yield return analyticGeometry;
            yield return differentialGeometry;
        }
    }
}
