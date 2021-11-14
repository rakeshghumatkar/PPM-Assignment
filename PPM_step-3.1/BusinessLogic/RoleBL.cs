using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class RoleBL
    {
        public List<RoleModel> RoleList = new List<RoleModel>();

        public RoleBL()
        { }

        public void AddRole(RoleModel role)
        {
            RoleList.Add(role);
        }

        public List<RoleModel> ReturnRoleList ()
        {
            return RoleList;
        }
        public bool IsRole(int rid)
        {
            for (int i = 0; i < RoleList.Count; i++)
            {
                if (rid == RoleList[i].roleId)
                {
                    return true;
                }
            }
            return false;
        }
        public RoleModel GetRoleById(int rid)
        {
            RoleModel role = new RoleModel();
            for (int i = 0; i < RoleList.Count; i++)
            {
                if (rid == RoleList[i].roleId)
                {
                    role = RoleList[i];
                    return role;
                }
            }
            return role;
        }

    }
}
