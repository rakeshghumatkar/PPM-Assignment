using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    [Serializable]
    public class RoleModel : IComparable<RoleModel>
    {
        public int roleId { get; set; }
        public string roleName { get; set; }
        public RoleModel()
        { }

        public RoleModel(int roleId, string roleName)
        {
            this.roleId = roleId;
            this.roleName = roleName;

        }

        public int CompareTo(RoleModel other)
        {
            if (this.roleId > other.roleId)
                return 1;
            else if (this.roleId < other.roleId)
                return -1;
            else
                return 0;
        }

       
    }
}
