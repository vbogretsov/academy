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
            user.UserId = viewModel.Id;
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
            UserViewModel viewModel = new UserViewModel();
            viewModel.Id = user.UserId;
            viewModel.Email = user.Email;
            viewModel.FirstName = user.FirstName;
            viewModel.LastName = user.LastName;
            viewModel.University = user.University;
            viewModel.BirthDate = DateMapper.Map(user.BirthDate);
            viewModel.PhotoFileName = user.PhotoFileName;
            if (user.Disciplines != null)
            {
                viewModel.Disciplines = user.Disciplines.Select(DisciplineMapper.Map);
            }
            if (user.Articles != null)
            {
                viewModel.Articles = user.Articles.Select(ArticleMapper.Map);
            }
            if (user.Comments != null)
            {
                viewModel.Comments = user.Comments.Select(SingleCommentMapper.Map);
            }
            if (user.Questions != null)
            {
                viewModel.Questions = user.Questions.Select(QuestionMapper.Map);
            }
            if (user.Answers != null)
            {
                viewModel.Answers = user.Answers.Select(SingleAnswerMapper.Map);
            }
            return viewModel;
        }

        public static User Map(RegistrationViewModel viewModel)
        {
            User user = new User();
            user.Email = viewModel.Email;
            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.University = viewModel.University;
            user.BirthDate = DateMapper.Map(viewModel.BirthDate);
            return user;
        }
    }
}
