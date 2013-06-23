using System;
using System.Collections.Generic;
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
            viewModel.Questions = model.Results.Select(QuestionMapper.Map);
            return viewModel;
        }
    }
}
