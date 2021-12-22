using PPM_Web_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPM_Web_Application.Data_DAO
{
    public class ProjectDA
    {
        public void Add(Project p)
        {
            PPMEntities db = new PPMEntities();
            Project project = new Project();
           
            project.ProjectName = p.ProjectName;
            project.Description = p.Description;
            project.StartDate = p.StartDate;
            project.EndDate = p.EndDate;
            project.CreateDate = DateTime.Now;
            project.ModifiedDate = DateTime.Now;

            db.Projects.Add(project);
            db.SaveChanges();
           
        }

        public void Update(Project project)
        {
            PPMEntities db = new PPMEntities();
            //Project project = new Project();

           //db.Projects.Where(x => x.ProjectId == project.ProjectId).Select(x => x = project ).SingleOrDefault();

            //db.Projects.Where( x=>x.ProjectId == p.ProjectId).

            //project.ProjectName = p.ProjectName;
            //project.Description = p.Description;
            //project.StartDate = p.StartDate;
            //project.EndDate = p.EndDate;
            //project.ModifiedDate = DateTime.Now;

            //db.Projects.Select(x =>);
            //db.Projects.Add(project);

            db.SaveChanges();

        }


    }
}