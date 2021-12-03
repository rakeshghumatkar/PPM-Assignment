using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPM_LinqToSql
{
    public class Program
    {
        static void Main(string[] args)
        {
            PPMEntities entities = new PPMEntities();
            
            /*var result1 = from emp in entities.Employees select emp;
            var result = entities.Employees.Select(x => x);
            Console.WriteLine("List of Employee ");
            foreach(var v in result1)
            {
                Console.WriteLine("EmployeeId = "+v.employeeId+" Employee Name = " + v.firstName + " " + v.lastName );
            }
            foreach (var v in result)
            {
                Console.WriteLine("EmployeeId = " + v.employeeId + " Employee Name = " + v.firstName + " " + v.lastName);
            }

            //var resu = entities.Employees.Select(x => x).Where(x=>x.employeeId.Equals(11));
            var result2 = from emp in entities.Employees where emp.employeeId >22 select emp;
            Console.WriteLine("List of Employee id greater than 22 ");
            foreach (var v in result2)
            {
                Console.WriteLine("EmployeeId = " + v.employeeId + "Employee Name = " + v.firstName + " " + v.lastName);
            }

            var result3 = from emp in entities.Employees orderby emp.firstName select emp;
            Console.WriteLine("List of Employee id greater than 22 ");
            foreach (var v in result3)
            {
                Console.WriteLine("EmployeeId = " + v.employeeId + "Employee Name = " + v.firstName + " " + v.lastName);
            }
*/

            
                PPMEntities db = new PPMEntities();
            /*Employee employee = new Employee();
            employee.employeeId = 88;
            employee.firstName = "ram";
            employee.lastName = "jj";
            employee.emailId = "ram@";
            employee.phoneNo = "875431245";
            employee.eAddress = "Nagpur";
            //employee.role = 1;

            db.Employees.Add(employee);
            db.SaveChanges();*/

            var row = db.Employees.Find(x => x.employeeId.Equals(88));
            //row.createDate = DateTime.Now;
            db.SaveChanges();

            Console.WriteLine(row);
           /* var result = entities.Employees.Select(x => x);
            Console.WriteLine("List of Employee ");
            foreach (var v in result)
            {
                Console.WriteLine("EmployeeId = " + v.employeeId + " Employee Name = " + v.firstName + " " + v.lastName);
            }*/

            Console.ReadLine();


        }
    }
}
