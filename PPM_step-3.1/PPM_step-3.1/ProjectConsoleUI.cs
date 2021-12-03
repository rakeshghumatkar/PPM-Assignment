using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPM_step_3._1
{
    public class ProjectConsoleUI
    {
        public ProjectConsoleUI()
        {
           
        }

        //Display Function
        public void ViewProjectList(List<ProjectModel> projectModels)
        {
            Console.WriteLine("\n- Project Details are :");

            var result = projectModels.Select(x => x);
            //for (int i = 0; i < projectModels.Count; i++)
            foreach(var projects in result)
            {
                Console.WriteLine("\n  - Project ID = " + projects.ProjectId);
                Console.WriteLine("  - Name Of Project = " + projects.ProjectName);
                Console.WriteLine("  - Project Description : " + projects.Description);
                Console.WriteLine("  - Start date : " + projects.StartDate);
                Console.WriteLine("  - End date : " + projects.EndDate);
                
                
            }
        }

        public void ViewProject(ProjectModel project)
        {
            Console.WriteLine("\n  - Project ID = " + project.ProjectId);
            Console.WriteLine("  - Name Of Project = " + project.ProjectName);
            Console.WriteLine("  - Project Description : " + project.Description);
            Console.WriteLine("  - Start date : " + project.StartDate);
            Console.WriteLine("  - End date : " + project.EndDate);
        }

        public void ViewProjectListWithEmployees(List<ProjectModel> projectModels)
        {
            Console.WriteLine("\n- Project Details are :");
            var result1 = projectModels.Select(x => x);
            //for (int i = 0; i < projectModels.Count; i++)
            foreach(var projects in result1)
            {
                Console.WriteLine("\n  - Project ID = " + projects.ProjectId);
                Console.WriteLine("  - Name Of Project = " + projects.ProjectName);
                Console.WriteLine("  - Start date : " + projects.StartDate);
                Console.WriteLine("  - End date : " + projects.EndDate);
                Console.WriteLine("    - Employees Working on : ");
                for (int j = 0; j < projects.ProjectEmployeesList.Count; j++)
                //var result2 = from empls in projects.ProjectEmployeesList select empls;
                //foreach(var employees in result2)
                {
                    Console.WriteLine("    - " + projects.ProjectEmployeesList[j].firstName + " " + projects.ProjectEmployeesList[j].lastName);
                    Console.WriteLine("    - RoleID = " + projects.ProjectEmployeesList[j].role.roleId);
                    Console.WriteLine("      - Role = " + projects.ProjectEmployeesList[j].role.roleName);
                   
                }

            }
        }

        //Input Function
        public ProjectModel InputProject()
        {
            ProjectModel p = new ProjectModel();
            try
            {
                Console.WriteLine("Enter the Project ID : ");
                p.ProjectId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the Project Name : ");
                p.ProjectName = Console.ReadLine();

                Console.WriteLine("Enter the Project Description : ");
                p.Description = Console.ReadLine();


                Console.WriteLine("Enter the start date in project");
                Console.WriteLine("Enter year");
                int yy1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter month");
                int mm1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter day");
                int dd1 = Convert.ToInt32(Console.ReadLine());

                p.StartDate = DateTime.Parse($"{yy1}-{mm1}-{dd1}");

                Console.WriteLine("Enter the end date in project");
                Console.WriteLine("Enter year");
                int yy2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter month");
                int mm2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter day");
                int dd2 = Convert.ToInt32(Console.ReadLine());

                p.EndDate = DateTime.Parse($"{yy2}-{mm2}-{dd2}");

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
            return p;
        }

       
        public void ProjectInputModule(ref int inputNo)
        {
            Console.WriteLine(" ~~~~~~~~~~~~~ Project Module ~~~~~~~~~~~~~ ");
            Console.WriteLine("1. Add ");
            Console.WriteLine("2. List All");
            Console.WriteLine("3. List By ID ");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Update ");
            Console.WriteLine("6. Return To Main ");
            inputNo = int.Parse(Console.ReadLine());
           
        }

        public ProjectModel UpdateProject(int pid)
        {
            ProjectModel p = new ProjectModel();
            try
            {
                p.ProjectId = pid;
                
                Console.WriteLine("Enter the Project Name : ");
                p.ProjectName = Console.ReadLine();

                Console.WriteLine("Enter the Project Description : ");
                p.Description = Console.ReadLine();


                Console.WriteLine("Enter the start date in project");
                Console.WriteLine("Enter year");
                int yy1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter month");
                int mm1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter day");
                int dd1 = Convert.ToInt32(Console.ReadLine());

                p.StartDate = DateTime.Parse($"{yy1}-{mm1}-{dd1}");

                Console.WriteLine("Enter the end date in project");
                Console.WriteLine("Enter year");
                int yy2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter month");
                int mm2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter day");
                int dd2 = Convert.ToInt32(Console.ReadLine());

                p.EndDate = DateTime.Parse($"{yy2}-{mm2}-{dd2}");

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
            return p;
        }


    }
}
