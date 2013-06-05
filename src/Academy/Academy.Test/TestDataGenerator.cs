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
            ClearDisciplines(academyEntities);
            IEnumerable<Discipline> disciplines = GetTestDisciplines();
            foreach (Discipline discipline in disciplines)
            {
                academyEntities.Disciplines.Add(discipline);
            }
            academyEntities.SaveChanges();
        }

        private static void ClearDisciplines(AcademyEntities academyEntities)
        {
            IEnumerable<Discipline> disciplines = academyEntities.Disciplines.ToList();
            foreach (var discipline in disciplines)
            {
                academyEntities.Disciplines.Remove(discipline);
            }
            academyEntities.SaveChanges();
        }

        private static IEnumerable<Discipline> GetTestDisciplines()
        {
            Discipline math = new Discipline() { Name = "Math" };
            Discipline algebra = new Discipline() { Name = "Algebra", Parent = math };
            Discipline groupTheory = new Discipline() { Name = "Group Theory", Parent = algebra };
            Discipline combinatorialGroupTheory = new Discipline() { Name = "Combinatorial Group Theory", Parent = groupTheory };
            Discipline finiteFieldsTheory = new Discipline() { Name = "Finite Fields", Parent = algebra };
            Discipline geometry = new Discipline() { Name = "Geometry", Parent = math };
            Discipline analynicGeometry = new Discipline() { Name = "Analytic Geometry", Parent = geometry };
            Discipline differentialGeometry = new Discipline() { Name = "Differential Geometry", Parent = geometry };
            Discipline topology = new Discipline() { Name = "Topology", Parent = math };
            Discipline differentialTopology = new Discipline() { Name = "Differential Topology", Parent = topology };
            Discipline combinatorialTopology = new Discipline() { Name = "Combinatorial Topology", Parent = topology };
            Discipline generalTopology = new Discipline() { Name = "General Topology", Parent = topology };
            Discipline physic = new Discipline() { Name = "Physic" };
            Discipline mechanics = new Discipline() { Name = "mechanics", Parent = physic };
            Discipline thermodynamics = new Discipline() { Name = "Thermodynamics", Parent = physic };

            yield return math;
            yield return algebra;
            yield return groupTheory;
            yield return combinatorialGroupTheory;
            yield return finiteFieldsTheory;
            yield return geometry;
            yield return differentialGeometry;
            yield return analynicGeometry;
            yield return topology;
            yield return differentialTopology;
            yield return combinatorialTopology;
            yield return generalTopology;
            yield return physic;
            yield return mechanics;
            yield return thermodynamics;
        }
    }
}
