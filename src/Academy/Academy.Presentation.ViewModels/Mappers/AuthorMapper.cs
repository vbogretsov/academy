using System;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class AuthorMapper
    {
        public static User Map(AuthorViewModel viewModel)
        {
            User user = new User();
            user.Id = viewModel.Id;
            user.Email = viewModel.Email;
            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            return user;
        }

        public static AuthorViewModel Map(User user)
        {
            AuthorViewModel viewModel = new AuthorViewModel();
            viewModel.Id = user.Id;
            viewModel.Email = user.Email;
            viewModel.FirstName = user.FirstName;
            viewModel.LastName = user.LastName;
            return viewModel;
        }
    }
}
