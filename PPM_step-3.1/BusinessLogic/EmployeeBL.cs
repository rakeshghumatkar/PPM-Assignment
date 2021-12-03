using PPM_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPM_DAL_EF;

namespace BusinessLogic
{
    public class EmployeeBL : IEmployeeOperation
    {
        public List<EmployeeModel> EmployeeList = new List<EmployeeModel>();
        public void AddEmployee(EmployeeModel employee)
        {
            EmployeeList.Add(employee);
        }

        public void DeleteEmployee(EmployeeModel employee)
        {
            EmployeeList.Remove(employee);
        }

        public List<EmployeeModel> GetEmployee()
        {
            EmployeeList.Sort();
            return EmployeeList;
        }

        public void AssignRoleToEmployee(int eid,RoleModel role)
        {
            for(int i=0;i<EmployeeList.Count; i++)
            {
                if(EmployeeList[i].empolyeeId == eid)
                {
                    EmployeeList[i].SetRole(role);
                    EmployeeList[i].roleId = role.roleId;
                }
                
            }
            
        }

        public bool IsEmployeeExist(int eid)
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

        public bool Validation(EmployeeModel employee)
        {
            if (employee.empolyeeId == null || employee.firstName == "" || employee.lastName == "" || employee.emailID == "" || employee.phoneNo == "" || employee.address == "")
                return false;
            else if (EmployeeList.Contains(employee))
                return false;
            else if (IsEmployeeExist(employee.empolyeeId))
                return false;
            else if (IsEmployeeExistInDB(employee.empolyeeId))
                return false;
            else
                return true;
        }

        public bool IsEmployeeRoleExist(int rid, ref int index)
        {
            for (int i = 0; i < EmployeeList.Count; i++)
            {
                if (rid == EmployeeList[i].GetRoleId())
                {
                    index = i;
                    return true;
                }
            }
            return false;
        }

        public bool IsEmployeeRoleExist(int rid)
        {
            for (int i = 0; i < EmployeeList.Count; i++)
            {
                if (rid == EmployeeList[i].GetRoleId())
                {
                    return true;
                }
            }
            return false;
        }

        public void DeleteRoleOfEmployee(int index)
        {
            RoleModel newRole = new RoleModel();
            EmployeeList[index].SetRole(newRole);
        }

        public EmployeeModel GetEmployee(int eid)
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

        public void SaveIntoFile()
        {
            try
            {
                XMLFileData data = new XMLFileData();
                string filePath = "C:\\Users\\rakes\\source\\repos\\PPM_step-3.1\\EmployeeFile.xml";
                data.XmlSerialize(typeof(List<EmployeeModel>), EmployeeList, filePath);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SaveIntoDB(EmployeeModel emp)
        {
            EmployeesDA db = new EmployeesDA();
            db.SaveEmployee(emp.empolyeeId, emp.firstName, emp.lastName, emp.emailID, emp.phoneNo, emp.address, emp.roleId);

           
        }

        public void DeleteAllRecord()
        {
            EmployeeList.Clear();

        }



        public void ViewAllFromDB()
        {
            EmployeesDA db = new EmployeesDA();
            string query = "Select *from Employees;";
            db.GetEmployee(query);
        }

        public void ViewAllFromDB(int eid)
        {
            EmployeesDA db = new EmployeesDA();
            string query = "Select *from Employees where employeeId = "+eid+";";
            db.GetEmployee(query);
        }

        public void DeleteEmployeeFromDB(int eid)
        {
            EmployeesDA db = new EmployeesDA();
          
            db.DeleteEmployee(eid);
        }

        public bool IsEmployeeExistInDB(int eid)
        {
            CommonOperation db = new CommonOperation();
            string query = "Select *from Employees where employeeId = " + eid + ";";
            bool flag = false;
            db.IsExist(query, ref flag);
            return flag;
        }

        public void AddEmployeeToProjectIntoDB(int pid, int eid)
        {
            CommonOperation db = new CommonOperation();
            string query1 = "insert into ProjectEmployees values ("+pid+","+eid+",CURRENT_TIMESTAMP);";
            db.ExcuteQuery(query1);
            string query2 = "UPDATE Employees SET modifiedDate = CURRENT_TIMESTAMP WHERE employeeId = " + eid + ";";
            db.ExcuteQuery(query2);
            string query3 = "UPDATE Projects SET modifiedDate = CURRENT_TIMESTAMP WHERE projectId = " + pid + ";";
            db.ExcuteQuery(query3);
        }

        public void AssignRoleToEmployeeIntoDB(int eid, int rid)
        {
            CommonOperation db = new CommonOperation();

            string query1 = "update Employees set roleID = "+rid+" where employeeId = "+eid+";";
            db.ExcuteQuery(query1);

            string query2 = "UPDATE Employees SET modifiedDate = CURRENT_TIMESTAMP WHERE employeeId = " + eid + ";";
            db.ExcuteQuery(query2);

            string query3 = "UPDATE Roles SET modifiedDate = CURRENT_TIMESTAMP WHERE roleId = " + rid + ";";
            db.ExcuteQuery(query3);
        }


        public void UpdateEmployee(EmployeeModel emp)
        {
            CommonOperation db = new CommonOperation();
            string query = "Update Employees set firstName = '"+emp.firstName+"', lastName = '"+emp.lastName+"', emailId = '"+emp.emailID+"', phoneNo = '"+emp.phoneNo+"', eAddress = '"+emp.address+"', modifiedDate = CURRENT_TIMESTAMP where employeeId = "+emp.empolyeeId+"; ";
            db.ExcuteQuery(query);
        }


        public void SaveEmployeeUsingEF(EmployeeModel emp)
        {
            try
            {
                
                PPMEntities db = new PPMEntities();
                Employee employee = new Employee();
                employee.employeeId = emp.empolyeeId;
                employee.firstName = emp.firstName;
                employee.lastName = emp.lastName;
                employee.emailId = emp.emailID;
                employee.phoneNo = emp.phoneNo;
                employee.eAddress = emp.address;
                employee.createDate = DateTime.Now;
                employee.modifiedDate = DateTime.Now;
                
                if (emp.roleId == null)
                    employee.roleID = 0;
                else
                    employee.roleID = emp.roleId;
               
                db.Employees.Add(employee);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.Message);
         
            }
        }
         public void SaveEmployeeUsingEF()
        {
            PPMEntities db = new PPMEntities();
            Employee employee = new Employee();
            employee.employeeId = 526;
            employee.firstName = "rams";
            employee.lastName = "djj";
            employee.emailId = "dsak@";
            employee.phoneNo = "8940349853";
            employee.eAddress = "wjlksd";
            employee.createDate = DateTime.Now;
            employee.modifiedDate = DateTime.Now;
            employee.roleID =6;

            db.Employees.Add(employee);
            db.SaveChanges();
        }



    }
}
