using System;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class AnswerNewsMapper
    {
        public static AnswerNewsViewModel Map(AnswerNews model)
        {
            var viewModel = new AnswerNewsViewModel();
            viewModel.Id = model.Id;
            viewModel.Answer = SingleAnswerMapper.Map(model.Answer);
            viewModel.Read = model.Read;
            return viewModel;
        }
    }
}
