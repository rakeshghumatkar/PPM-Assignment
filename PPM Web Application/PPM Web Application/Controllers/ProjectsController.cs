using PPM_Web_Application.Data_DAO;
using PPM_Web_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PPM_Web_Application.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Projects
        public ActionResult Index()
        {
            List<Project> projects = new List<Project>();
            PPMEntities db = new PPMEntities();
            projects = db.Projects.ToList();
            return View("Index", projects);
        }

        
        public ActionResult Create()
        {
            return View("ProjectForm");
        }

        [HttpPost]
        public ActionResult CreateProcess(Project project)
        {
            PPMEntities db = new PPMEntities();
            ProjectDA projectDA = new ProjectDA();
            projectDA.Add(project);
            List<Project> projects = new List<Project>();
            projects = db.Projects.ToList();
            return View("Index", projects);
        }

        public ActionResult Details(int id)
        {
            Project project;
            PPMEntities db = new PPMEntities();
            project = db.Projects.FirstOrDefault(x=>x.ProjectId == id);
            return View("Details", project);
        }

       

        public ActionResult Edit(int id)
        {
            using (var context = new PPMEntities())
            {
                Project data = context.Projects.Where(x => x.ProjectId == id).SingleOrDefault();
                return View("Edit",data);
            }
        }

        // To specify that this will be 
        // invoked when post method is called
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Project model)
        {
            using (var context = new PPMEntities())
            {

                // Use of lambda expression to access
                // particular record from a database
                var data = context.Projects.FirstOrDefault(x => x.ProjectId == id);

                // Checking if any such record exist 
                if (data != null)
                {
                    data.ProjectName = model.ProjectName;
                    data.Description = model.Description;
                    data.StartDate = model.StartDate;
                    data.EndDate = model.EndDate;
                    data.ModifiedDate = DateTime.Now;
                    context.SaveChanges();

                    // It will redirect to 
                    // the Read method
                    return RedirectToAction("Index");
                }
                else
                    return View();
            }
        }

        public ActionResult Delete(int id)
        {
            PPMEntities db = new PPMEntities(); 
            db.Projects.Remove(db.Projects.FirstOrDefault(x => x.ProjectId == id));
            db.SaveChanges();
            List<Project> projects = db.Projects.ToList();
            return View("Index", projects);
        }



    }
}