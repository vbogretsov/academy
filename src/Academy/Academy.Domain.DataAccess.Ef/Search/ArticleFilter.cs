using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;
using Academy.Domain.Search;

namespace Academy.Domain.DataAccess.Ef.Search
{
    internal class ArticleFilter
    {
        private delegate IEnumerable<Article> Filter(IEnumerable<Article> articles);

        private readonly ICollection<Filter> filters;

        public ArticleFilter(ArticleSearchCriteria criteria)
        {
            filters = new List<Filter>();
            if (!String.IsNullOrEmpty(criteria.Title))
            {
                filters.Add(x => x.Where(a => a.Title.Contains(criteria.Title)));
            }
            if (!String.IsNullOrEmpty(criteria.Description))
            {
                filters.Add(x => x.Where(a => a.Title.Contains(criteria.Description)));
            }
            if (!String.IsNullOrEmpty(criteria.Author))
            {
                // todo: add author filter.
            }
            if (criteria.Disciplines != null)
            {
                // todo: add disciplines filter.
            }
        }

        public IEnumerable<Article> Select(IEnumerable<Article> articles)
        {
            var result = articles;
            foreach (var filter in filters)
            {
                result = filter(result);
            }
            return result;
        }
    }
}
