using System;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class CommentMapper
    {
        private static readonly PostMapper<Comment, CommentViewModel> mapper =
            new PostMapper<Comment, CommentViewModel>();

        public static CommentViewModel Map(Comment model)
        {
            var viewModel = mapper.Map(model);
            viewModel.AuthorId = model.UserId;
            viewModel.Author = AuthorMapper.Map(model.User);
            viewModel.ArticleId = model.ArticleId;
            return viewModel;
        }

        public static Comment Map(CommentViewModel viewModel)
        {
            var model = mapper.Map(viewModel);
            model.ArticleId = viewModel.ArticleId;
            model.UserId = viewModel.AuthorId;
            return model;
        }
    }
}
