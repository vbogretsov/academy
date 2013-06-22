using System;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class ArticleNewsMapper
    {
        public static ArticleNewsViewModel Map(ArticleNews model)
        {
            var viewModel = new ArticleNewsViewModel();
            viewModel.Id = model.Id;
            viewModel.Article = ArticleMapper.Map(model.Article);
            viewModel.Read = model.Read;
            return viewModel;
        }
    }
}
