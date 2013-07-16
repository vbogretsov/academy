using System;
using System.Linq;
using Academy.Domain.Objects;
using Academy.Domain.Search;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class ArticleSearchResultMapper
    {
        public static ArticleSearchResultViewModel Map(SearchResult<Article> model)
        {
            var viewModel = new ArticleSearchResultViewModel();
            viewModel.Articles = model.ResultsCount > 0
                ? model.Results.Select(ArticleMapper.Map)
                : null;
            return viewModel;
        }
    }
}
