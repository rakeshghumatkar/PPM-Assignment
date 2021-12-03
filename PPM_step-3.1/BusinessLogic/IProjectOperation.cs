using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    interface IProjectOperation
    {
        void AddProject(ProjectModel projectModel);

        void DeleteProject(ProjectModel projectModel);

        ProjectModel GetProject(int pid);

        List<ProjectModel> GetProject();
        bool IsProjectExist(int pid);

        bool IsProjectEmployeeExist(int eid);

    }
}
