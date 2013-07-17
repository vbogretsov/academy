using System;
using System.Linq;
using Academy.Domain.Objects;
using Academy.Domain.Search;

namespace Academy.Domain.DataAccess.Ef.Search
{
    internal class ArticleFilter : Filter<Article>
    {
        public ArticleFilter(ArticleSearchCriteria criteria)
        {
            if (!String.IsNullOrEmpty(criteria.Title))
            {
                AddFilter(x => x.Where(a => a.Title.Contains(criteria.Title)));
            }
            if (!String.IsNullOrEmpty(criteria.Description))
            {
                AddFilter(x => x.Where(a => a.Title.Contains(criteria.Description)));
            }
            if (!String.IsNullOrEmpty(criteria.Author))
            {
                AddFilter(x =>
                    x.Where(
                        a => a.Authors.Any(u =>
                            u.Email.Contains(criteria.Author) ||
                            u.FirstName.Contains(criteria.Author) ||
                            u.LastName.Contains(criteria.Author))));
            }
            if (criteria.Disciplines != null)
            {
                AddFilter(x => x.Where(a => a.Disciplines.Any(
                    d => criteria.Disciplines.Contains(d.Id))));
            }
        }
    }
}
