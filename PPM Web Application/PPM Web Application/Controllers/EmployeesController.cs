using PPM_Web_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PPM_Web_Application.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            List<Employee> Employees = new List<Employee>();
            PPMEntities db = new PPMEntities();
            Employees = db.Employees.ToList();
            return View("Index", Employees);
        }


        public ActionResult Create()
        {
            return View("EmployeeForm");
        }

        [HttpPost]
        public ActionResult ProcessCreate(Employee employee)
        {
            PPMEntities db = new PPMEntities();
            employee.CreateDate = DateTime.Now;
            employee.ModifiedDate = DateTime.Now;
            db.Employees.Add(employee);
            db.SaveChanges();
            List<Employee> employees ;
            employees = db.Employees.ToList();
            return View("Index", employees);
        }

        public ActionResult Details(int id)
        {
            Employee employee;
            PPMEntities db = new PPMEntities();
            employee = db.Employees.FirstOrDefault(x => x.EmployeeId == id);
            return View("Details", employee);
        }



        public ActionResult Edit(int id)
        {
            using (var context = new PPMEntities())
            {
                Employee data = context.Employees.Where(x => x.EmployeeId == id).SingleOrDefault();
                return View("Edit", data);
            }
        }

        // To specify that this will be 
        // invoked when post method is called
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee model)
        {
            using (var context = new PPMEntities())
            {

                // Use of lambda expression to access
                // particular record from a database
                var data = context.Employees.FirstOrDefault(x => x.EmployeeId == id);

                // Checking if any such record exist 
                if (data != null)
                {
                    data.FirstName = model.FirstName;
                    data.LastName = model.LastName;
                    data.EmailId = model.EmailId;
                    data.PhoneNo = model.PhoneNo;
                    data.Address = model.Address;
                    data.RoleID = model.RoleID;
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
            db.Employees.Remove(db.Employees.FirstOrDefault(x => x.EmployeeId == id));
            db.SaveChanges();
            List<Employee> employees = db.Employees.ToList();
            return View("Index", employees);
        }



    }
}