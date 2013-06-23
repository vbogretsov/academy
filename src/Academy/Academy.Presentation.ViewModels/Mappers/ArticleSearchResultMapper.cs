using System;
using System.Collections.Generic;
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
            viewModel.Articles = model.Results.Select(ArticleMapper.Map);
            return viewModel;
        }
    }
}
