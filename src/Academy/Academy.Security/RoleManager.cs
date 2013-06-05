using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Security
{
    public abstract class RoleManager
    {
        public abstract void AddUserToRole(string username, string rolename);

        public abstract void CreateRole(string rolename);

        public abstract bool IsUserInRole(string username, string rolename);

        public abstract bool RoleExists(string rolename);
    }
}
