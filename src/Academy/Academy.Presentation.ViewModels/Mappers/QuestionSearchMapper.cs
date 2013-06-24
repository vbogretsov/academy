using System;
using System.Linq;
using Academy.Domain.Search;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class QuestionSearchMapper
    {
        public static QuestionSearchCriteria Map(QuestionSearchViewModel viewModel)
        {
            var model = new QuestionSearchCriteria();
            model.Keyword = viewModel.Keyword ?? String.Empty;
            model.Disciplines = viewModel.Disciplines != null
                ? viewModel.Disciplines.Select(x => x.Id)
                : new int[0];
            return model;
        }
    }
}
