using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class CommentMapper
    {
        public static CommentViewModel Map(Comment comment)
        {
            CommentViewModel viewModel = new CommentViewModel();
            viewModel.Id = comment.CommentId;
            viewModel.Text = comment.Text;
            viewModel.Author = AuthorMapper.Map(comment.User);
            viewModel.PostedDate = comment.PostedDate;
            return viewModel;
        }

        public static Comment Map(CommentViewModel viewModel)
        {
            Comment comment = new Comment();
            comment.CommentId = viewModel.Id;
            comment.Text = viewModel.Text;
            return comment;
        }
    }
}
