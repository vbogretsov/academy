using System;
using System.Linq;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class ArticleMapper
    {
        private static readonly TitledPostMapper<Article, ArticleViewModel> mapper =
            new TitledPostMapper<Article, ArticleViewModel>();

        public static Article Map(ArticleViewModel viewModel)
        {
            var model = mapper.Map(viewModel);
            model.Source = viewModel.Source;
            model.Disciplines = viewModel.Disciplines.Select(
                DisciplineMapper.Map).ToList();
            model.Authors = viewModel.Authors.Select(
                AuthorMapper.Map).ToList();
            return model;
        }

        public static ArticleViewModel Map(Article model)
        {
            var viewModel = mapper.Map(model);
            viewModel.Source = model.Source;
            viewModel.Disciplines = model.Disciplines.Select(
                DisciplineMapper.Map).ToList();
            viewModel.Authors = model.Authors.Select(
                AuthorMapper.Map).ToList();
            return viewModel;
        }
    }
}
