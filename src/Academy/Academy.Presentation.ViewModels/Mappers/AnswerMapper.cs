using System;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public class AnswerMapper
    {
        private static readonly PostMapper<Answer, AnswerViewModel> mapper =
            new PostMapper<Answer, AnswerViewModel>();

        public static AnswerViewModel Map(Answer model)
        {
            //AnswerViewModel viewModel = new AnswerViewModel();
            //viewModel.Id = answer.Id;
            //viewModel.QuestionId = answer.QuestionId;
            //viewModel.Text = answer.Text;
            //viewModel.PostedDate = answer.PostedDate;
            //viewModel.Author = AuthorMapper.Map(answer.User);
            var viewModel = mapper.Map(model);
            viewModel.AuthorId = model.UserId;
            viewModel.Author = AuthorMapper.Map(model.User);
            viewModel.QuestionId = model.QuestionId;
            return viewModel;
        }

        public static Answer Map(AnswerViewModel viewModel)
        {
            //Answer answer = new Answer();
            //answer.Id = viewModel.Id;
            //answer.UserId = viewModel.AuthorId;
            //answer.QuestionId = viewModel.QuestionId;
            //answer.Text = viewModel.Text;
            //answer.PostedDate = viewModel.PostedDate
            var model = mapper.Map(viewModel);
            model.UserId = viewModel.AuthorId;
            model.QuestionId = viewModel.QuestionId;
            return model;
        }
    }
}
