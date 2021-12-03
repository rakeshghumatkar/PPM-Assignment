using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    interface IEmployeeOperation
    {
        void AddEmployee(EmployeeModel employee);

        void DeleteEmployee(EmployeeModel employee);

        bool IsEmployeeExist(int eid);

        EmployeeModel GetEmployee(int eid);
        List<EmployeeModel> GetEmployee();
        void AssignRoleToEmployee(int eid, RoleModel role);

        void DeleteRoleOfEmployee(int index);
    }
}
