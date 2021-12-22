using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace PPM_Web_API.Controllers
{
    public class ProjectsController : ApiController
    {
        
       
        public IEnumerable<Project> Get()
        {
            using (PPMEntities db = new PPMEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.Projects.ToList();
            }
        }

       
        public Project Get(int id)
        {
            using (PPMEntities db = new PPMEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.Projects.FirstOrDefault(x => x.ProjectId == id);
            }
        }

     
        public Project Post([FromBody] Project project)
        {
            using (PPMEntities db = new PPMEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Projects.Add(project);
                db.SaveChanges();
                return project;
            }
        }

        public Project Put(int id, [FromBody] Project project)
        {
            using (PPMEntities db = new PPMEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                var existingProject = db.Projects.Where(s => s.ProjectId == id).FirstOrDefault<Project>();
                if (existingProject != null)
                {
                    existingProject.ProjectName = project.ProjectName;
                    existingProject.Description = project.Description;
                    existingProject.StartDate = project.StartDate;
                    existingProject.EndDate = project.EndDate;
                    existingProject.ModifiedDate = DateTime.Now;

                    db.SaveChanges();
                }

                return existingProject;
            }
        }

        [HttpDelete]
        public Project Delete(int id)
        {
            using (PPMEntities db = new PPMEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                Project p = db.Projects.FirstOrDefault(x => x.ProjectId == id);
                db.Projects.Remove(p);
                db.SaveChanges();
                return p;
            }
        }








    }
}
