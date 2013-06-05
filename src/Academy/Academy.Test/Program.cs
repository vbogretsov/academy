using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.DataAccess.Ef;

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
