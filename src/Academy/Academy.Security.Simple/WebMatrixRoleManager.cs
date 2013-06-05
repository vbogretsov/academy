using System;
using System.Web.Security;

namespace Academy.Security.Simple
{
    public class WebMatrixRoleManager : RoleManager
    {
        public override void AddUserToRole(string username, string rolename)
        {
            Roles.AddUserToRole(username, rolename);
        }

        public override void CreateRole(string rolename)
        {
            Roles.CreateRole(rolename);
        }

        public override bool IsUserInRole(string username, string rolename)
        {
            return Roles.IsUserInRole(username, rolename);
        }

        public override bool RoleExists(string rolename)
        {
            return Roles.RoleExists(rolename);
        }
    }
}
