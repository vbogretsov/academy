using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal class EfArticleStorage : IArticleStorage
    {
        private readonly AcademyEntities academyEntities;

        public EfArticleStorage(AcademyEntities academyEntities)
        {
            this.academyEntities = academyEntities;
        }

        public Article Get(int articleId)
        {
            return academyEntities.Articles.SingleOrDefault(x => x.ArticleId == articleId);
        }

        public void Add(Article article)
        {
            academyEntities.Articles.Add(article);
            academyEntities.SaveChanges();
        }

        public void Update(Article article)
        {
            //academyEntities.Articles.Attach(article);
            academyEntities.SaveChanges();
        }

        public void Remove(Article article)
        {
            academyEntities.Articles.Remove(article);
            academyEntities.SaveChanges();
        }

        public void Resolve(Article article)
        {
            
        }
    }
}
