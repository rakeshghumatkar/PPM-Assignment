using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prolifics_Project_Manager_PPM_
{
    internal class Program
    {
         static string[] projectName = new string[3];
         static string[] employeeName = new string[3];
         static string[] roleName = new string[3];
         static int project_count = -1, employee_count = -1, roles_count = -1;

        void addProject()
        {
            if (project_count < projectName.Length-1)
            {
                try
                {
                    project_count = project_count + 1;
                    Console.WriteLine("Enter the project name : ");
                    string pname = Console.ReadLine();
                    projectName[project_count] = pname;

                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Please! Enter the valid input");
                }
               

            }

            else
                Console.WriteLine("Sorry! Project array is full");
        }

         void addEmployee()
        {
            if (employee_count < employeeName.Length -1)
            {
                try
                {
                    employee_count = employee_count + 1;
                    Console.WriteLine("Enter the employee name : ");
                    string ename = Console.ReadLine();
                    employeeName[employee_count] = ename;

                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Please! Enter the valid input");
                }


            }

            else
                Console.WriteLine("Sorry! Employees array is full");

        }

         void addRole()
        {
            if (roles_count < roleName.Length-1)
            {
                try
                {
                    roles_count = roles_count + 1;
                    Console.WriteLine("Enter the role name : ");
                    string rname = Console.ReadLine();
                    roleName[roles_count] = rname;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Please! Enter the valid input");
                }

            }

            else
                Console.WriteLine("Sorry! Roles array is full");

        }

         void viewProjects()
        {
            for (int i = 0; i <= project_count; i++)
            {
                string pname = projectName[i];
                Console.WriteLine(pname);
            }
        }

         void viewEmployees()
        {
            for (int i = 0; i <= employee_count; i++)
            {
                string ename = employeeName[i];
                Console.WriteLine(ename);
            }
        }
         void viewRoles()
        {
            for (int i = 0; i <= roles_count; i++)
            {
                string rname = roleName[i];
                Console.WriteLine(rname);
            }
        }


        static void Main(string[] args)
        {

            int i=0;
            do
            {
                Console.WriteLine("Enter the value with respective following operations : ");
                Console.WriteLine("1. Add Project");
                Console.WriteLine("2. View Projects");
                Console.WriteLine("3. Add Employees");
                Console.WriteLine("4. View Employees");
                Console.WriteLine("5. Add Role");
                Console.WriteLine("6. View Roles");
                Console.WriteLine("7. Quit");
                try
                {
                    i = Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException ex1)
                {
                    Console.WriteLine("Please! Enter the numeric value only");
                }
                catch (OverflowException ex2)
                {
                    Console.WriteLine(ex2.Message);
                }
                
                Program program = new Program();
                switch (i)
                {
                    case 1:
                        program.addProject();
                        Console.WriteLine();
                        break;

                    case 2:
                        Console.WriteLine(" Project list : ");
                        program.viewProjects();
                        Console.WriteLine();
                        break;

                    case 3:

                        program.addEmployee();
                        Console.WriteLine();
                        break;

                    case 4:
                        Console.WriteLine(" Employees list : ");
                        program.viewEmployees();
                        Console.WriteLine();
                        break;

                    case 5:
                        program.addRole();
                        Console.WriteLine();
                        break;

                    case 6:
                        Console.WriteLine(" Roles list : ");
                        program.viewRoles();
                        Console.WriteLine();
                        break;

                    default:
                        break;
                }
            }
            while (i <= 6);
            Console.ReadLine();
        }
    }
}
