using System;
using System.Linq;
using Academy.Domain.Objects;
using Academy.Domain.Search;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class QuestionSearchResultMapper
    {
        public static QuestionSearchResultViewModel Map(SearchResult<Question> model)
        {
            var viewModel = new QuestionSearchResultViewModel();
            viewModel.Questions = model.ResultsCount > 0
                ? model.Results.Select(QuestionMapper.Map)
                : null;
            return viewModel;
        }
    }
}
