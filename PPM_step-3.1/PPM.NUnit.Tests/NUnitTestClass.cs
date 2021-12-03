// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using PPM_step_3._1;
using BusinessLogic;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PPM.NUnit.Tests
{
    [TestFixture]
    public class NUnitTestClass
    {
        
            ProjectBL projectBLTest = new ProjectBL();
            EmployeeBL employeeBLTest = new EmployeeBL();
            RoleBL roleBLTest = new RoleBL();
            List<ProjectModel> projects;
            List<EmployeeModel> employees;
            List<RoleModel> roles ;

        

        [Test]
        public void ProjectTests()
        {
            //Arrange
            
            DateTime dt1_1 = new DateTime(2016, 12, 20);
            DateTime dt1_2 = new DateTime(2019, 12, 20);
            ProjectModel project1 = new ProjectModel(11,"Hotel Management", dt1_1, dt1_2, "desss..1");


            DateTime dt2_1 = new DateTime(2017, 11, 22);
            DateTime dt2_2 = new DateTime(2018, 11, 22);
            ProjectModel project2 = new ProjectModel(22,"Employee Management", dt2_1, dt2_2, "desss..2");

            //Act
            projectBLTest.AddProject(project1);
            projectBLTest.AddProject(project2);

            projects = projectBLTest.GetProject();


            //Assert

            Assert.AreEqual(true, projectBLTest.IsProjectExist(project1.ProjectId));
            Assert.AreNotEqual(false, projectBLTest.IsProjectExist(project1.ProjectId));
            Assert.AreEqual(true, projectBLTest.IsProjectExist(project2.ProjectId));
            Assert.AreEqual(false, projectBLTest.IsProjectExist(33));

            //Delete Project Test
            ProjectModel DeleteProject = projectBLTest.GetProject(22);
            projectBLTest.DeleteProject(DeleteProject);
            Assert.AreEqual(false, projectBLTest.IsProjectExist(22));
        }

        [Test]
        public void RoleTests()
        {
            //Arrange 
            RoleModel role1 = new RoleModel(111, "HR");
            RoleModel role2 = new RoleModel(222, "Tester");

            //Act
            roleBLTest.AddRole(role1);
            roleBLTest.AddRole(role2);
            roles = roleBLTest.GetRole();

            //Assert
            Assert.AreEqual(111, role1.roleId);
            Assert.AreEqual("HR", role1.roleName);

            Assert.AreEqual(222, role2.roleId);
            Assert.AreEqual("Tester", role2.roleName);

            Assert.AreEqual(true, roleBLTest.IsRoleExist(role1.roleId));
            Assert.AreEqual(true, roleBLTest.IsRoleExist(role2.roleId));
        }


        [Test]
        public void EmployeeTests()
        {
            //Arrange
            EmployeeModel employee1 = new EmployeeModel(11, "rakesh", "ghumatkar", "rakesh@gmail.com", "98654712", "aaa");
            EmployeeModel employee2 = new EmployeeModel(22, "sagar", "xxx", "xxx@gmail.com", "8954136", "sss");
           

            //Act
            employeeBLTest.AddEmployee(employee1);
            employeeBLTest.AddEmployee(employee2);
            employees = employeeBLTest.GetEmployee();

            //Assert
            Assert.AreEqual(11, employee1.empolyeeId);
            Assert.AreEqual("rakesh", employee1.firstName);
            Assert.AreEqual("ghumatkar", employee1.lastName);
            Assert.AreEqual("rakesh@gmail.com", employee1.emailID);

            Assert.AreEqual(22, employee2.empolyeeId);
            Assert.AreEqual("sagar", employee2.firstName);
            Assert.AreEqual("xxx", employee2.lastName);
            Assert.AreEqual("xxx@gmail.com", employee2.emailID);

            Assert.AreEqual(true, employeeBLTest.IsEmployeeExist(employee1.empolyeeId));
            Assert.AreEqual(true, employeeBLTest.IsEmployeeExist(employee2.empolyeeId));

            Assert.AreEqual(false, employeeBLTest.IsEmployeeExist(33));
        }

        
        [Test]
        public void AddandDeleteEmployeeFromProjectTest()
        {
            //Arrange
            DateTime dt1_1 = new DateTime(2014, 12, 20);
            DateTime dt1_2 = new DateTime(2020, 12, 20);
            ProjectModel project1 = new ProjectModel(111, "School Management", dt1_1, dt1_2, "desss..1");
            DateTime dt2_1 = new DateTime(2017, 11, 22);
            DateTime dt2_2 = new DateTime(2018, 11, 22);
            ProjectModel project2 = new ProjectModel(222, "Employee Management", dt2_1, dt2_2, "desss..2");

            EmployeeModel employee1 = new EmployeeModel(11, "Mogali", "wwe", "wwe@gmail.com", "98654712", "aaa");
            EmployeeModel employee2 = new EmployeeModel(22, "Shinchan", "xxx", "xxx@gmail.com", "9856452", "acccbb");
            EmployeeModel employee3 = new EmployeeModel(33, "RamuKaka", "rdx", "rdx@gmail.com", "98745214", "aawww ss");
            EmployeeModel employee4 = new EmployeeModel(44, "Chacha", "abc", "abc@gmail.com", "7894562", "wqq dd");

            //Act : Add Employee To Project Test
            projectBLTest.AddProject(project1);
            projectBLTest.AddProject(project2);

            projectBLTest.AddEmployeeToProject(111, employee1);
            projectBLTest.AddEmployeeToProject(111, employee2);
            projectBLTest.AddEmployeeToProject(111, employee3);
            projectBLTest.AddEmployeeToProject(111, employee4);

            projectBLTest.AddEmployeeToProject(222, employee1);
            projectBLTest.AddEmployeeToProject(222, employee2);
            projectBLTest.AddEmployeeToProject(222, employee3);
            projectBLTest.AddEmployeeToProject(222, employee4);

            projects = projectBLTest.GetProject();

            //Assert
            Assert.AreEqual(employee1, projects[0].ProjectEmployeesList[0]);
            Assert.AreEqual(employee2, projects[0].ProjectEmployeesList[1]);
            Assert.AreEqual(employee3, projects[0].ProjectEmployeesList[2]);
            Assert.AreEqual(employee4, projects[0].ProjectEmployeesList[3]);

            Assert.AreEqual(employee1, projects[1].ProjectEmployeesList[0]);
            Assert.AreEqual(employee2, projects[1].ProjectEmployeesList[1]);
            Assert.AreEqual(employee3, projects[1].ProjectEmployeesList[2]);
            Assert.AreEqual(employee4, projects[1].ProjectEmployeesList[3]);



            //Act : Delete Employee From The Project Test

            int projectIndex = -1, employeeIndex = -1;
            //Project 1
            Assert.AreEqual(true, projectBLTest.IsProjectEmployeeExist(11));
            projectBLTest.IsProjectEmployeeExist(11, ref projectIndex, ref employeeIndex);
            projectBLTest.DeleteEmployeeFromProjectList(projectIndex, employeeIndex);
            Assert.AreEqual(true, projectBLTest.IsProjectEmployeeExist(11));
            Assert.AreNotEqual(employee1, projects[0].ProjectEmployeesList[0]);
            Assert.AreEqual(employee2, projects[0].ProjectEmployeesList[0]);

            Assert.AreEqual(true, projectBLTest.IsProjectEmployeeExist(22));
            projectBLTest.IsProjectEmployeeExist(22, ref projectIndex, ref employeeIndex);
            projectBLTest.DeleteEmployeeFromProjectList(projectIndex, employeeIndex);
            Assert.AreEqual(true, projectBLTest.IsProjectEmployeeExist(22));
            Assert.AreNotEqual(employee2, projects[0].ProjectEmployeesList[0]);

            Assert.AreEqual(employee3, projects[0].ProjectEmployeesList[0]);
            Assert.AreEqual(employee4, projects[0].ProjectEmployeesList[1]);


            //Project 2
            Assert.AreEqual(true, projectBLTest.IsProjectEmployeeExist(11));
            projectBLTest.IsProjectEmployeeExist(11, ref projectIndex, ref employeeIndex);
            projectBLTest.DeleteEmployeeFromProjectList(projectIndex, employeeIndex);
            Assert.AreNotEqual(employee1, projects[1].ProjectEmployeesList[0]);
            Assert.AreEqual(employee2, projects[1].ProjectEmployeesList[0]);

            Assert.AreEqual(true, projectBLTest.IsProjectEmployeeExist(22));
            projectBLTest.IsProjectEmployeeExist(22, ref projectIndex, ref employeeIndex);
            projectBLTest.DeleteEmployeeFromProjectList(projectIndex, employeeIndex);
            Assert.AreNotEqual(employee2, projects[1].ProjectEmployeesList[0]);

            Assert.AreEqual(false, projectBLTest.IsProjectEmployeeExist(22));
            Assert.AreEqual(false, projectBLTest.IsProjectEmployeeExist(11));

            Assert.AreEqual(employee3, projects[1].ProjectEmployeesList[0]);
            Assert.AreEqual(employee4, projects[1].ProjectEmployeesList[1]);

        


        }

        [Test]
        public void AssignRoleToEmployeeTest()
        {
            //Arrange
            EmployeeModel employee1 = new EmployeeModel(11, "Tom", "UFC", "Tom@gmail.com", "98654712", "aaa");
            EmployeeModel employee2 = new EmployeeModel(22, "Jerry", "WWE", "Jerry@gmail.com", "8954136", "sss");

            RoleModel role1 = new RoleModel(111, "HR");
            RoleModel role2 = new RoleModel(222, "Tester");

            //Act
            employeeBLTest.AddEmployee(employee1);
            employeeBLTest.AddEmployee(employee2);

           
            employees = employeeBLTest.GetEmployee();
           
            employeeBLTest.AssignRoleToEmployee(11, role1);
            employeeBLTest.AssignRoleToEmployee(22, role2);

            //Assert
            int roleID1 = employees[0].GetRoleId();
            Assert.AreEqual(roleID1, role1.roleId);
            int roleID2 = employees[1].GetRoleId();
            Assert.AreEqual(roleID2, role2.roleId);

            //Checking Employee role Assign or not
            Assert.AreEqual(true, employeeBLTest.IsEmployeeRoleExist(111));
            Assert.AreEqual(false, employeeBLTest.IsEmployeeRoleExist(333));

            int n = -1;
            employeeBLTest.IsEmployeeRoleExist(111,ref n);
            employeeBLTest.DeleteRoleOfEmployee(n);
            Assert.AreEqual(false, employeeBLTest.IsEmployeeRoleExist(111));
        }
    }
}
