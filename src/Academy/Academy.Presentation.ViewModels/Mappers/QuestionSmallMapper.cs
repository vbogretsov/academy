using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class QuestionSmallMapper
    {
        public static QuestionViewModel Map(Question question)
        {
            QuestionViewModel viewModel = new QuestionViewModel();
            viewModel.Id = question.Id;
            viewModel.Title = question.Title;
            return viewModel;
        }
    }
}
