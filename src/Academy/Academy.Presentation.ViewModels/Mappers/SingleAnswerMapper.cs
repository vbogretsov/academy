using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class SingleAnswerMapper
    {
        public static AnswerViewModel Map(Answer answer)
        {
            AnswerViewModel viewModel = AnswerMapper.Map(answer);
            viewModel.Question = QuestionSmallMapper.Map(answer.Question);
            return viewModel;
        }
    }
}
