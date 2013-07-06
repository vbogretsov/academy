using System;
using System.Linq;
using Academy.Domain.Objects;

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
            if (user.Disciplines != null)
            {
                viewModel.Disciplines = user.Disciplines.Select(DisciplineMapper.Map);
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
