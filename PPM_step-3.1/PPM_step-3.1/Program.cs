using System;
using System.Collections.Generic;
using BusinessLogic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace PPM_step_3._1
{
    public class Program
    {
       
        static void Main(string[] args)
        {
            int i = 0;
            int inputNo = 0;
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
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("\n - Enter the value with respective following operations : ");
                    Console.WriteLine("1. Project Module");
                    Console.WriteLine("2. Role Module");
                    Console.WriteLine("3. Employees Module");
                    Console.WriteLine("4. Save ");
                    Console.WriteLine("5. Quit ");

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
                            //Project Modules
                            projectConsoleUI.ProjectInputModule(ref inputNo);
                            switch (inputNo)
                            {
                                case 1://Add
                                    int no = 0;
                                    do
                                    {
                                        Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.WriteLine("\n Choose the Operation");
                                        Console.WriteLine("1. Add a Project");
                                        Console.WriteLine("2. Add an employee to project with role.");
                                        Console.WriteLine("3. Add an employee to project (in DB).");
                                        Console.WriteLine("4. Back");
                                        no = int.Parse(Console.ReadLine());
                                        switch (no)
                                        {
                                            case 1://Add Project
                                                ProjectModel project ;
                                                project = projectConsoleUI.InputProject();
                                                if (projectBL.Validation(project))
                                                {
                                                    projectBL.AddProject(project);
                                                    Console.WriteLine("Project is Added Successfully!");
                                                }
                                                else
                                                {
                                                    Console.WriteLine(" Opps! Operation Fails \n You might be enter existing project or miss something in Project \n Please try again");
                                                }

                                                break;
                                            case 2: //Add an employee to project with role
                                                Console.WriteLine("Enter the Project-ID :");
                                                int pid = Convert.ToInt32(Console.ReadLine());
                                                if (projectBL.IsProjectExist(pid))
                                                {
                                                    Console.WriteLine("Enter the Employee-ID :");
                                                    int eid2 = Convert.ToInt32(Console.ReadLine());
                                                    if (employeeBL.IsEmployeeExist(eid2))
                                                    {
                                                        EmployeeModel emp = employeeBL.GetEmployee(eid2);
                                                        projectBL.AddEmployeeToProject(pid, emp);
                                                        Console.WriteLine("Employee Added Successfully!\n");
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

                                            case 3: //Add an employee to project with role in db
                                                Console.WriteLine("Enter the Project-ID :");
                                                int pid1 = Convert.ToInt32(Console.ReadLine());
                                                if (projectBL.IsProjectExistInDB(pid1))
                                                {
                                                    Console.WriteLine("Enter the Employee-ID :");
                                                    int eid1 = Convert.ToInt32(Console.ReadLine());
                                                    if (employeeBL.IsEmployeeExistInDB(eid1))
                                                    {
                                                        employeeBL.AddEmployeeToProjectIntoDB(pid1, eid1);
                                                        Console.WriteLine("Employee Added Successfully!\n");

                                                       

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
                                            



                                            default:
                                                break;
                                        }
                                    }
                                    while (no < 4);
                                    break;

                                case 2://List All
                                    int no2 = 0;
                                    do
                                    {
                                        Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.WriteLine("\n Choose the Operation");
                                        Console.WriteLine("1. View Projects");
                                        Console.WriteLine("2. View Projects with Employees and roles(in DB).");
                                        Console.WriteLine("3. View all");
                                        Console.WriteLine("4. Back");
                                        no2 = int.Parse(Console.ReadLine());

                                        switch (no2)
                                        {
                                            case 1:
                                                projectConsoleUI.ViewProjectListWithEmployees(projectBL.GetProject());
                                                Console.WriteLine("\n\n Data from DB \n");
                                                projectBL.GetAllFromDB();
                                                break;

                                            case 2:
                                                Console.WriteLine("\n Project Details\n");
                                                Console.WriteLine("\n Project With Employees");
                                                projectBL.GetEmployeeWithProjectsFromDB();
                                                Console.WriteLine("\n Employees With Roles");
                                                projectBL.GetEmployeeWithRoleFromDB();
                                                break;

                                            case 3:
                                                projectConsoleUI.ViewProjectListWithEmployees(projectBL.GetProject());
                                                Console.WriteLine("\n\n Data from DB \n");
                                                projectBL.GetAllFromDB();
                  
                                                Console.WriteLine("\n Project Details\n");
                                                Console.WriteLine("\n Project With Employees");
                                                projectBL.GetEmployeeWithProjectsFromDB();
                                                Console.WriteLine("\n Employees With Roles");
                                                projectBL.GetEmployeeWithRoleFromDB();

                                                break;

                                            default:
                                                break;
                                        }
                                    }
                                    while (no2 < 4);

                                    break;

                                case 3://List By Id
                                    Console.WriteLine("Enter The Project Id ");
                                    int View_pid = int.Parse(Console.ReadLine());
                                    if (projectBL.IsProjectExist(View_pid))
                                    {
                                        ProjectModel ViewProject = projectBL.GetProject(View_pid);
                                        projectConsoleUI.ViewProject(ViewProject);
                                    }
                                    else
                                        Console.Write("Opps! Project is not found");

                                    Console.WriteLine("\n\n Data from DB \n");
                                    projectBL.GetAllFromDB(View_pid);

                                    break;

                                case 4://Delete
                                    int no3 = 0;
                                    do
                                    {
                                        Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                        Console.WriteLine("\n Choose the Operation");
                                        Console.WriteLine("1. Delete Project");
                                        Console.WriteLine("2. Delete Project with Employees and Role");
                                        Console.WriteLine("3. Back");
                                        no3 = int.Parse(Console.ReadLine());
                                        switch (no3)
                                        {
                                            case 1://Delete Project
                                                Console.WriteLine("Enter the Project ID, That you want to delete");
                                                int Delete_pid = int.Parse(Console.ReadLine());
                                                if (projectBL.IsProjectExist(Delete_pid))
                                                {
                                                    ProjectModel DeleteProject = projectBL.GetProject(Delete_pid);
                                                    projectBL.DeleteProject(DeleteProject);
                                                    Console.WriteLine("Project is Deleted Successfully!");

                                                }
                                                else
                                                    Console.WriteLine(" Oops! ProjectID is not Found");

                                                employeeBL.DeleteEmployeeFromDB(Delete_pid);
                                                break;

                                            case 2: //Delete Project with Employees and Role
                                                int no5 = 0;
                                                do
                                                {
                                                    Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                                    Console.WriteLine("\n Choose the Operation");
                                                    Console.WriteLine("1. Remove Employee From Project ");
                                                    Console.WriteLine("2. Remove the Role From Employee ");
                                                    Console.WriteLine("3. Remove the Employee From All Project ");
                                                    Console.WriteLine("4. Remove the Role From All Employee ");
                                                    Console.WriteLine("5. Remove All Employees from the Project");
                                                    Console.WriteLine("6. Back");
                                                    no5 = int.Parse(Console.ReadLine());
                                                    switch (no5)
                                                    {
                                                        case 1:
                                                            Console.WriteLine("enter the Project ID");
                                                            int pid = int.Parse(Console.ReadLine());
                                                            Console.WriteLine("enter the Employee ID");
                                                            int eid = int.Parse(Console.ReadLine());
                                                            projectBL.DeleteEmployeeFromProjectInDB(pid, eid);

                                                            break;

                                                        case 2:
                                                            Console.WriteLine("enter the Employee ID");
                                                            int eid1 = int.Parse(Console.ReadLine());
                                                            Console.WriteLine("enter the Role ID");
                                                            int rid = int.Parse(Console.ReadLine());
                                                            projectBL.DeleteRoleFromEmployeesInDB(eid1, rid);

                                                            break;

                                                        case 3:
                                                            Console.WriteLine("enter the Employee ID");
                                                            int rid1 = int.Parse(Console.ReadLine());
                                                            projectBL.DeleteEmployeesFromAllProjectsInDB(rid1);
                                                            break;

                                                        case 4:
                                                            Console.WriteLine("enter the Role ID");
                                                            int eid2 = int.Parse(Console.ReadLine());
                                                            projectBL.DeleteRoleFromAllEmployeesInDB(eid2);
                                                            break;

                                                        case 5:
                                                            Console.WriteLine("enter the Project ID");
                                                            int pid1 = int.Parse(Console.ReadLine());
                                                            projectBL.DeleteWholeProjectInDB(pid1);
                                                            break;

                                                        default:
                                                            break;
                                                    }
                                                } while (no5 < 6);
                                                break;
                                        }
                                    } while (no3 < 3);
                                    break;

                                case 5://Update Project

                                    Console.WriteLine("\nEnter the Project ID (Only DB value)");
                                    int Update_pid = int.Parse(Console.ReadLine());
                                    if (projectBL.IsProjectExistInDB(Update_pid))
                                    {
                                        ProjectModel p = projectConsoleUI.UpdateProject(Update_pid);

                                        projectBL.UpdateProjectFromDB(p);
                                        Console.WriteLine("Project is Updated Successfully!");

                                    }
                                    else
                                        Console.WriteLine(" Oops! ProjectID is not Found");

                                    break;

                                default ://Return To Main 

                                    break;

                            }
                            Console.WriteLine();
                            break;

                        case 2:
                            //Role Modules 
                            do
                            {
                                
                                roleConsoleUI.RoleInputModule(ref inputNo);
                                switch (inputNo)
                                {
                                    case 1://Add
                                        RoleModel role = roleConsoleUI.InputRole();
                                        if (roleBL.Validation(role))
                                        {
                                            roleBL.AddRole(role);
                                            Console.WriteLine("Role is Added Successfully!");
                                        }
                                        else
                                        {
                                            Console.WriteLine(" Opps! Operation Fails \n You might be enter existing Role or miss something in Role \n Please try again");
                                        }
                                        break;

                                    case 2://List All
                                        roleConsoleUI.ViewAllRole(roleBL.GetRole());
                                        Console.WriteLine("\n\n Data from DB \n");
                                        roleBL.GetRoleFromDB();

                                       
                                        break;

                                    case 3://List By Id
                                        Console.WriteLine("\nEnter The Role Id ");
                                        int View_rid = int.Parse(Console.ReadLine());
                                        if (roleBL.IsRoleExist(View_rid))
                                        {
                                            RoleModel ViewRole = roleBL.GetRole(View_rid);
                                            roleConsoleUI.ViewRole(ViewRole);
                                        }
                                        else
                                            Console.Write("Opps! Role is not found");

                                        Console.WriteLine("\n\n Data from DB \n");
                                        roleBL.GetRoleFromDB(View_rid);

                                        break;

                                    case 4://Delete
                                        Console.WriteLine("\nEnter the Role ID, That you want to delete");
                                        int Delete_rid = int.Parse(Console.ReadLine());
                                        roleBL.DeleteRole(Delete_rid);

                                        if (roleBL.IsRoleExist(Delete_rid))
                                        {
                                            int indexOfAssignRoleToEmp = -1;
                                            RoleModel dummyRole = roleBL.GetRole(Delete_rid);
                                            bool flag = false;

                                            if (employeeBL.IsEmployeeRoleExist(Delete_rid, ref indexOfAssignRoleToEmp))
                                                flag = true;

                                            if (flag)
                                            {
                                                Console.WriteLine("  Warning! Role is Assign to an Employee\n");
                                                Console.WriteLine("1. For Continue");
                                                Console.WriteLine("2. For Cancel");
                                                int uno = int.Parse(Console.ReadLine());
                                                switch (uno)
                                                {
                                                    case 1:
                                                        roleBL.DeleteRole(dummyRole);
                                                        employeeBL.DeleteRoleOfEmployee(indexOfAssignRoleToEmp);
                                                        Console.WriteLine("Role is Deleted Successfully!");
                                                        break;

                                                    default:
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                roleBL.DeleteRole(dummyRole);
                                                Console.WriteLine("Role is Deleted Successfully!");
                                            }

                                        }
                                        else
                                            Console.WriteLine(" Oops! Role ID is not Found");


                                        Console.WriteLine("Role is Deleted Successfully!");
                                        break;

                                    case 5://Update
                                        Console.WriteLine("Enter the Role Id");
                                        int rid = int.Parse(Console.ReadLine());
                                        if (roleBL.IsRoleExistInDB(rid))
                                        {
                                            Console.WriteLine("Enter the Role Name");
                                            string rName = Console.ReadLine();
                                            roleBL.UpdateRole(rid, rName);
                                            Console.WriteLine("Role is Updated Successfully!");
                                        }
                                        else
                                            Console.WriteLine(" Oops! Role is not found");

                                        break;

                                    default://Return To Main 

                                        break;
                                }
                            } while (inputNo < 6);
 
                            break;

                        case 3: // Employee Modules
                            do
                            {
                                
                                employeeConsoleUI.EmployeeInputModule(ref inputNo);
                                switch (inputNo)
                                {
                                    case 1://Add
                                        int no2 = 0;
                                        do
                                        {
                                            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                            Console.WriteLine("\n Choose the Operation");
                                            Console.WriteLine(" 1. Add Employee");
                                            Console.WriteLine(" 2. Assign Role to Employee");
                                            Console.WriteLine(" 3. Assign Role to Employee (in DB)");
                                            Console.WriteLine(" 4. Back");
                                            no2 = int.Parse(Console.ReadLine());
                                            switch (no2)
                                            {
                                                case 1: // Add Employee
                                                    EmployeeModel employee = employeeConsoleUI.InputEmployee();
                                                    if (employeeBL.Validation(employee))
                                                    {
                                                        employeeBL.AddEmployee(employee);
                                                        Console.WriteLine("Employee is Added Successfully!");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine(" Opps! Operation Fails \n You might be enter existing Employee or miss something in Employee \n Please try again");
                                                    }

                                                    break;

                                                case 2: // Assign Role to Employee
                                                    Console.WriteLine("\nEnter the Employee-ID : ");
                                                    int eid2 = Convert.ToInt32(Console.ReadLine());
                                                    if (employeeBL.IsEmployeeExist(eid2))
                                                    {
                                                        Console.WriteLine("Enter the Role-ID : ");
                                                        int rid = Convert.ToInt32(Console.ReadLine());
                                                        if (roleBL.IsRoleExist(rid))
                                                        {
                                                            RoleModel role;
                                                            role = roleBL.GetRole(rid);
                                                            employeeBL.AssignRoleToEmployee(eid2, role);
                                                            Console.WriteLine(" Role Added Successfully!");
                                                        }
                                                        else
                                                            Console.WriteLine(" Oops! RoleId is not found");
                                                    }
                                                    else
                                                        Console.WriteLine(" Oops! EmployeeId is not found");

                                                    break;

                                                case 3: //Assign Role to Employee in db
                                                    Console.WriteLine("\nEnter the Employee-ID : ");
                                                    int eid = Convert.ToInt32(Console.ReadLine());
                                                    if (employeeBL.IsEmployeeExistInDB(eid))
                                                    {
                                                        Console.WriteLine("Enter the Role-ID : ");
                                                        int rid1 = Convert.ToInt32(Console.ReadLine());
                                                        if (roleBL.IsRoleExistInDB(rid1))
                                                        {
                                                            employeeBL.AssignRoleToEmployeeIntoDB(eid, rid1);
                                                            Console.WriteLine("Role Assign Successfully!\n");
                                                        }
                                                        else
                                                            Console.WriteLine(" Oops! RoleId is not found");
                                                    }
                                                    else
                                                        Console.WriteLine(" Oops! Employee is not exist ");

                                                    break;

                                                default://Back
                                                    break;

                                            }
                                            
                                            
                                        } while (no2 < 4);
                                        break;

                                    case 2://List All
                                        employeeConsoleUI.ViewEmployeeList(employeeBL.GetEmployee());
                                        Console.WriteLine("\n\n Data from DB \n");
                                        employeeBL.ViewAllFromDB();

                                        Console.WriteLine("\n Employees With Roles");
                                        projectBL.GetEmployeeWithRoleFromDB();

                                        break;

                                    case 3://List By Id
                                        Console.WriteLine("Enter The Employee Id ");
                                        int View_eid = int.Parse(Console.ReadLine());
                                        if (employeeBL.IsEmployeeExist(View_eid))
                                        {
                                            EmployeeModel ViewEmployee = employeeBL.GetEmployee(View_eid);
                                            employeeConsoleUI.ViewEmployee(ViewEmployee);
                                        }
                                        else
                                            Console.Write("Opps! Employee ID is not found");

                                        Console.WriteLine("\n\n Data from DB \n");
                                        employeeBL.ViewAllFromDB(View_eid);

                                        break;

                                    case 4://Delete
                                        Console.WriteLine("Enter the Employee ID, That you want to delete");
                                        int Delete_eid = int.Parse(Console.ReadLine());
                                        employeeBL.DeleteEmployeeFromDB(Delete_eid);

                                        if (employeeBL.IsEmployeeExist(Delete_eid))
                                        {
                                            EmployeeModel dummyEmployee = employeeBL.GetEmployee(Delete_eid);
                                            bool flag = false;
                                            int projectIndex = -1;
                                            int employeeIndex = -1;
                                            if (projectBL.IsProjectEmployeeExist(Delete_eid, ref projectIndex, ref employeeIndex))
                                                flag = true;

                                            if (flag)
                                            {
                                                Console.WriteLine("  Warning! Employee is Assign to an Project\n");
                                                Console.WriteLine("1. For Continue");
                                                Console.WriteLine("2. For Cancel");
                                                int uno = int.Parse(Console.ReadLine());
                                                switch (uno)
                                                {
                                                    case 1:
                                                        employeeBL.DeleteEmployee(dummyEmployee);
                                                        do
                                                        {
                                                            projectBL.DeleteEmployeeFromProjectList(projectIndex, employeeIndex);
                                                        }
                                                        while (projectBL.IsProjectEmployeeExist(Delete_eid, ref projectIndex, ref employeeIndex));

                                                        Console.WriteLine("Employee is Deleted Successfully!");
                                                        break;

                                                    default:
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                employeeBL.DeleteEmployee(dummyEmployee);
                                                Console.WriteLine("Employee is Deleted Successfully!");
                                            }

                                        }
                                        else
                                            Console.WriteLine(" Oops! Employee ID is not Found");


                                        break;

                                    case 5: //Update
                                        Console.WriteLine("Enter the Employee ID");
                                        int Update_eid = int.Parse(Console.ReadLine());
                                        if (employeeBL.IsEmployeeExistInDB(Update_eid))
                                        {
                                            EmployeeModel emp = employeeConsoleUI.UpdateEmployee(Update_eid);
                                            employeeBL.UpdateEmployee(emp);
                                        }
                                        else
                                            Console.WriteLine(" Oops! Employee is not found");


                                        break;

                                    default://Return to main menu
                                        break;
                                }
                            } while (inputNo < 6);
                            break;



                        case 4: //Store Data 
                            int no1 = 0;
                            do
                            {
                                Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                Console.WriteLine("\n Choose the Operation");
                                Console.WriteLine("1. File");
                                Console.WriteLine("2. DB-ADO.NET");
                                Console.WriteLine("3. DB-EF");
                                Console.WriteLine("4. Return To main");
                                no1 = int.Parse(Console.ReadLine());
                                switch (no1)
                                {
                                    case 1:
                                        // FOR STORING INTO FILE
                                        projectBL.SaveIntoFile();
                                        employeeBL.SaveIntoFile();
                                        roleBL.SaveIntoFile();
                                        Console.WriteLine("Data is Stored in file Successfully!");
                                        break;


                                    case 2://save app data using DB-ADO.NET


                                        try
                                        {
                                            List<RoleModel> roles = roleBL.GetRole();
                                            for (int j = 0; j < roles.Count; j++)
                                            {
                                                Console.WriteLine(j);
                                                roleBL.SaveIntoDB_ADO(roles[j]);
                                            }
                                            roleBL.DeleteAllRecord();
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }


                                        try
                                        {
                                            List<EmployeeModel> employees = employeeBL.GetEmployee();
                                            for (int j = 0; j < employees.Count; j++)
                                            {
                                                employeeBL.SaveIntoDB(employees[j]);
                                            }
                                            employeeBL.DeleteAllRecord();
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }

                                        try
                                        {
                                            List<ProjectModel> projects = projectBL.GetProject();
                                            for (int j = 0; j < projects.Count; j++)
                                            {
                                                projectBL.SaveIntoDB_ADO(projects[j]);


                                            }
                                            projectBL.DeleteAllRecord();
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }


                                        break;

                                   
                                       

                                    case 3:// save app data using EF

                                        try
                                        {
                                            List<RoleModel> roles1 = roleBL.GetRole();
                                            for (int j = 0; j < roles1.Count; j++)
                                            {
                                                Console.WriteLine(j);
                                                roleBL.SaveRoleUsingEF(roles1[j]);
                                            }
                                            roleBL.DeleteAllRecord();
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }

                                        
                                        try
                                        {

                                            List<EmployeeModel> employees = employeeBL.GetEmployee();
                                            for (int j = 0; j < employees.Count; j++)
                                            {
                                                employeeBL.SaveEmployeeUsingEF(employees[j]);
                                            }
                                            employeeBL.DeleteAllRecord();
                                        }
                                        
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                            Console.WriteLine(ex.InnerException.Message);
                                        }
                                        

                                        try
                                        {
                                            List<ProjectModel> projects = projectBL.GetProject();
                                            for (int j = 0; j < projects.Count; j++)
                                            {
                                                projectBL.SaveProjectUsingEF(projects[j]);
                                               
                                            }
                                            projectBL.DeleteAllRecord();
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                            Console.WriteLine(ex.InnerException.Message);
                                        }
                                       // employeeBL.SaveEmployeeUsingEF();

                                        break;


                                 




                                    default: //Return To Main

                                        break;

                                }
                            } while (no1 < 5);
                        
                            break;


                        // Exist 
                        default:

                            break;

                    }
                }

                while (i <= 4);
                Console.ReadLine();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
    
}
