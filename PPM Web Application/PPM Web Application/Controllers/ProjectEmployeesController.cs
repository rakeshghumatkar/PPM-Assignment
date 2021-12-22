using PPM_Web_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PPM_Web_Application.Controllers
{
    public class ProjectEmployeesController : Controller
    {
        // GET: ProjectEmployees
        public ActionResult Index()
        {
            List<ProjectEmployeesModel> projects = new List<ProjectEmployeesModel>();
            //PPMEntities db = new PPMEntities();
            using (var db = new PPMEntities())
            {
                var data = (from p in db.Projects
                           join ep in db.ProjectEmployees on p.ProjectId equals ep.ProjectID
                           join e in db.Employees on ep.EmployeeID equals e.EmployeeId
                           select new
                           {
                               ProjectId = p.ProjectId,
                               ProjectName = p.ProjectName,
                               EmployeeId = ep.EmployeeID,
                               FirstName = e.FirstName,
                               LastName = e.LastName,
                               EmailId = e.EmailId,
                               PhoneNo = e.PhoneNo,
                               AssignDate = ep.AssignDate,
                           }).ToList();

               for( int i=0; i< data.Count; i++ )
                {
                    ProjectEmployeesModel p = new ProjectEmployeesModel();
                    p.ProjectId = data[i].ProjectId;
                    p.ProjectName = data[i].ProjectName;
                    p.EmployeeId = data[i].EmployeeId;
                    p.FirstName = data[i].FirstName;
                    p.LastName = data[i].LastName;
                    p.PhoneNo = data[i].PhoneNo;
                    p.EmailId = data[i].EmailId;
                    p.AssignDate = (DateTime) data[i].AssignDate;
                    projects.Add(p);
                }
            }

            return View("Index",projects);

        }

        public ActionResult Details(int id)
        {
            List<ProjectEmployeesModel> projects = new List<ProjectEmployeesModel>();
            //PPMEntities db = new PPMEntities();
            using (var db = new PPMEntities())
            {
                var data = (from p in db.Projects
                            join ep in db.ProjectEmployees on p.ProjectId equals ep.ProjectID
                            join e in db.Employees on ep.EmployeeID equals e.EmployeeId
                            where p.ProjectId == id
                            select new
                            {
                                ProjectId = p.ProjectId,
                                ProjectName = p.ProjectName,
                                EmployeeId = ep.EmployeeID,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                EmailId = e.EmailId,
                                PhoneNo = e.PhoneNo,
                                AssignDate = ep.AssignDate,
                            }).ToList();

                for (int i = 0; i < data.Count; i++)
                {
                    ProjectEmployeesModel p = new ProjectEmployeesModel();
                    p.ProjectId = data[i].ProjectId;
                    p.ProjectName = data[i].ProjectName;
                    p.EmployeeId = data[i].EmployeeId;
                    p.FirstName = data[i].FirstName;
                    p.LastName = data[i].LastName;
                    p.PhoneNo = data[i].PhoneNo;
                    p.EmailId = data[i].EmailId;
                    p.AssignDate = (DateTime)data[i].AssignDate;
                    projects.Add(p);
                }
            }

            return View("Index", projects);

        }

        public ActionResult Create()
        {
            return View("ProjectEmployeesForm");
        }

    [HttpPost]
    public ActionResult CreateProcess(ProjectEmployee projectEmployee)
        {
            PPMEntities db = new PPMEntities();
            projectEmployee.AssignDate = DateTime.Now;
            db.ProjectEmployees.Add(projectEmployee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

         public ActionResult Delete(int id)
         {
             return View("ProjectEmployeesDeleteForm");
         }

         [HttpPost]
         public ActionResult DeleteProcess(ProjectEmployee projectEmployee)
         {
            PPMEntities db = new PPMEntities();
            ProjectEmployee pe ;
            List<ProjectEmployee> projects;
            if (projectEmployee.ProjectID <= 0 || projectEmployee.EmployeeID <= 0)
            {
                projects = db.ProjectEmployees.Where(x => x.ProjectID == projectEmployee.ProjectID || x.EmployeeID == projectEmployee.EmployeeID).ToList();
                foreach(var i in projects)
                {
                    db.ProjectEmployees.Remove(i);
                }
            }
            else
            {
                pe = db.ProjectEmployees.FirstOrDefault(x => x.ProjectID == projectEmployee.ProjectID && x.EmployeeID == projectEmployee.EmployeeID);
                db.ProjectEmployees.Remove(pe);
            }
            
            db.SaveChanges();
            return RedirectToAction("Index");
         }

        

    }
}