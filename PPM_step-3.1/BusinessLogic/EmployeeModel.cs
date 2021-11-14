using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class EmployeeModel
    {
        public int empolyeeId { get; set; }
        //public int roleId { get; set; }
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

        /*public EmployeeModel(int eid, int roleID,string fname, string lname, string email, string phone, string addrss)
        {
            empolyeeId = eid;
            //roleId = roleID;
            firstName = fname;
            lastName = lname;
            emailID = email;
            phoneNo = phone;
            address = addrss;

        }*/

        public RoleModel GetRole()
        {
            return role;
        }
        public void SetRole(RoleModel role)
        {
            //roleId = role.roleId;
            this.role.roleId = role.roleId;
            this.role.roleName = role.roleName;
        }
        
        public int GetRoleId()
        {
            return role.roleId;
        }
    }
}
