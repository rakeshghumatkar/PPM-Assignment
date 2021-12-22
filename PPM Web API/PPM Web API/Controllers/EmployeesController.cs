using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PPM_Web_API.Controllers
{
    public class EmployeesController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using (PPMEntities db = new PPMEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.Employees.ToList();
            }
        }


        public Employee Get(int id)
        {
            using (PPMEntities db = new PPMEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.Employees.FirstOrDefault(x => x.EmployeeId == id);
            }
        }

        [HttpPost]
        public Employee Post([FromBody] Employee employee)
        {
            using (PPMEntities db = new PPMEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                employee.CreateDate = DateTime.Now;
                employee.ModifiedDate = DateTime.Now;
                db.Employees.Add(employee);
                db.SaveChanges();
                return employee;
            }
        }

       
        public Employee Put(int id, [FromBody] Employee employee)
        {
            using (PPMEntities db = new PPMEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                var existingEmployee = db.Employees.Where(s => s.EmployeeId == id).FirstOrDefault<Employee>();
                if (existingEmployee != null)
                {
                    existingEmployee.FirstName = employee.FirstName;
                    existingEmployee.LastName = employee.LastName;
                    existingEmployee.EmailId = employee.EmailId;
                    existingEmployee.PhoneNo = employee.PhoneNo;
                    existingEmployee.Address = employee.Address;
                    existingEmployee.ModifiedDate = DateTime.Now;

                    db.SaveChanges();
                }

                return existingEmployee;
            }
        }

        [HttpDelete]
        public Employee Delete(int id)
        {
            using (PPMEntities db = new PPMEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                Employee p = db.Employees.FirstOrDefault(x => x.EmployeeId == id);
                db.Employees.Remove(p);
                db.SaveChanges();
                return p;
            }
        }
    }
}
