using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class QuestionMapper
    {
        public static Question Map(QuestionViewModel viewModel)
        {
            Question question = new Question();
            question.QuestionId = viewModel.Id;
            question.UserId = viewModel.AuthorId;
            question.Title = viewModel.Title;
            question.Text = viewModel.Text;
            question.PostedDate = viewModel.PostedDate;
            question.Disciplines = viewModel.Disciplines.Select(
                DisciplineMapper.Map).ToList();
            return question;
        }

        public static QuestionViewModel Map(Question question)
        {
            QuestionViewModel viewModel = new QuestionViewModel();
            viewModel.Id = question.QuestionId;
            viewModel.Title = question.Title;
            viewModel.Text = question.Text;
            viewModel.PostedDate = question.PostedDate;
            viewModel.Author = AuthorMapper.Map(question.User);
            viewModel.Disciplines = question.Disciplines.Select(
                DisciplineMapper.Map);
            if (question.Answers != null)
            {
                viewModel.Answers = question.Answers.Select(AnswerMapper.Map);
            }
            return viewModel;
        }
    }
}
