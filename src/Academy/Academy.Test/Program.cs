using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            //InitializeDatabase();
        }

        private static void ValidateEncoding()
        {
            const string articlesFolder = @"d:\dev\academy\test\articles\";
            foreach (var file in Directory.GetFiles(articlesFolder))
            {
                Console.WriteLine(File.ReadAllText(file, Encoding.GetEncoding(1251)));
            }
        }

        private static void ValidateDates()
        {
            const string usersFolder = @"d:\dev\academy\test\users\";
            foreach (var testUser in Directory.GetFiles(usersFolder))
            {
                string userInfo = File.ReadAllText(testUser);
                string date = Regex.Match(userInfo, "(?<=date:).*").Value.TrimEnd('\r');
                DateTime dateTime;
                if (!DateTime.TryParse(date, out dateTime))
                {
                    Console.WriteLine(testUser);
                }
            }
        }

        private static void UpdateTestPasswords()
        {
            const string usersFolder = @"d:\dev\academy\test\users\";
            foreach (var testUser in Directory.GetFiles(usersFolder))
            {
                string userInfo = File.ReadAllText(testUser);
                File.WriteAllText(testUser, userInfo.Replace("some password", "110011"));
            }
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
                //academyEntities.Database.ExecuteSqlCommand("ALTER DATABASE Academy COLLATE Cyrillic_General_CI_AS");
                Console.WriteLine("Database created");
                //Console.WriteLine("Generating test data...");
                //TestDataGenerator generator = new TestDataGenerator(academyEntities);
                //generator.GenerateDisciplines();
                //Console.WriteLine("Generating test data compleeted");
            }
        }
    }
}
