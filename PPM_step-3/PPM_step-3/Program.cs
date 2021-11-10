using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPM_step_3
{
     class Program : BusinessLogic
     {
       
        

       
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
                    Console.WriteLine("3. Add Role");
                    Console.WriteLine("4. View Roles");
                    Console.WriteLine("5. Add Employees ");
                    Console.WriteLine("6. View Employees");
                    Console.WriteLine("7. Add Employee to project ");
                    Console.WriteLine("8. Delete Employee from project");
                    Console.WriteLine("9. View Project Detail (Project Details and List of employees by role) ");
                    Console.WriteLine("10. Assign Roles to Employees ");
                    Console.WriteLine("11. Quit");
                    BusinessLogic logic = new BusinessLogic();
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
                            logic.AddProjects();
                            Console.WriteLine();
                            break;

                        case 2:
                            //view projects 
                            logic.ViewProjects();
                            Console.WriteLine();
                            break;

                        case 3:
                            //Add role 
                            logic.AddRole();
                            Console.WriteLine();
                            break;

                        case 4:
                            //View roles of employee
                            logic.ViewRoles();
                            Console.WriteLine();
                            break;

                        case 5:
                            
                            //Add Employee
                            logic.AddEmployee();
                            Console.WriteLine();
                            
                            break;

                        case 6:
                            
                            //View employees
                            logic.ViewEmployees();
                            Console.WriteLine();
                            break;

                        case 7:
                            //Add employee to project
                            Console.WriteLine("Enter the Project Name ");
                            string pname = Console.ReadLine();
                            if(logic.IsProject(pname))
                            {
                                Console.WriteLine("Enter the Employee-ID ");
                                int eid = Convert.ToInt32(Console.ReadLine());
                                if(logic.IsEmployee(eid))
                                {
                                    logic.AddEmployeeToProject(pname, eid);
                                }
                            }
                            break;


                        case 8:
                            //Delete Employee from project
                            Console.WriteLine("Enter the Project Name ");
                            string pname1 = Console.ReadLine();
                            if(logic.IsProject(pname1))
                            {
                                Console.WriteLine("Enter the employee ID, Who you want to remove from the project");
                                int eid1 = Convert.ToInt32(Console.ReadLine());
                                if(logic.IsEmployee(eid1))
                                {
                                    logic.DeleteEmployeeFromProject(pname1, eid1);
                                }
                            }
                            break;

                        case 9:
                            //View Project Detail(Project Details and List of employees by role)
                            Console.WriteLine("\nProjects Detail are : ");
                            for (int j = 0; j < projectList.Count; j++)
                            {
                                Console.WriteLine("\n -Name Of Project : " + projectList[j].projectName);
                                Console.WriteLine(" Employees Detail are : ");
                                projectList[j].ShowAllEmployees();
                            }

                            break;


                        case 10:
                            //Assign Roles to Employees
                         
                            Console.WriteLine("Enter the employee ID : ");
                            int eid2 = Convert.ToInt32(Console.ReadLine());
                            if(logic.IsEmployee(eid2))
                            {
                                Console.WriteLine("Enter the Role-Id ");
                                int rid = Convert.ToInt32(Console.ReadLine());
                                if(logic.IsRole(rid))
                                {
                                    logic.AssignRoleToEmployee(eid2, rid);
                                }
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
