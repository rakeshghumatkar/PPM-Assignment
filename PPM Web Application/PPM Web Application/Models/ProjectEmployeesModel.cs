using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPM_Web_Application.Models
{
    public class ProjectEmployeesModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public DateTime AssignDate { get; set; }

        public ProjectEmployeesModel() { }
        public ProjectEmployeesModel(int projectId, string projectName, int employeeId, string firstName, string lastName, string emailId, string phoneNo, DateTime assignDate)
        {
            ProjectId = projectId;
            ProjectName = projectName;
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            EmailId = emailId;
            PhoneNo = phoneNo;
            AssignDate = assignDate;
        }

        public ProjectEmployeesModel(int projectId, string projectName, int employeeId, string firstName, string lastName, string emailId, string phoneNo)
        {
            ProjectId = projectId;
            ProjectName = projectName;
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            EmailId = emailId;
            PhoneNo = phoneNo;
        }
    }
}