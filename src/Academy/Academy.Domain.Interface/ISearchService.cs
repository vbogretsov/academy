using System;
using Academy.Domain.Objects;
using Academy.Domain.Search;

namespace Academy.Domain.Interface
{
    public interface ISearchService
    {
        SearchResult<Article> FindArticles(ArticleSearchCriteria criteria);

        SearchResult<Question> FindQuestions(QuestionSearchCriteria criteria);
    }
}
