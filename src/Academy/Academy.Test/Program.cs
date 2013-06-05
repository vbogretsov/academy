﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            using (AcademyEntities academyEntities = new AcademyEntities())
            {
                TreeLoader<Discipline, int> loader = new TreeLoader<Discipline, int>(
                    x => x.DisciplineId,
                    x => x.Parent != null ? x.Parent.DisciplineId : 0);

                Node<Discipline> root = loader.Load(academyEntities.Users.Single(x => x.UserId == 1).Disciplines.ToList());
                File.WriteAllText("d:\\tree.html", HtmlTree.Tree(root));

                //Console.WriteLine("Creating database");
                //if (academyEntities.Database.Exists())
                //{
                //    academyEntities.Database.Delete();
                //}
                //academyEntities.Database.Create();
                //Console.WriteLine("Database created");
                //Console.WriteLine("GEnerating test data...");
                //TestDataGenerator generator = new TestDataGenerator(academyEntities);
                //generator.GenerateDisciplines();
                //Console.WriteLine("Generating test data compleeted");

                //var user = academyEntities.Users.Single(x => x.UserId == 1);

                //foreach (Discipline discipline in academyEntities.Disciplines.ToList())
                //{
                //    user.Disciplines.Add(discipline);
                //}
                //academyEntities.SaveChanges();
            }
        }
    }
}
