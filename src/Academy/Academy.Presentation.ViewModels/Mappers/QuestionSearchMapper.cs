using System;
using System.Collections.Generic;
using System.Linq;
using Academy.Domain.Search;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class QuestionSearchMapper
    {
        public static QuestionSearchCriteria Map(QuestionSearchViewModel viewModel)
        {
            var model = new QuestionSearchCriteria();
            model.Title = viewModel.Title;
            if (viewModel.Disciplines != null)
            {
                model.Disciplines = viewModel.Disciplines.Select(x => x.Id);
            }
            return model;
        }
    }
}
