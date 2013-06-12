using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Web.Security;
using Academy.Domain.DataAccess;
using Academy.Domain.Objects;
using Academy.Security;

namespace Academy.Domain.Services
{
    public class AccountService
    {
        private const string UserRole = "User";

        private readonly RoleManager roleManager;

        private readonly AccountManager accountManager;

        private readonly UserStorage userStorage;

        public AccountService(
            RoleManager roleManager,
            AccountManager accountManager,
            UserStorage userStorage)
        {
            this.roleManager = roleManager;
            this.accountManager = accountManager;
            this.userStorage = userStorage;
        }

        public void Register(User user, string password)
        {
            if (!userStorage.Contains(user.Email))
            {
                userStorage.Add(user);
                RegisterNewUser(user, password);
            }
        }

        public bool Login(string username, string password, bool remember = false)
        {
            return accountManager.Login(username, password, remember);
        }

        public void Logout()
        {
            accountManager.Logout();
        }

        private void RegisterNewUser(User user, string password)
        {
            try
            {
                roleManager.AddUserToRole(user.Email, UserRole);
                accountManager.CreateAccount(user.Email, password);
            }
            catch (SecurityCreateUserException)
            {
                userStorage.Delete(user);
                throw;
            }
        }
    }
}
