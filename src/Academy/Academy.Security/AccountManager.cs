using System;
using System.Web.Security;

namespace Academy.Security
{
    public abstract class AccountManager
    {
        public abstract bool Login(
            string username,
            string password,
            bool remember = false);

        public abstract void Logout();

        public abstract void CreateAccount(
            string username,
            string password);

        public abstract MembershipUser GetUser();

        public abstract bool UserExists(string username);

        public abstract void InitializeDatabaseConnection(
            string connectionStringName,
            string userTableName,
            string userIdColumnName,
            string userNameColumnName,
            bool autoCreateTables = false);
    }
}
