using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;
using Academy.Utils;
using Academy.Utils.Collections;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class UserMapper
    {
        public static User Map(UserViewModel viewModel)
        {
            User user = new User();
            user.Email = viewModel.Email;
            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.BirthDate = DateMapper.Map(viewModel.BirthDate);
            user.PhotoFileName = viewModel.PhotoFile.FileName;
            user.University = viewModel.University;
            user.Comments.Add(viewModel.Comments.Select(CommentMapper.Map));
            user.Articles.Add(viewModel.Articles.Select(ArticleMapper.Map));
            user.Disciplines.Add(viewModel.Disciplines.Select(DisciplineMapper.Map));
            return user;
        }

        public static UserViewModel Map(User user)
        {
            throw new NotImplementedException();
        }
    }
}
