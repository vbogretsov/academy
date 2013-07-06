using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Academy.Domain.DataAccess;
using Academy.Domain.DataAccess.Ef;
using Academy.Domain.Interface;
using Academy.Domain.Interface.Facade;
using Academy.Domain.Objects;
using Academy.Domain.Services;
using Academy.Security;
using Academy.Security.Simple;

namespace Academy.Test.DataGenerating
{
    public class TestDataGenerator
    {
        private readonly string testDataFolder;
        private readonly IAcademyService service;

        private readonly RoleManager roleManager;

        public TestDataGenerator(string testDataFolder, IAcademyService service)
        {
            this.testDataFolder = testDataFolder;
            this.service = service;
            roleManager = new WebMatrixRoleManager();
        }

        public void GenerateTestData()
        {
            GenerateDisciplines();
            GenerateUsers();
            GenerateArticles();
        }

        private void GenerateDisciplines()
        {
            using (var entities = new AcademyEntities())
            {
                var disciplinesFolder = Path.Combine(testDataFolder, "disciplines");
                var directories = Directory.GetDirectories(disciplinesFolder);
                foreach (var directory in directories)
                {
                    CreateDiscipline(entities, directory, null);
                }
            }
        }

        private void GenerateUsers()
        {
            var usersFolder = Path.Combine(testDataFolder, "users");
            var users = Directory.GetFiles(usersFolder);
            foreach (var userFile in users)
            {
                CreateUser(userFile);
            }
        }

        private void CreateUser(string userFile)
        {
            string userInfo = File.ReadAllText(userFile);
            var user = new User();
            user.Email = GetInfoField(userInfo, "email");
            user.FirstName = GetInfoField(userInfo, "first_name");
            user.LastName = GetInfoField(userInfo, "last_name");
            user.University = GetInfoField(userInfo, "university");
            user.BirthDate = DateTime.Parse(GetInfoField(userInfo, "date"));
            string passwrod = GetInfoField(userInfo, "password");
            service.Register(user, passwrod);
            string[] disciplines = GetInfoField(userInfo, "disciplines").Split(',');
            service.Subscribe(user.Id, GetDisciplines(disciplines));
            if (!Regex.IsMatch(userFile, "\\d"))
            {
                roleManager.AddUserToRole(user.Email, "Admin");
            }
        }

        private void GenerateArticles()
        {
            var articlesFolder = Path.Combine(testDataFolder, "articles");
            var articles = Directory.GetFiles(articlesFolder);
            using (StreamWriter writer = new StreamWriter("d:\\articles.log", true))
            {
                writer.AutoFlush = true;
                writer.WriteLine("--------------------------------------------");
                foreach (var articleFile in articles)
                {
                    try
                    {
                        writer.WriteLine("{0}: Processing: {1}", DateTime.Now, articleFile);
                        CreateArticle(articleFile, writer);
                        writer.WriteLine("{0}: Compleeted: {1}", DateTime.Now, articleFile);
                    }
                    catch (Exception exception)
                    {
                        writer.WriteLine(exception);
                    }
                }
            }
        }

        private void CreateArticle(string articleFile, StreamWriter writer)
        {
            string articleInfo = File.ReadAllText(articleFile, Encoding.GetEncoding(1251));
            var article = new Article();
            article.Title = GetInfoField(articleInfo, "title");
            writer.WriteLine("Title: {0}", article.Title);
            article.Text = GetInfoField(articleInfo, "description");
            article.Source = GetInfoField(articleInfo, "source");
            var authors = GetInfoField(articleInfo, "users").Split(',');
            article.Authors = new List<User>();
            foreach (var author in authors)
            {
                article.Authors.Add(new User { Email = author.TrimEnd('\r') });
            }
            var disciplineIds = GetDisciplines(GetInfoField(articleInfo, "disciplines").Split(','));
            article.Disciplines = new List<Discipline>();
            foreach (var disciplineId in disciplineIds)
            {
                article.Disciplines.Add(new Discipline() { Id = disciplineId });
            }
            using (var dataContext = new EfDataContext())
            {
                var publicationService = new PublicationService(dataContext);
                publicationService.Publish(article);
                var notificationService = new NotificationService(dataContext);
                notificationService.NotifyAboutNewArticle(article);
            }
            AddComments(article, articleInfo);
        }

        private void AddComments(IEntity article, string articleInfo)
        {
            var comments = Regex.Matches(articleInfo, "(?<=text:).*");
            var authors = Regex.Matches(articleInfo, "(?<=author:).*");
            for (int i = 0; i < comments.Count; i++)
            {
                var comment = new Comment();
                comment.ArticleId = article.Id;
                comment.Text = comments[i].Value;
                using (var academyEntities = new AcademyEntities())
                {
                    var email = authors[i].Value.TrimEnd('\r');
                    comment.UserId = academyEntities.Users.Single(
                        x => x.Email.Equals(email)).Id;
                }
                using (var context = new EfDataContext())
                {
                    var publicationService = new PublicationService(context);
                    publicationService.Comment(comment);
                    var notificationService = new NotificationService(context);
                    notificationService.NotifyAboutNewComment(comment);
                }
            }
        }

        private static void CreateDiscipline(
            AcademyEntities entities,
            string name,
            Discipline parent)
        {
            var discipline = CreateDiscipline(name, parent);
            entities.Disciplines.Add(discipline);
            entities.SaveChanges();
            foreach (var child in Directory.GetDirectories(name))
            {
                CreateDiscipline(entities, child, discipline);
            }
        }

        private static IEnumerable<int> GetDisciplines(IEnumerable<string> names)
        {
            var disciplineNames = new HashSet<string>(names);
            using (var entities = new AcademyEntities())
            {
                return entities.Disciplines.Where(
                    x => disciplineNames.Contains(x.Name)).Select(x => x.Id).ToList();
            }
        }

        private static Discipline CreateDiscipline(string name, Discipline parent)
        {
            var discipline = new Discipline();
            discipline.Parent = parent;
            discipline.Name = new DirectoryInfo(name).Name;
            return discipline;
        }

        private static string GetInfoField(string userInfo, string fieldName)
        {
            return Regex.Match(
                userInfo,
                String.Format("(?<={0}:).*", fieldName)).Value.TrimEnd('\r');
        }
    }
}