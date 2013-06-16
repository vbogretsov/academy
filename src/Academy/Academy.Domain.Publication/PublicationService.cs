using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.DataAccess;
using Academy.Domain.Objects;

namespace Academy.Domain.Services
{
    public class PublicationService
    {
        private readonly UserStorage userStorage;

        private readonly ArticleStorage articleStorage;

        private readonly DisciplineStorage disciplineStorage;

        public PublicationService(
            UserStorage userStorage,
            ArticleStorage articleStorage,
            DisciplineStorage disciplineStorage)
        {
            this.userStorage = userStorage;
            this.articleStorage = articleStorage;
            this.disciplineStorage = disciplineStorage;
        }

        public void PublishArticle(User author, Article article)
        {
            try
            {
                ResolveAuthors(author, article);
                ResolveDisciplines(article);
                articleStorage.Add(article);
            }
            catch (Exception e)
            {
                var s = e.Message;
            }

        }

        private void ResolveAuthors(User author, Article article)
        {
            if (article.Authors != null)
            {
                var authors = article.Authors.ToList();
                article.Authors.Clear();
                article.Authors.Add(author);
                foreach (var resolvingAuthor in authors)
                {
                    var resolverAuthor = userStorage.Get(resolvingAuthor.Email);
                    if (resolverAuthor != null)
                    {
                        article.Authors.Add(resolverAuthor);
                    }
                }
            }
            else
            {
                article.Authors = new List<User> {author};
            }
        }

        private void ResolveDisciplines(Article article)
        {
            if (article.Disciplines != null)
            {
                var disciplines = article.Disciplines.ToList();
                article.Disciplines.Clear();
                foreach (var resolvingDiscipline in disciplines)
                {
                    var resolvedDiscipline = disciplineStorage.Get(
                        resolvingDiscipline.DisciplineId);
                    if (resolvedDiscipline != null)
                    {
                        article.Disciplines.Add(resolvedDiscipline);
                    }
                }
            }
        }
    }
}
