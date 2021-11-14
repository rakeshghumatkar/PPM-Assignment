using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class RoleModel
    {
        public int roleId { get; set; }
        public string roleName { get; set; }

        //public List<string> roleNames = new List<string>();

        public RoleModel()
        { }

        public RoleModel(int roleId, string roleName)
        {
            this.roleId = roleId;
            //roleNames.Add(roleName);
            this.roleName = roleName;

        }

       /* public void AddRole(string roleName)
        {
            roleNames.Add(roleName);
        }*/
    }
}
