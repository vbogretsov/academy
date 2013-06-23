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
            model.Title = viewModel.Title;
            model.Description = viewModel.Description;
            model.Author = viewModel.Author;
            if (viewModel.Disciplines != null)
            {
                model.Disciplines = viewModel.Disciplines.Select(x => x.Id);
            }
            return model;
        }
    }
}
