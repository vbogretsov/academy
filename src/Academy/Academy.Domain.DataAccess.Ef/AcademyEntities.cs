using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.DataAccess.Ef.Configuration;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef
{
    public class AcademyEntities : DbContext
    {
        private static void AddConfigurations(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
            modelBuilder.Configurations.Add(new ArticleConfiguration());
            modelBuilder.Configurations.Add(new DisciplineConfiguration());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            AddConfigurations(modelBuilder);
        }

        public DbSet<User> Users
        {
            get;
            set;
        }

        public DbSet<Article> Articles
        {
            get;
            set;
        }

        public DbSet<Discipline> Disciplines
        {
            get;
            set;
        }

        public DbSet<Comment> Comments
        {
            get;
            set;
        }
    }
}
