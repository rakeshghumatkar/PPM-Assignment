using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            PPMEntities db = new PPMEntities();
            Employee employee = new Employee();
            employee.employeeId = 99;
            employee.firstName = "ram";
            employee.lastName = "jj";
            employee.emailId = "ram@";
            employee.phoneNo = "875431245";
            employee.eAddress = "Nagpur";
            //employee.role = 1;

            db.Employees.Add(employee);
            db.SaveChanges();

        }
    }
}
