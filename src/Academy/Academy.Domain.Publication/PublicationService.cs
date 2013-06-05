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

        public PublicationService(
            UserStorage userStorage,
            ArticleStorage articleStorage)
        {
            this.articleStorage = articleStorage;
        }

        public void PublishArticle(Article article)
        {
            articleStorage.Add(article);
            // TODO: send notification
        }
    }
}
