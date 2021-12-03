using PPM_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPM_DAL_EF;

namespace BusinessLogic
{
    public class ProjectBL : IProjectOperation
    {
        public List<ProjectModel> ProjectList = new List<ProjectModel>();
        public ProjectBL()
        { }

        public void AddProject(ProjectModel projectModel)
        {
            ProjectList.Add(projectModel);

        }

        public void DeleteProject(ProjectModel projectModel)
        {
            ProjectList.Remove(projectModel);
        }

        public List<ProjectModel> GetProject()
        {
            ProjectList.Sort();
            return ProjectList;
        }
        

        public bool Validation(ProjectModel project)
        {
            if (project.ProjectId == null || project.ProjectName == "")
                return false;
            else if (ProjectList.Contains(project))
                return false;
            else if (IsProjectExist(project.ProjectId))
                return false;
            else if (IsProjectExistInDB(project.ProjectId))
                return false;
            else
                return true;
        }

        public ProjectModel GetProject(int pid)
        {
            ProjectModel DummyProject = new ProjectModel();
            for (int i = 0; i < ProjectList.Count; i++)
            {
                if (pid == ProjectList[i].ProjectId)
                {
                    DummyProject = ProjectList[i];
                    break;
                }
            }
            return DummyProject;
        }

        public bool IsProjectExist(int pid)
        {
            for (int i = 0; i < ProjectList.Count; i++)
            {
                if (pid == ProjectList[i].ProjectId)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsProjectEmployeeExist(int eid, ref int projectIndex, ref int employeeIndex)
        {
            for (int i = 0; i < ProjectList.Count; i++)
            {
                for (int j = 0; j < ProjectList[i].ProjectEmployeesList.Count; j++)
                {
                    if (eid == ProjectList[i].ProjectEmployeesList[j].empolyeeId)
                    {
                        projectIndex = i;
                        employeeIndex = j;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsProjectEmployeeExist(int eid)
        {
            for (int i = 0; i < ProjectList.Count; i++)
            {
                for (int j = 0; j < ProjectList[i].ProjectEmployeesList.Count; j++)
                {
                    if (eid == ProjectList[i].ProjectEmployeesList[j].empolyeeId)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void DeleteEmployeeFromProjectList(int projectIndex, int employeeIndex)
        {
            ProjectList[projectIndex].ProjectEmployeesList.RemoveAt(employeeIndex);
        }

        public void AddEmployeeToProject(int pid, EmployeeModel emp)
        {
            //var result = ProjectList.Select(x=> x).Where(x=>x.ProjectId.Equals(pid));
            

            
            for (int i = 0; i < ProjectList.Count; i++)
            {
                if (pid == ProjectList[i].ProjectId)
                {
                    ProjectList[i].ProjectEmployeesList.Add(emp);
                    break;
                }
            }
        }

        public void DeleteEmployeeToProject(int pid, EmployeeModel emp)
        {
            for (int i = 0; i < ProjectList.Count; i++)
            {
                if (pid == ProjectList[i].ProjectId)
                {
                    ProjectList[i].ProjectEmployeesList.Remove(emp);
                    break;
                }
            }
        }

        public void SaveIntoFile()
        {
            try
            {
                string filePath = "C:\\Users\\rakes\\source\\repos\\PPM_step-3.1\\ProjectFile.xml";
                XMLFileData data = new XMLFileData();
                data.XmlSerialize(typeof(List<ProjectModel>), ProjectList, filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SaveIntoDB_ADO(ProjectModel project)
        {
            try
            {
                ProjectsDA db = new ProjectsDA();
                db.SaveProject(project.ProjectId, project.ProjectName, project.Description, project.StartDate, project.EndDate);
                for (int i =0; i<project.ProjectEmployeesList.Count; i++)
                {
                    CommonOperation db2 = new CommonOperation();
                    string query = "insert into ProjectEmployees values ("+project.ProjectId+","+project.ProjectEmployeesList[i].empolyeeId+", CURRENT_TIMESTAMP);";
                    db2.ExcuteQuery(query);
                }

              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        

        public void DeleteAllRecord()
        {
            ProjectList.Clear();
        }

        public void GetAllFromDB()
        {
            try
            {
                ProjectsDA db = new ProjectsDA();
                string query = "Select *from Projects order by projectId;";
                db.GetProject(query);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void GetAllFromDB(int pid)
        {
            try
            {
                ProjectsDA db = new ProjectsDA();
                string query = "Select *from Projects where projectId = " + pid + ";";
                db.GetProject(query);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool IsProjectExistInDB(int pid)
        {
            bool flag = false;
            try
            {
                CommonOperation db = new CommonOperation();
                string query = "Select *from Projects where projectId = " + pid + ";";
                db.IsExist(query, ref flag);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return flag;
        }

        public void DeleteProjectFromDB(int pid)
        {
            ProjectsDA db = new ProjectsDA();
            //string query = "Select *from Employees where employeeId = " + eid + ";";
            db.DeleteProject(pid);
        }

        public void UpdateProjectFromDB(ProjectModel p)
        {
            CommonOperation db = new CommonOperation();
            string query = "update Projects set projectName = '"+p.ProjectName+"', pdescription = '"+p.Description+"', startDate = '"+p.StartDate+"', endDate = '"+p.EndDate+"',modifiedDate= CURRENT_TIMESTAMP where projectId = "+p.ProjectId+";";
            db.ExcuteQuery(query);
           
        }

        public void GetEmployeeWithRoleFromDB()
        {
            try
            {
                ProjectsDA db = new ProjectsDA();
                string query = "SELECT Employees.employeeId, Employees.firstName, Employees.lastName, Roles.roleId, Roles.roleName FROM Employees INNER JOIN Roles ON Employees.roleId = Roles.roleId; ";
                db.GetEmployeeWithRole(query);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void GetEmployeeWithProjectsFromDB()
        {
            try
            {
                ProjectsDA db = new ProjectsDA();
                string query = "SELECT Projects.projectId, Projects.projectName, Employees.employeeId, Employees.firstName, Employees.lastName FROM((ProjectEmployees INNER JOIN Projects ON ProjectEmployees.projectId = Projects.projectId) INNer JOIN Employees ON ProjectEmployees.employeeId = Employees.employeeId); ";
                db.GetProjectWithEmployees(query);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void GetProjectsWithEmployeesAndRolesFromDB()
        {
            try
            {
                ProjectsDA db = new ProjectsDA();
                string query = "SELECT Projects.projectId, Projects.projectName, Employees.employeeId, Employees.firstName, Employees.lastName FROM(( ProjectEmployees INNER JOIN Projects ON ProjectEmployees.projectId = Projects.projectId) INNER JOIN Employees ON ProjectEmployees.employeeId = Employees.employeeId);";
                db.GetProjectsWithEmployeesAndRoles(query);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        public void DeleteEmployeeFromProjectInDB(int pid, int eid)
        {
            CommonOperation db = new CommonOperation();
            string query = "delete from ProjectEmployee where employeeId ="+eid+" and projectId="+pid+";";
            db.ExcuteQuery(query);
        }

        public void DeleteRoleFromEmployeesInDB(int eid, int rid)
        {
            CommonOperation db = new CommonOperation();
            string query = "update from Employees set roleID = Null where employeeId = "+eid+" and roleID =" + rid + ";";
            db.ExcuteQuery(query);
        }

        public void DeleteEmployeesFromAllProjectsInDB(int eid)
        {
            CommonOperation db = new CommonOperation();
            string query = "delete from ProjectEmployees where employeeId ="+eid+";";
            db.ExcuteQuery(query);
        }

        public void DeleteRoleFromAllEmployeesInDB(int rid)
        {
            CommonOperation db = new CommonOperation();
            string query = "update Employees set roleID = Null where roleId =" + rid + ";";
            db.ExcuteQuery(query);
        }

        public void DeleteWholeProjectInDB(int pid)
        {
            CommonOperation db = new CommonOperation();
            string query1 = "delete from ProjectEmployees where projectId =" + pid + ";";
            db.ExcuteQuery(query1);
            
        }


        public void SaveProjectUsingEF(ProjectModel p)
        {
            PPMEntities db = new PPMEntities();
            Project project = new Project();
            project.projectId = p.ProjectId;
            project.projectName = p.ProjectName;
            project.pdescription = p.Description;
            project.startDate = p.StartDate;
            project.endDate = p.EndDate;
            project.createDate = DateTime.Now;
            project.modifiedDate = DateTime.Now;
            
            db.Projects.Add(project);
            db.SaveChanges();

           
            //var EmpList = p.ProjectEmployeesList.Select(x => x);
            //foreach(var list in EmpList)
            for(int i=0; i<p.ProjectEmployeesList.Count; i++)
            {
                ProjectEmployee pm = new ProjectEmployee();
                pm.projectID = p.ProjectId;
                pm.employeeID = p.ProjectEmployeesList[i].empolyeeId;
                pm.assignDate = DateTime.Now;
                db.ProjectEmployees.Add(pm);
                db.SaveChanges();
            }


        }
       

        

    }
}
