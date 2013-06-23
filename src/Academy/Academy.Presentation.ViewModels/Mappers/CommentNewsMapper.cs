using System;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class CommentNewsMapper
    {
        public static CommentNewsViewModel Map(CommentNews model)
        {
            var viewModel = new CommentNewsViewModel();
            viewModel.Id = model.Id;
            viewModel.Comment = SingleCommentMapper.Map(model.Comment);
            viewModel.Read = model.Read;
            return viewModel;
        }
    }
}
