using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal class EfArticleStorage : ArticleStorage
    {
        private readonly AcademyEntities academyEntities;

        public override Article Get(int articleId)
        {
            return academyEntities.Articles.SingleOrDefault(x => x.ArticleId == articleId);
        }

        public EfArticleStorage(AcademyEntities academyEntities)
        {
            this.academyEntities = academyEntities;
        }

        public override void Add(Article article)
        {
            academyEntities.Articles.Add(article);
            academyEntities.SaveChanges();
        }

        public override void Update(Article article)
        {
            //academyEntities.Articles.Attach(article);
            academyEntities.SaveChanges();
        }

        public override void Remove(Article article)
        {
            academyEntities.Articles.Remove(article);
            academyEntities.SaveChanges();
        }

        public override void Resolve(Article article)
        {
            
        }
    }
}
