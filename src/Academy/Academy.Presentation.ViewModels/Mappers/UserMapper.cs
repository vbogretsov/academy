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
            user.Id = viewModel.Id;
            user.Email = viewModel.Email;
            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.BirthDate = DateMapper.Map(viewModel.BirthDate);
            user.PhotoFileName = viewModel.PhotoFile != null
                ? viewModel.PhotoFile.FileName
                : viewModel.PhotoFileName;
            user.University = viewModel.University;
            return user;
        }

        public static UserViewModel Map(User user)
        {
            UserViewModel viewModel = new UserViewModel();
            viewModel.Id = user.Id;
            viewModel.Email = user.Email;
            viewModel.FirstName = user.FirstName;
            viewModel.LastName = user.LastName;
            viewModel.University = user.University;
            viewModel.BirthDate = DateMapper.Map(user.BirthDate);
            viewModel.PhotoFileName = user.PhotoFileName;
            // <refactor>
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
            if (user.ArticleNewses != null)
            {
                viewModel.ArticleNews = user.ArticleNewses.Select(ArticleNewsMapper.Map);
            }
            if (user.QuestionNewses != null)
            {
                viewModel.QuestionNews = user.QuestionNewses.Select(QuestionNewsMapper.Map);
            }
            if (user.CommentNewses != null)
            {
                viewModel.CommentNews = user.CommentNewses.Select(CommentNewsMapper.Map);
            }
            if (user.AnswerNewses != null)
            {
                viewModel.AnswerNews = user.AnswerNewses.Select(AnswerNewsMapper.Map);
            }
            if (user.Notes != null)
            {
                viewModel.Notes = user.Notes.Select(NoteMapper.Map);
            }
            // </refactor>
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
