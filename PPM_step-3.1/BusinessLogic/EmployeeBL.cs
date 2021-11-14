using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class EmployeeBL
    {
        public List<EmployeeModel> EmployeeList = new List<EmployeeModel>();
        public void AddEmployee(EmployeeModel employee)
        {
            EmployeeList.Add(employee);
        }

        public List<EmployeeModel> ReturnEmployeeList()
        {
            return EmployeeList;
        }

        public void AssignRoleToEmployee(int eid,RoleModel role)
        {
            for(int i=0;i<EmployeeList.Count; i++)
            {
                if(EmployeeList[i].empolyeeId == eid)
                {
                    EmployeeList[i].SetRole(role);
                }
                
            }
            
        }

        public bool IsEmployee(int eid)
        {
            for(int i=0; i<EmployeeList.Count; i++)
            {
                if(eid == EmployeeList[i].empolyeeId)
                {
                    return true;
                }
            }
            return false;
        }

        public EmployeeModel GetEmployeeById(int eid)
        {
            EmployeeModel emp = new EmployeeModel();
            for(int i=0; i<EmployeeList.Count; i++ )
            {
                if(eid == EmployeeList[i].empolyeeId)
                {
                    emp = EmployeeList[i];
                    return emp;
                }
            }
            return emp;
        }
    }
}
