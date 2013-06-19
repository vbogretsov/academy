using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class AnswerMapper
    {
        public static AnswerViewModel Map(Answer answer)
        {
            AnswerViewModel viewModel = new AnswerViewModel();
            viewModel.Id = answer.AnswerId;
            viewModel.QuestionId = answer.QuestionId;
            viewModel.Text = answer.Text;
            viewModel.PostedDate = answer.PostedDate;
            viewModel.Author = AuthorMapper.Map(answer.User);
            return viewModel;
        }

        public static Answer Map(AnswerViewModel viewModel)
        {
            Answer answer = new Answer();
            answer.AnswerId = viewModel.Id;
            answer.QuestionId = viewModel.QuestionId;
            answer.Text = viewModel.Text;
            answer.PostedDate = viewModel.PostedDate;
            return answer;
        }
    }
}
