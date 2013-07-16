using System;
using System.Web.Security;
using WebMatrix.WebData;

namespace Academy.Security.Simple
{
    public class WebMatrixAccountManager : AccountManager
    {
        public override bool Login(string username, string password, bool remember = false)
        {
            return WebSecurity.Login(username, password, remember);
        }

        public override void Logout()
        {
            WebSecurity.Logout();
        }

        public override void CreateAccount(string username, string password)
        {
            try
            {
                WebSecurity.CreateAccount(username, password);
            }
            catch (MembershipCreateUserException exception)
            {
                throw new SecurityCreateUserException(exception);
            }
        }

        public override MembershipUser GetUser()
        {
            return Membership.GetUser();
        }

        public override bool UserExists(string username)
        {
            return WebSecurity.UserExists(username);
        }

        public override void InitializeDatabaseConnection(
            string connectionStringName,
            string userTableName,
            string userIdColumnName,
            string userNameColumnName,
            bool autoCreateTables = false)
        {
            WebSecurity.InitializeDatabaseConnection(
                connectionStringName,
                userTableName,
                userIdColumnName,
                userNameColumnName,
                autoCreateTables);
        }
    }
}
