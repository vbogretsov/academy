using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class QuestionMapper
    {
        private static readonly TitledPostMapper<Question, QuestionViewModel> mapper =
            new TitledPostMapper<Question, QuestionViewModel>();

        public static Question Map(QuestionViewModel viewModel)
        {
            var model = mapper.Map(viewModel);
            model.UserId = viewModel.AuthorId;
            model.Disciplines = viewModel.Disciplines.Select(
                DisciplineMapper.Map).ToList();
            return model;
        }

        public static QuestionViewModel Map(Question model)
        {
            var viewModel = mapper.Map(model);
            viewModel.Author = AuthorMapper.Map(model.User);
            viewModel.AuthorId = model.UserId;
            viewModel.Disciplines = model.Disciplines.Select(
                DisciplineMapper.Map);
            return viewModel;
        }
    }
}
