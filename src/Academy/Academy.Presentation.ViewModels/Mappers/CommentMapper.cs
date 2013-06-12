﻿using System;
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
            return viewModel;
        }

        public static Comment Map(CommentViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
