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
            modelBuilder.Configurations.Add(new NoteConfiguration());
            modelBuilder.Configurations.Add(new QuestionConfiguration());
            modelBuilder.Configurations.Add(new AnswerConfiguration());
            modelBuilder.Configurations.Add(new ArticleNewsConfiguration());
            modelBuilder.Configurations.Add(new CommentNewsConfiguration());
            modelBuilder.Configurations.Add(new AnswerNewsConfiguration());
            modelBuilder.Configurations.Add(new QuestionNewsConfiguration());
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

        public DbSet<Note> Notes
        {
            get;
            set;
        }

        public DbSet<Question> Questions
        {
            get;
            set;
        }

        public DbSet<Answer> Answers
        {
            get;
            set;
        }

        public DbSet<ArticleNews> ArticleNewses
        {
            get;
            set;
        }

        public DbSet<CommentNews> CommentNewses
        {
            get;
            set;
        }

        public DbSet<QuestionNews> QuestionNewses
        {
            get;
            set;
        }

        public DbSet<AnswerNews> AnswerNewses
        {
            get;
            set;
        }
    }
}
