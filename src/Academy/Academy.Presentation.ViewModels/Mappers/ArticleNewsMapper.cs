using System;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class ArticleNewsMapper
    {
        private static readonly NewsMapper<ArticleNews, ArticleNewsViewModel> mapper =
            new NewsMapper<ArticleNews, ArticleNewsViewModel>();

        public static ArticleNewsViewModel Map(ArticleNews model)
        {
            var viewModel = mapper.Map(model);
            viewModel.Article = ArticleMapper.Map(model.Article);
            return viewModel;
        }
    }
}
