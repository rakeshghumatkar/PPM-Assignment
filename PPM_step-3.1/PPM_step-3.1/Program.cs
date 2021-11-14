using System;
using System.Collections.Generic;
using BusinessLogic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPM_step_3._1
{
    public class Program
    {
       
        static void Main(string[] args)
        {
            int i = 0;
            ProjectConsoleUI projectConsoleUI = new ProjectConsoleUI();
            ProjectBL projectBL = new ProjectBL();
            EmployeeConsoleUI employeeConsoleUI = new EmployeeConsoleUI();
            EmployeeBL employeeBL = new EmployeeBL();
            RoleConsoleUI roleConsoleUI = new RoleConsoleUI();
            RoleBL roleBL = new RoleBL();
            try
            {
                do
                {
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("\n - Enter the value with respective following operations : ");
                    Console.WriteLine("1. Add Project");
                    Console.WriteLine("2. View Projects");
                    Console.WriteLine("3. Add Role");
                    Console.WriteLine("4. View Roles");
                    Console.WriteLine("5. Add Employees ");
                    Console.WriteLine("6. View Employees");
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
                        Console.WriteLine(ex1.Message);
                    }

                    catch (StackOverflowException ex2)
                    {
                        Console.WriteLine("Enter only the single digit value");
                        Console.WriteLine(ex2.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.ToString());
                    }


                    switch (i)
                    {
                        case 1:
                            //Add project

                            projectBL.AddProject(projectConsoleUI.InputProject());
                            
                            Console.WriteLine();
                            break;

                        case 2:
                            //view projects 
                            
                            projectConsoleUI.ViewProjectList(projectBL.ReturnProjectList());

                            Console.WriteLine();
                            break;

                        case 3:
                            //Add role 
                            roleBL.AddRole(roleConsoleUI.InputRole());
                            Console.WriteLine();
                            break;

                        case 4:
                            //View roles of employee
                            roleConsoleUI.ViewRole(roleBL.ReturnRoleList());
                            Console.WriteLine();
                            break;

                        case 5:
                            //Add Employee
                            employeeBL.AddEmployee(employeeConsoleUI.InputEmployee());
                            Console.WriteLine();
                            break;

                        case 6:
                            //View employees
                            employeeConsoleUI.ViewEmployeeList(employeeBL.ReturnEmployeeList());
                            Console.WriteLine();
                            break;

                        case 7:
                            //Add employee to project
                            Console.WriteLine("Enter the Project-ID :");
                            int pid = Convert.ToInt32(Console.ReadLine());
                            if (projectBL.IsProject(pid))
                            {
                                Console.WriteLine("Enter the Employee-ID :");
                                int eid = Convert.ToInt32(Console.ReadLine());
                                if (employeeBL.IsEmployee(eid))
                                {
                                    EmployeeModel emp = employeeBL.GetEmployeeById(eid);
                                    projectBL.AddEmployeeToProject(pid, emp);
                                    Console.WriteLine("Employee Added Successfully!");
                                }
                                else
                                {
                                    Console.WriteLine(" Oops! EmployeeID is not Found");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine(" Oops! ProjectID is not Found");
                                break;
                            }
                            
                            break;


                        case 8:
                            //Delete Employee from project
                            Console.WriteLine("Enter the Project-Name :");
                            int pid1 = Convert.ToInt32(Console.ReadLine());
                            if (projectBL.IsProject(pid1))
                            {
                                Console.WriteLine("Enter the Employee-ID :");
                                int eid1 = Convert.ToInt32(Console.ReadLine());
                                if (employeeBL.IsEmployee(eid1))
                                {
                                    EmployeeModel emp = employeeBL.GetEmployeeById(eid1);
                                    projectBL.DeleteEmployeeToProject(pid1, emp);
                                    Console.WriteLine("Employee Added Successfully!");
                                }
                                else
                                {
                                    Console.WriteLine(" Oops! EmployeeID is not Found");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine(" Oops! Project is not Found");
                                break;
                            }

                            break;

                        case 9:
                            //View Project Detail(Project Details and List of employees by role)
                            projectConsoleUI.ViewProjectListWithEmployees(projectBL.ReturnProjectList());

                            break;


                        case 10:
                            //Assign Roles to Employees

                            Console.WriteLine("Enter the employee ID : ");
                            int eid2 = Convert.ToInt32(Console.ReadLine());

                            if(employeeBL.IsEmployee(eid2))
                            {
                                Console.WriteLine("Enter the Role-ID : ");
                                int rid = Convert.ToInt32(Console.ReadLine());

                                if (roleBL.IsRole(rid))
                                {
                                    RoleModel role;
                                    role = roleBL.GetRoleById(rid);  
                                    employeeBL.AssignRoleToEmployee(eid2, role);
                                }
                                else
                                    Console.WriteLine(" Oops! RoleId is not found");
                            }
                            else
                                Console.WriteLine(" Oops! EmployeeId is not found");


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
