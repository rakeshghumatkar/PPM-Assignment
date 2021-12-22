using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PPM_Web_API.Controllers
{
    public class ProjectEmployeesController : ApiController
    {

        public IEnumerable<ProjectEmployee> Get()
        {
            using (PPMEntities db = new PPMEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.ProjectEmployees.ToList();
            }
        }


        public ProjectEmployee Get(int id)
        {
            using (PPMEntities db = new PPMEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.ProjectEmployees.FirstOrDefault(x => x.ProjectID == id);
            }
        }


        public ProjectEmployee Post([FromBody] ProjectEmployee ProjectEmployee)
        {
            using (PPMEntities db = new PPMEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.ProjectEmployees.Add(ProjectEmployee);
                db.SaveChanges();
                return ProjectEmployee;
            }
        }

        public ProjectEmployee Put(int id, [FromBody] ProjectEmployee ProjectEmployee)
        {
            using (PPMEntities db = new PPMEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                var existingRole = db.ProjectEmployees.Where(s => s.ProjectID == id).FirstOrDefault<ProjectEmployee>();
                if (existingRole != null)
                {
                    existingRole.EmployeeID = ProjectEmployee.EmployeeID;

                    db.SaveChanges();
                }

                return existingRole;
            }
        }

        [HttpDelete]
        public ProjectEmployee Delete(int id)
        {
            using (PPMEntities db = new PPMEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                ProjectEmployee p = db.ProjectEmployees.FirstOrDefault(x => x.ProjectID == id);
                db.ProjectEmployees.Remove(p);
                db.SaveChanges();
                return p;
            }
        }

    }
}
