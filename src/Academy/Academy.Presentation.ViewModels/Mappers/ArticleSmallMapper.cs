using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class ArticleSmallMapper
    {
        public static ArticleViewModel Map(Article article)
        {
            ArticleViewModel viewModel = new ArticleViewModel();
            viewModel.Id = article.Id;
            viewModel.Title = article.Title;
            return viewModel;
        }
    }
}
