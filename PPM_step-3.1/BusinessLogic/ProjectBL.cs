using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ProjectBL
    {
        public List<ProjectModel> ProjectList = new List<ProjectModel>();
        public ProjectBL()
        {

        }

        public void AddProject(ProjectModel projectModel)
        {
            ProjectList.Add(projectModel);
        }

        public List<ProjectModel> ReturnProjectList()
        {
            return ProjectList;
        }

        public bool IsProject(int pid)
        {
            for(int i=0; i<ProjectList.Count; i++)
            {
                if(pid == ProjectList[i].ProjectId)
                {
                    return true;
                }
            }
            return false;
        }
        public void AddEmployeeToProject(int pid, EmployeeModel emp)
        {
            for(int i=0; i<ProjectList.Count; i++)
            {
                if(pid == ProjectList[i].ProjectId)
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
    }
}
