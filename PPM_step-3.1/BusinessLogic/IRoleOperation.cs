using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    interface IRoleOperation
    {
        void AddRole(RoleModel role);
        void DeleteRole(int roleId);

        bool IsRoleExist(int rid);

        RoleModel GetRole(int rid);

        List<RoleModel> GetRole();
    }
}
