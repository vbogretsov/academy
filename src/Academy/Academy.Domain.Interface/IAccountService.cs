using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Domain.Interface
{
    public interface IAccountService
    {
        void Update(User user);

        User GetCurrentUser();

        bool IsUserExists(string userName);

        void Register(User user, string password);

        bool Login(string username, string password, bool remember = false);

        void Logout();
    }
}
