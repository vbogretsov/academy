using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class SingleCommentMapper
    {
        public static CommentViewModel Map(Comment comment)
        {
            CommentViewModel viewModel = CommentMapper.Map(comment);
            viewModel.Article = ArticleSmallMapper.Map(comment.Article);
            return viewModel;
        }
    }
}
