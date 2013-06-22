using System;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class QuestionNewsMapper
    {
        public static QuestionNewsViewModel Map(QuestionNews model)
        {
            var viewModel = new QuestionNewsViewModel();
            viewModel.Id = model.Id;
            viewModel.Question = QuestionMapper.Map(model.Question);
            viewModel.Read = model.Read;
            return viewModel;
        }
    }
}
