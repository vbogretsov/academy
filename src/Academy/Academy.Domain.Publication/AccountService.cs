using System;
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

        private readonly IUserStorage userStorage;

        public AccountService(
            RoleManager roleManager,
            AccountManager accountManager,
            IUserStorage userStorage)
        {
            this.roleManager = roleManager;
            this.accountManager = accountManager;
            this.userStorage = userStorage;
        }

        //TODO: move to separate class
        public void Update(User user)
        {
            userStorage.Update(user);
        }

        public User GetCurrentUser()
        {
            User user = null;
            var membershipUser = accountManager.GetUser();
            if (membershipUser != null)
            {
                user = userStorage.Get(membershipUser.UserName);
            }
            return user;
        }

        public bool IsUserExists(string userName)
        {
            return userStorage.Contains(userName);
        }

        public void Register(User user, string password)
        {
            if (!userStorage.Contains(user.Email))
            {
                user.LastAccessDate = DateTime.Now;
                user.RegistrationDate = DateTime.Now;
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
