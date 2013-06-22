using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.DataAccess;
using Academy.Domain.DataAccess.Ef;
using Academy.Domain.Objects;
using Academy.Utils;
using Academy.Utils.Trees;

namespace Academy.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                
                Start(args);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            Console.ReadLine();
        }

        private static void Start(string[] args)
        {
            CreateDatabase();
            //TestChildDisciplines();
        }

        private static void TestChildDisciplines()
        {
            using (IDataContext context = new EfDataContext())
            {
                var storage = context.DisciplineStorage;
                var disciplines = SelectDisciplines(storage);
                var allChildren = storage.Get(disciplines.Select(x => x.Id));
                foreach (var discipline in allChildren)
                {
                    Console.WriteLine(discipline.Name);
                }
            }
        }

        private static IEnumerable<Discipline> SelectDisciplines(
            IDisciplineStorage storage)
        {
            yield return storage.Get(2);
            yield return storage.Get(5);
            yield return storage.Get(3);
            yield return storage.Get(8);
            yield return storage.Get(4);
            yield return storage.Get(11);
            yield return storage.Get(14);
        }

        private static void CreateDatabase()
        {
            using (AcademyEntities academyEntities = new AcademyEntities())
            {
                Console.WriteLine("Creating database");
                if (academyEntities.Database.Exists())
                {
                    academyEntities.Database.Delete();
                }
                academyEntities.Database.Create();
                Console.WriteLine("Database created");
                Console.WriteLine("GEnerating test data...");
                TestDataGenerator generator = new TestDataGenerator(academyEntities);
                generator.GenerateDisciplines();
                Console.WriteLine("Generating test data compleeted");
            }
        }
    }
}
