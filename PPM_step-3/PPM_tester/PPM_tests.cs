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

        BusinessLogic test = new BusinessLogic();
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "Some useful error message");
        }


        
        [Test]
        public void ProjectTests()
        {
            //Arrange
            DateTime dt1 = new DateTime(2016, 12, 20);
            DateTime dt2 = new DateTime(2019, 12, 20);
            Project project = new Project("projectt", dt1, dt2, "desss");

            //Act


            //Assert
            Assert.AreEqual("projectt", project.projectName);
            Assert.AreEqual("desss", project.description);

        }

        [Test]
        public void RoleTests()
        {
            //Arrange 
            Role role = new Role(111, "HR");

            //Act

            //Assert

            Assert.AreEqual(111, role.roleId);
            Assert.AreEqual("HR", role.roleNames[0]);

        }

        [Test]
        public void EmployeeTests()
        {
            //Arrange
            Employee employee = new Employee(11, "rakesh", "ghumatkar", "rakesh@gmail.com", "98654712", "aaa");

            //Assert
            Assert.AreEqual(11, employee.empolyeeId);
            Assert.AreEqual("rakesh", employee.firstName);
            Assert.AreEqual("ghumatkar", employee.lastName);
            Assert.AreEqual("rakesh@gmail.com", employee.emailID);
        }
        

        public void AddEmployeeToProjectTests()
        {
            //Arrange

            //Act
            test.AddEmployeeToProject("projectt", 11);

            //Assert
            //Assert.AreEqual("rakesh", test)

        }



    }
}
