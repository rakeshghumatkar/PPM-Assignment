using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    [Serializable]
    public class ProjectModel : IComparable<ProjectModel>
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        
        public string Description { get; set; }

        public List<EmployeeModel> ProjectEmployeesList = new List<EmployeeModel>();

        public ProjectModel()
        {
        }

        public ProjectModel(int ProjectId,string projectName, DateTime startDate, DateTime endDate, string description)
        {
            this.ProjectId = ProjectId;
            this.ProjectName = projectName;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Description = description;
        }

        public int CompareTo(ProjectModel other)
        {
            if (this.ProjectId > other.ProjectId)
                return 1;
            else if (this.ProjectId < other.ProjectId)
                return -1;
            else
                return 0;
        }
    }
}
