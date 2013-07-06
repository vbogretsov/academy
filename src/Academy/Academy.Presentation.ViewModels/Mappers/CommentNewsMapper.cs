using System;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class CommentNewsMapper
    {
        private static readonly NewsMapper<CommentNews, CommentNewsViewModel> mapper =
            new NewsMapper<CommentNews, CommentNewsViewModel>();

        public static CommentNewsViewModel Map(CommentNews model)
        {
            var viewModel = mapper.Map(model);
            viewModel.Comment = CommentMapper.Map(model.Comment);
            return viewModel;
        }
    }
}
