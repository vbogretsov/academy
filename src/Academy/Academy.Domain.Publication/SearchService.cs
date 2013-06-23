using System;
using System.Collections.Generic;
using System.Linq;
using Academy.Domain.DataAccess;
using Academy.Domain.Interface;
using Academy.Domain.Objects;
using Academy.Domain.Search;

namespace Academy.Domain.Services
{
    public class SearchService : ISearchService
    {
        private readonly IDataContext context;

        public SearchService(IDataContext context)
        {
            this.context = context;
        }

        public SearchResult<Article> FindArticles(ArticleSearchCriteria criteria)
        {
            var articles = context.ArticleStorage.FindArticles(criteria);
            var result = articles != null ? articles.ToList() : new List<Article>();
            return new SearchResult<Article>(result);
        }

        public SearchResult<Question> FindQuestions(QuestionSearchCriteria criteria)
        {
            var questions = context.QuestionStorage.FindQuestions(criteria);
            var result = questions != null ? questions.ToList() : new List<Question>();
            return new SearchResult<Question>(result);
        }
    }
}
