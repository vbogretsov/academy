using System;
using System.Collections.Generic;
using System.Linq;
using Academy.Domain.Search;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class ArticleSearchMapper
    {
        public static ArticleSearchCriteria Map(ArticleSearchViewModel viewModel)
        {
            var model = new ArticleSearchCriteria();
            model.Title = viewModel.Title ?? String.Empty;
            model.Description = viewModel.Description ?? String.Empty;
            model.Author = viewModel.Author ?? String.Empty;
            model.Disciplines = viewModel.Disciplines != null
                ? viewModel.Disciplines.Select(x => x.Id)
                : new int[0];
            return model;
        }
    }
}
