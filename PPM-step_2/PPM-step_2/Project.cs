using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPM_step_2
{
    class Project
    {
        public string projectName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public string description { get; set; }

        public List<Employee> projectEmployees = new List<Employee>();

        public Project()
        { }

        public Project(string projectName, DateTime startDate, DateTime endDate, string description)
        {
            this.projectName = projectName;
            this.startDate = startDate;
            this.endDate = endDate;
            this.description = description;
        }


        public void InputProject()
        {
            Console.WriteLine("Enter the Project Name : ");
            projectName = Console.ReadLine();

            Console.WriteLine("Enter the Project Description : ");
            description = Console.ReadLine();


            Console.WriteLine("Enter the start date in project");
            Console.WriteLine("Enter year");
            int yy1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter month");
            int mm1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter day");
            int dd1 = Convert.ToInt32(Console.ReadLine());

            startDate = DateTime.Parse($"{yy1}-{mm1}-{dd1}");

            Console.WriteLine("Enter the end date in project");
            Console.WriteLine("Enter year");
            int yy2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter month");
            int mm2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter day");
            int dd2 = Convert.ToInt32(Console.ReadLine());

            endDate = DateTime.Parse($"{yy2}-{mm2}-{dd2}");

        }

        public void ViewProject()
        {
            Console.WriteLine("  - Project Name : " + projectName);
            Console.WriteLine("  - Project Description : " + description);
            Console.WriteLine("  - Start date : " + startDate);
            Console.WriteLine("  - End date : " + endDate);
            Console.WriteLine();
        }

        /* public void addEmployee()
         {
             *//*Console.Write(" Enter the Employee ID : ");
             int eid = Convert.ToInt32(Console.ReadLine());*//*
             Employee employee = new Employee();
             Project_employees.Add(employee);
         }*/

        public void AddEmployeeRole(int eid)
        {


            bool flag = false;
            eid = Convert.ToInt32(Console.ReadLine());


            for (int i = 0; i < projectEmployees.Count; i++)
            {
                if (projectEmployees[i].empolyeeId == eid)
                {
                    projectEmployees[i].AddRoles();
                    flag = true;
                }
            }
            if (flag == false)
                Console.WriteLine("Opps! Employee not found ");

        }


        public void ShowAllEmployees()
        {
            Console.WriteLine(" Working employees under the project are : ");
            for (int i = 0; i < projectEmployees.Count; i++)
            {
                Employee emp = projectEmployees[i];
                Console.WriteLine(" - " + emp.firstName + " " + emp.lastName);

                //View role
                for (int j = 0; j < Program.roleList.Count; j++)
                {
                    if (projectEmployees[i].roleId == Program.roleList[j].roleId)
                    {
                        Program.roleList[j].ViewRole();
                    }
                }


            }
        }

        public void DeleteEmployee(int empid)
        {
            bool flag = false;
            for (int i = 0; i < projectEmployees.Count; i++)
            {
                Employee emp = projectEmployees[i];
                if (emp.empolyeeId == empid)
                {
                    projectEmployees.RemoveAt(i);
                    flag = true;
                    break;

                }
            }
            if (flag == false)
                Console.WriteLine("Employee is not found!");

        }


        public void ViewEmployeeById(int empid)
        {
            bool flag = false;
            for (int i = 0; i < projectEmployees.Count; i++)
            {
                Employee emp = projectEmployees[i];
                if (emp.empolyeeId == empid)
                {
                    emp.ShowEmployeeDetails();
                    flag = true;
                    break;

                }
                if (flag == false)
                    Console.WriteLine("Employee is not found!");


            }


        }
    }
}
