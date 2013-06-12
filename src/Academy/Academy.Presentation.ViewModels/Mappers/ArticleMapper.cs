using System;
using System.Linq;
using Academy.Domain.Objects;
using Academy.Utils.Collections;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class ArticleMapper
    {
        public static Article Map(ArticleViewModel viewModel)
        {
            Article article = new Article();
            article.Source = viewModel.Source;
            // TODO: article.Title
            article.Description = viewModel.Description;
            article.Disciplines.Add(viewModel.Disciplines.Select(DisciplineMapper.Map));
            article.Comments.Add(viewModel.Comments.Select(CommentMapper.Map));
            article.Authors.Add(viewModel.Authors.Select(AuthorMapper.Map));
            return article;
        }

        public static ArticleViewModel Map(Article article)
        {
            ArticleViewModel viewModel = new ArticleViewModel();
            viewModel.Id = article.ArticleId;
            viewModel.Description = article.Description;
            viewModel.Source = article.Source;
            return viewModel;
        }
    }
}
