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
            for (int i = 0; i < projectModels.Count; i++)
            {
                Console.WriteLine("\n  - Project ID = " + projectModels[i].ProjectId);
                Console.WriteLine("  - Name Of Project = " + projectModels[i].ProjectName);
                Console.WriteLine("  - Project Description : " + projectModels[i].Description);
                Console.WriteLine("  - Start date : " + projectModels[i].StartDate);
                Console.WriteLine("  - End date : " + projectModels[i].EndDate);
                
                
            }
        }

        public void ViewProjectListWithEmployees(List<ProjectModel> projectModels)
        {
            Console.WriteLine("\n- Project Details are :");
            for (int i = 0; i < projectModels.Count; i++)
            {
                Console.WriteLine("\n  - Project ID = " + projectModels[i].ProjectId);
                Console.WriteLine("  - Name Of Project = " + projectModels[i].ProjectName);
                Console.WriteLine("  - Start date : " + projectModels[i].StartDate);
                Console.WriteLine("  - End date : " + projectModels[i].EndDate);
                Console.WriteLine("    - Employees Working on : ");
                for (int j = 0; j < projectModels[i].ProjectEmployeesList.Count; j++)
                {
                    Console.WriteLine("    - " + projectModels[i].ProjectEmployeesList[j].firstName + " " + projectModels[i].ProjectEmployeesList[j].lastName);
                    Console.WriteLine("    - RoleID = " + projectModels[i].ProjectEmployeesList[j].role.roleId);
                    Console.WriteLine("      - Role = " + projectModels[i].ProjectEmployeesList[j].role.roleName);
                    /*for (int k = 0; k< projectModels[i].ProjectEmployeesList[j].role.roleNames.Count; k++)
                    {
                        Console.WriteLine("     -  Role = " + projectModels[i].ProjectEmployeesList[j].role.roleNames[k]);
                    }*/

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

       public void AddEmployeeToProject()
        {
            try
            {
                Console.WriteLine("Enter the Project-Name :");
                string pname = Console.ReadLine();

                Console.WriteLine("Enter the Employee-ID :");
                int eid = Convert.ToInt32(Console.ReadLine());

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
        }

    }
}
