using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPM_step_2
{
    class Program
    {

        public static List<Project> projectList = new List<Project>();
        public static List<Employee> employeeList = new List<Employee>();
        public static List<Role> roleList = new List<Role>();
        static void Main(string[] args)
        {



            int i = 0;
            try
            {
                do
                {
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("\n - Enter the value with respective following operations : ");
                    Console.WriteLine("1. Add Project");
                    Console.WriteLine("2. View Projects");
                    Console.WriteLine("3. Add Employees");
                    Console.WriteLine("4. View Employees");
                    Console.WriteLine("5. Add Role");
                    Console.WriteLine("6. View Roles");
                    Console.WriteLine("7. Add Employee to project ");
                    Console.WriteLine("8. Delete Employee from project");
                    Console.WriteLine("9. View Project Detail (Project Details and List of employees by role) ");
                    Console.WriteLine("10. Assign Roles to Employees ");
                    Console.WriteLine("11. Quit");
                    try
                    {
                        i = Convert.ToInt32(Console.ReadLine());
                    }

                    catch (FormatException ex1)
                    {
                        Console.WriteLine("Please enter the Numeric value only");
                    }

                    catch (StackOverflowException ex2)
                    {
                        Console.WriteLine("Enter only the single digit value");
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.ToString());
                    }


                    switch (i)
                    {
                        case 1:
                            //Add project
                            Project project = new Project();
                            project.InputProject();
                            projectList.Add(project);
                            Console.WriteLine();
                            break;

                        case 2:
                            //view projects 
                            Console.WriteLine("Project list : ");
                            for (int j = 0; j < projectList.Count; j++)
                            {
                                projectList[j].ViewProject();
                            }
                            Console.WriteLine();
                            break;

                        case 3:
                            //Add Employee
                            Employee employee = new Employee();
                            employeeList.Add(employee);
                            Console.WriteLine();
                            break;

                        case 4:
                            //View employees
                            Console.WriteLine(" Employees list : ");

                            for (int j = 0; j < employeeList.Count; j++)
                            {
                                employeeList[j].ShowEmployeeDetails();
                            }
                            Console.WriteLine();
                            break;

                        case 5:
                            //Add role 
                            Role role = new Role();
                            roleList.Add(role);
                            Console.WriteLine();
                            break;

                        case 6:
                            //View roles of employee
                            Console.WriteLine(" Roles list : ");

                            for (int j = 0; j < roleList.Count; j++)
                            {
                                roleList[j].ViewRole();
                            }
                            Console.WriteLine();
                            break;

                        case 7:
                            //Add employee to project
                            Console.WriteLine("Enter the Project Name ");
                            string pname = Console.ReadLine();
                            bool flag = false;
                            for (int j = 0; j < projectList.Count; j++)
                            {
                                if (projectList[j].projectName == pname)
                                {
                                    flag = true;
                                    Console.Write(" Enter the Employee ID : ");
                                    int eid = 0;
                                    try
                                    {
                                        eid = Convert.ToInt32(Console.ReadLine());
                                    }


                                    catch (FormatException ex1)
                                    {
                                        Console.WriteLine("Please enter the Numeric value only");
                                    }

                                    catch (StackOverflowException ex2)
                                    {
                                        Console.WriteLine("Enter only the single digit value");
                                    }
                                    catch (Exception ex3)
                                    {
                                        Console.Write(ex3.ToString());
                                    }

                                    bool flag01 = false;
                                    for (int k = 0; k < employeeList.Count; k++)
                                    {
                                        if (employeeList[k].empolyeeId == eid)
                                        {
                                            projectList[j].projectEmployees.Add(employeeList[k]);
                                            flag01 = true;


                                            //display the employee working on same projects
                                            Console.WriteLine("\n List of employees after the performation of operation in the project :");
                                            projectList[j].ShowAllEmployees();
                                        }
                                    }
                                    if (flag01 == false)
                                    {
                                        Console.WriteLine(" Opps! Employee ID is not found");
                                    }


                                }
                            }
                            if (!flag)
                                Console.WriteLine("Opps! Project is not found");

                            break;


                        case 8:
                            //Delete Employee from project
                            Console.WriteLine("Enter the Project Name ");
                            string pname1 = null;
                            try
                            {
                                pname1 = Console.ReadLine();

                                bool flag1 = false;
                                for (int j = 0; j < projectList.Count; j++)
                                {
                                    if (projectList[j].projectName == pname1)
                                    {
                                        Console.WriteLine("Enter the employee ID, Who you want to remove from the project");
                                        int eid = Convert.ToInt32(Console.ReadLine());
                                        projectList[j].DeleteEmployee(eid);
                                        flag1 = true;

                                        //check line
                                        Console.WriteLine("\n After removing the employee from the Project, the employee are ");
                                        projectList[j].ShowAllEmployees();
                                    }
                                }
                                if (flag1 == false)
                                    Console.WriteLine("Opps! Project is not found");
                            }

                            catch (FormatException ex1)
                            {
                                Console.WriteLine("Please enter the Numeric value only");
                            }

                            catch (StackOverflowException ex2)
                            {
                                Console.WriteLine("Enter only the single digit value");
                            }
                            catch (Exception ex3)
                            {
                                Console.Write(ex3.ToString());
                            }
                            break;



                        case 9:
                            //View Project Detail(Project Details and List of employees by role)
                            Console.WriteLine("Projects Detail are : ");
                            for (int j = 0; j < projectList.Count; j++)
                            {
                                Console.WriteLine(" - Name Of Project : " + projectList[j].projectName);
                                Console.WriteLine(" Employees Detail are : ");
                                projectList[j].ShowAllEmployees();


                            }

                            /*Console.WriteLine(" Employees Detail are : ");
                            for (int j = 0; j < Employees.Count; j++)
                            {

                                Employees[j].showEmployeeBasicDetails();

                            }*/
                            break;



                        case 10:
                            //Assign Roles to Employees

                            try
                            {
                                bool flag2 = false;
                                bool flag3 = false;
                                Console.WriteLine("Enter the employee ID : ");
                                int eid = Convert.ToInt32(Console.ReadLine());

                                for (int k = 0; k < employeeList.Count; k++)
                                {
                                    if (eid == employeeList[k].empolyeeId)
                                    {
                                        flag2 = true;
                                        Console.WriteLine("Enter the Role-Id ");
                                        int rid = Convert.ToInt32(Console.ReadLine());

                                        for (int a = 0; a < roleList.Count; a++)
                                        {
                                            if (rid == roleList[a].roleId)
                                            {
                                                flag3 = true;
                                                employeeList[k].roleId = rid;
                                            }
                                        }
                                        /*rid = employeeList[k].roleId;
                                        employeeList[k].AddRolesToEmployee();*/
                                    }

                                }
                                if (!flag3)
                                    Console.WriteLine("Opps! Role is not found");

                                if (!flag2)
                                    Console.WriteLine("Opps! Employee is not found");
                            }
                            catch (FormatException ex1)
                            {
                                Console.WriteLine("Please enter the Numeric value only");
                            }

                            catch (StackOverflowException ex2)
                            {
                                Console.WriteLine("Enter only the single digit value");
                            }
                            catch (Exception ex3)
                            {
                                Console.Write(ex3.ToString());
                            }

                            break;

                        default:
                            break;
                    }
                }

                while (i <= 10);
                Console.ReadLine();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }

}
