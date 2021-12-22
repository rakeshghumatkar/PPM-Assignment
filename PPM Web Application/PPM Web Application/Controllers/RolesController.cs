using PPM_Web_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PPM_Web_Application.Controllers
{
    public class RolesController : Controller
    {
     
        // GET: Roles
        public ActionResult Index()
        {
            List<Role> roles ;
            PPMEntities db = new PPMEntities();
            roles = db.Roles.ToList();
            return View("Index", roles);
        }


        public ActionResult Create()
        {
            return View("RoleForm");
        }

        [HttpPost]
        public ActionResult ProcessCreate(Role Role)
        {
            PPMEntities db = new PPMEntities();
            db.Roles.Add(Role);
            db.SaveChanges();
            List<Role> Roles ;
            Roles = db.Roles.ToList();
            return View("Index", Roles);
        }

        public ActionResult Details(int id)
        {
            Role role;
            PPMEntities db = new PPMEntities();
            role = db.Roles.FirstOrDefault(x => x.RoleId == id);
            return View("Details", role);
        }



        public ActionResult Edit(int id)
        {
            using (var context = new PPMEntities())
            {
                Role data = context.Roles.Where(x => x.RoleId == id).SingleOrDefault();
                return View("Edit", data);
            }
        }

        // To specify that this will be 
        // invoked when post method is called
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Role model)
        {
            using (var context = new PPMEntities())
            {

                // Use of lambda expression to access
                // particular record from a database
                var data = context.Roles.FirstOrDefault(x => x.RoleId == id);

                // Checking if any such record exist 
                if (data != null)
                {
                    data.RoleId = model.RoleId;
                    data.RoleName = model.RoleName;
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
            db.Roles.Remove(db.Roles.FirstOrDefault(x => x.RoleId == id));
            db.SaveChanges();
            List<Role> roles = db.Roles.ToList();
            return View("Index", roles);
        }
    }
}