using System;
using System.Web.Security;
using WebMatrix.WebData;

namespace Academy.Security.Simple
{
    public class WebMatrixAccountManager : AccountManager
    {
        public override bool Login(string username, string password, bool remember = false)
        {
            return WebSecurity.Login(username, password);
        }

        public override void Logout()
        {
            WebSecurity.Logout();
        }

        public override void CreateAccount(string username, string password)
        {
            WebSecurity.CreateAccount(username, password);
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
