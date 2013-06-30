using System;
using System.Web.Security;
using Academy.Domain.DataAccess;
using Academy.Domain.Interface;
using Academy.Domain.Objects;
using Academy.Security;

namespace Academy.Domain.Services
{
    public class AccountService : IAccountService
    {
        private const string UserRole = "User";

        private readonly RoleManager roleManager;

        private readonly AccountManager accountManager;

        private readonly IDataContext dataContext;

        public AccountService(
            RoleManager roleManager,
            AccountManager accountManager,
            IDataContext dataContext)
        {
            this.roleManager = roleManager;
            this.accountManager = accountManager;
            this.dataContext = dataContext;
        }

        //TODO: move to separate class
        public void Update(User user)
        {
            user.LastAccessDate = DateTime.Now;
            dataContext.UserStorage.Update(user);
        }

        public User GetCurrentUser()
        {
            User user = null;
            var membershipUser = accountManager.GetUser();
            if (membershipUser != null)
            {
                user = dataContext.UserStorage.Get(membershipUser.UserName);
            }
            return user;
        }

        public bool IsUserExists(string userName)
        {
            return dataContext.UserStorage.Exists(userName);
        }

        public void Register(User user, string password)
        {
            if (!dataContext.UserStorage.Exists(user.Email))
            {
                user.LastAccessDate = DateTime.Now;
                user.RegistrationDate = DateTime.Now;
                dataContext.UserStorage.Add(user);
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
                dataContext.UserStorage.Remove(user.Email);
                throw;
            }
        }
    }
}
