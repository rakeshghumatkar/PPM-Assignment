// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using PPM_step_3;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PPM_tester
{
    [TestFixture]
    public class PPM_tests
    {

        BusinessLogic test = null;

        [SetUp]
        public void SetUp()
        {
            test = new BusinessLogic();
        }

        [Test]
        public void TestMethod()
        {

            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "Some useful error message");
        }



        [Test]
        public void ProjectTests()
        {
            //Arrange
            // 1.
            DateTime dt1_1 = new DateTime(2016, 12, 20);
            DateTime dt1_2 = new DateTime(2019, 12, 20);
            Project project1 = new Project("Hotel Management", dt1_1, dt1_2, "desss..1");

            DateTime dt2_1 = new DateTime(2017, 11, 22);
            DateTime dt2_2 = new DateTime(2018, 11, 22);
            Project project2 = new Project("Employee Management", dt2_1, dt2_2, "desss..2");



            //Act
            // 2.
            test.AddProjectsTest(project1);
            test.AddProjectsTest(project2);

            //Assert
            Assert.AreEqual("Hotel Management", project1.projectName);
            Assert.AreEqual("desss..1", project1.description);

            Assert.AreEqual("Employee Management", project2.projectName);
            Assert.AreEqual("desss..2", project2.description);

            Assert.AreEqual(true, test.IsProject(project1.projectName));
            Assert.AreEqual(true, test.IsProject(project2.projectName));



        }

        [Test]
        public void RoleTests()
        {
            //Arrange 
            Role role1 = new Role(111, "HR");
            Role role2 = new Role(222, "Tester");

            //Act
            test.AddRoleTest(role1);
            test.AddRoleTest(role2);

            //Assert

            Assert.AreEqual(111, role1.roleId);
            Assert.AreEqual("HR", role1.roleNames[0]);

            Assert.AreEqual(222, role2.roleId);
            Assert.AreEqual("Tester", role2.roleNames[0]);

            Assert.AreEqual(true, test.IsRole(role1.roleId));
            Assert.AreEqual(true, test.IsRole(role2.roleId));
        }

        [Test]
        public void EmployeeTests()
        {
            //Arrange
            Employee employee1 = new Employee(11, "rakesh", "ghumatkar", "rakesh@gmail.com", "98654712", "aaa");
            Employee employee2 = new Employee(22, "sagar", "xxx", "xxx@gmail.com", "8954136", "sss");

            //Act
            test.AddEmployeeTest(employee1);
            test.AddEmployeeTest(employee2);

            //Assert
            Assert.AreEqual(11, employee1.empolyeeId);
            Assert.AreEqual("rakesh", employee1.firstName);
            Assert.AreEqual("ghumatkar", employee1.lastName);
            Assert.AreEqual("rakesh@gmail.com", employee1.emailID);

            Assert.AreEqual(22, employee2.empolyeeId);
            Assert.AreEqual("sagar", employee2.firstName);
            Assert.AreEqual("xxx", employee2.lastName);
            Assert.AreEqual("xxx@gmail.com", employee2.emailID);

            Assert.AreEqual(true, test.IsEmployee(employee1.empolyeeId));
            Assert.AreEqual(true, test.IsEmployee(employee2.empolyeeId));
        }

        [Test]
        public void AddEmployeeToProjectTests()
        {
            //Arrange
            DateTime dt1_1 = new DateTime(2016, 12, 20);
            DateTime dt1_2 = new DateTime(2019, 12, 20);
            Project project1 = new Project("Hotel", dt1_1, dt1_2, "desss..1");
            Employee employee1 = new Employee(33, "rakesh", "ghumatkar", "rakesh@gmail.com", "98654712", "aaa");
            // Employee employee2 = new Employee(22, "sagar", "xxx", "xxx@gmail.com", "8954136", "sss");

            //Act
            test.AddProjectsTest(project1);
            test.AddEmployeeTest(employee1);

            test.AddEmployeeToProject("Hotel", 33);
            bool flag = test.IsProjectEmployee("Hotel", 33);
            //test.AddEmployeeToProject("Hotel Management", 22);

            //Assert
            Assert.AreEqual(true, test.IsProjectEmployee("Hotel", 33));
            Assert.AreEqual(true, flag);
            //Assert.AreEqual(true, test.IsProjectEmployee("Hotel", 22));

        }

        [Test]
        public void DeleteEmployeeFromProjectTest()
        {
            //Arrange
            DateTime dt1_1 = new DateTime(2016, 12, 20);
            DateTime dt1_2 = new DateTime(2019, 12, 20);
            Project project1 = new Project("Hotel", dt1_1, dt1_2, "desss..1");
            Employee employee1 = new Employee(33, "rakesh", "ghumatkar", "rakesh@gmail.com", "98654712", "aaa");
            // Employee employee2 = new Employee(22, "sagar", "xxx", "xxx@gmail.com", "8954136", "sss");

            //Act
            test.AddProjectsTest(project1);
            test.AddEmployeeTest(employee1);

            test.AddEmployeeToProject("Hotel", 33);
            bool flag = test.IsProjectEmployee("Hotel", 33);
            //test.AddEmployeeToProject("Hotel Management", 22);

            //Assert
            Assert.AreEqual(true, test.IsProjectEmployee("Hotel", 33));
            Assert.AreEqual(true, flag);

            //Act
            test.DeleteEmployeeFromProject("Hotel", 33);

            Assert.AreNotEqual(true, test.IsProjectEmployee("Hotel", 33));
        }


    }
}
