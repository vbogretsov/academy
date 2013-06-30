﻿using System;
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
            article.Id = viewModel.Id;
            article.Source = viewModel.Source;
            article.Title = viewModel.Title;
            article.Description = viewModel.Description;
            article.Disciplines = viewModel.Disciplines.Select(DisciplineMapper.Map).ToList();
            article.Comments = viewModel.Comments.Select(CommentMapper.Map).ToList();
            article.Authors = viewModel.Authors.Select(AuthorMapper.Map).ToList();
            return article;
        }

        public static ArticleViewModel Map(Article article)
        {
            ArticleViewModel viewModel = new ArticleViewModel();
            viewModel.Id = article.Id;
            viewModel.Title = article.Title;
            viewModel.Description = article.Description;
            viewModel.Source = article.Source;
            viewModel.Authors = article.Authors.Select(AuthorMapper.Map).ToList();
            viewModel.Disciplines = article.Disciplines.Select(DisciplineMapper.Map).ToList();
            // TODO: add paging for comments
            if (article.Comments != null)
            {
                viewModel.Comments = article.Comments.Select(CommentMapper.Map).ToList();
            }
            return viewModel;
        }
    }
}
