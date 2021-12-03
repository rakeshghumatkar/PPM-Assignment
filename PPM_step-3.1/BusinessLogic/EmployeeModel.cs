using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    [Serializable]
    public class EmployeeModel : IComparable<EmployeeModel>
    {
        public int empolyeeId { get; set; }

        public int roleId { get; set; }
        public int projectId { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailID { get; set; }
        public string phoneNo { get; set; }
        public string address { get; set; }

        public RoleModel role = new RoleModel();
        
        public EmployeeModel() { }
        public EmployeeModel(int eid, string fname, string lname, string email, string phone, string addrss)
        {
            empolyeeId = eid;
            firstName = fname;
            lastName = lname;
            emailID = email;
            phoneNo = phone;
            address = addrss;

        }

       

        public RoleModel GetRole()
        {
            return role;
        }
        public void SetRole(RoleModel role)
        {
           
            this.role.roleId = role.roleId;
            this.role.roleName = role.roleName;
        }
        
        public int GetRoleId()
        {
            return role.roleId;
        }

        public int CompareTo(EmployeeModel other)
        {
            if (this.empolyeeId > other.empolyeeId)
                return 1;
            else if (this.empolyeeId < other.empolyeeId)
                return -1;
            else
                return 0;
        }
    }
}
