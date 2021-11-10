using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPM_step_3
{
    public class BusinessLogic
    {
        public static List<Project> projectList = new List<Project>();
        public static List<Employee> employeeList = new List<Employee>();
        public static List<Role> roleList = new List<Role>();


        public void AddProjects()
        {
            Project project = new Project();
            project.InputProject();
            projectList.Add(project);
        }

        public void ViewProjects()
        {
            Console.WriteLine("Project list : ");
            for (int j = 0; j < projectList.Count; j++)
            {
                projectList[j].ViewProject();
            }
        }

        public void AddEmployee()
        {
            Employee employee = new Employee();
            employeeList.Add(employee);
        }

        public void ViewEmployees()
        {
            Console.WriteLine(" Employees list : ");

            for (int j = 0; j < employeeList.Count; j++)
            {
                employeeList[j].ShowEmployeeDetails();
            }
        }

        public void AddRole()
        {
            Role role = new Role();
            roleList.Add(role);
        }

        public void ViewRoles()
        {
            Console.WriteLine(" Roles list : ");

            for (int j = 0; j < roleList.Count; j++)
            {
                roleList[j].ViewRole();
            }
        }

        public bool IsProject(string projectName)
        {
            for (int i = 0; i < projectList.Count; i++)
            {
                if (projectName == projectList[i].projectName)
                    return true;
            }
            Console.WriteLine(" Opps! Project is not found");
            return false;
        }

        public bool IsEmployee(int employeeId)
        {
            for (int i = 0; i < employeeList.Count; i++)
            {
                if (employeeId == employeeList[i].empolyeeId)
                    return true;
            }
            Console.WriteLine(" Opps! Employee-Id is not found");
            return false;
        }


        public bool IsRole(int roleID)
        {
            for(int i=0; i<roleList.Count;i++)
            {
                if (roleID == roleList[i].roleId)
                    return true;
            }
            Console.WriteLine(" Opps! Role-ID is not found");
            return false;
        }

        public void AddEmployeeToProject(string pname, int eid)
        {

            for (int j = 0; j < projectList.Count; j++)
            {
                if (projectList[j].projectName == pname)
                {
                    for (int k = 0; k < employeeList.Count; k++)
                    {
                        if (employeeList[k].empolyeeId == eid)
                        {
                            projectList[j].projectEmployees.Add(employeeList[k]);

                            //display the employee working on same projects
                            Console.WriteLine("\n Employee Working in the Project :");
                            projectList[j].ShowAllEmployees();
                        }
                    }
                }
                

            }  
        }


        public void DeleteEmployeeFromProject(String pname1, int eid1)
        {
            for (int j = 0; j < projectList.Count; j++)
            {
                if (projectList[j].projectName == pname1)
                {
                    /*if(projectList[j].)*/
                    projectList[j].DeleteEmployee(eid1);


                    //check line
                    Console.WriteLine("\n After removing the employee from the Project, the employee are ");
                    projectList[j].ShowAllEmployees();
                }
            }
        }

        public void AssignRoleToEmployee(int eid2, int rid)
        {
            for (int k = 0; k < employeeList.Count; k++)
            {
                if (eid2 == employeeList[k].empolyeeId)
                {
                
                    for (int a = 0; a < roleList.Count; a++)
                    {
                        if (rid == roleList[a].roleId)
                        {
                            employeeList[k].roleId = rid;
                        }
                    }

                }

            }
        }

    
    }


    
}
