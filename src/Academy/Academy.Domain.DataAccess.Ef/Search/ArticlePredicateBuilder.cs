using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;
using Academy.Domain.Search;

namespace Academy.Domain.DataAccess.Ef.Search
{
    internal static class ArticlePredicateBuilder
    {
        public static IEnumerable<Predicate<Article>> Build(ArticleSearchCriteria criteria)
        {
            if (criteria.Title != null)
            {
                yield return article => article.Title.Contains(criteria.Title);
            }
            if (criteria.Description != null)
            {
                yield return article => article.Description.Contains(criteria.Description);
            }
            if (criteria.Author != null)
            {
                yield return article => article.Authors.Any(author =>
                    author.Email.Contains(criteria.Author) ||
                    author.FirstName.Contains(criteria.Author) ||
                    author.LastName.Contains(criteria.Author));
            }
            if (criteria.Disciplines != null)
            {
                yield return article => article.Disciplines.Any(
                    discipline => criteria.Disciplines.Contains(discipline.Id));
            }
            yield return article => true;
        }
    }
}
