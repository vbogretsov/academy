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
        private readonly ArticleStorage articleStorage;

        private readonly DisciplineStorage disciplineStorage;

        public PublicationService(
            ArticleStorage articleStorage,
            DisciplineStorage disciplineStorage)
        {
            this.articleStorage = articleStorage;
        }

        public void PublishArticle(Article article, IEnumerable<int> disciplineIds)
        {
            if (disciplineIds != null)
            {
                foreach (int disciplineId in disciplineIds)
                {
                    var discipline = disciplineStorage.Get(disciplineId);
                    if (discipline != null)
                    {
                        article.Disciplines.Add(discipline);
                    }
                }
            }
            articleStorage.Add(article);
        }
    }
}
