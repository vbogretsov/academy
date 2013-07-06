using System;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class AnswerNewsMapper
    {
        private static readonly NewsMapper<AnswerNews, AnswerNewsViewModel> mapper =
            new NewsMapper<AnswerNews, AnswerNewsViewModel>();

        public static AnswerNewsViewModel Map(AnswerNews model)
        {
            //var viewModel = new AnswerNewsViewModel();
            //viewModel.Id = model.Id;
            //viewModel.Answer = SingleAnswerMapper.Map(model.Answer);
            //viewModel.Read = model.Read;
            var viewModel = mapper.Map(model);
            viewModel.Answer = SingleAnswerMapper.Map(model.Answer);
            return viewModel;
        }
    }
}
