using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCFinalProject.Models;

namespace MVCFinalProject.Controllers
{
    public class EmployeeController : Controller
    {
        private MVC4ProjectEntities2 db = new MVC4ProjectEntities2();

        // GET: /Employee/
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Benefit).Include(e => e.Department).Include(e => e.Designation).Include(e => e.Division).Include(e => e.Employee_Type).Include(e => e.Grade).Include(e => e.Section);
            return View(employees.ToList());
        }

        // GET: /Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: /Employee/Create
        public ActionResult Create()
        {
            ViewBag.Benefit_ID = new SelectList(db.Benefits, "Benefit_ID", "Benefit_Type");
            ViewBag.DID = new SelectList(db.Departments, "DID", "DName");
            ViewBag.DesId = new SelectList(db.Designations, "DesId", "DesName");
            ViewBag.DivID = new SelectList(db.Divisions, "DivID", "Division_Name");
            ViewBag.EmployeeType_ID = new SelectList(db.Employee_Type, "EmployeeType_ID", "Employee_Types");
            ViewBag.GID = new SelectList(db.Grades, "GID", "Grade_Name");
            ViewBag.SecID = new SelectList(db.Sections, "SecID", "Section_Name");
            return View();
        }

        // POST: /Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EmpID,Name,Father_Name,Mother_Name,DOB,Gender,Nationality,Maritual_status,Religion,Mobile,Email,Home_phone,Present_address,parmanent_address,DID,DesId,SecID,DivID,Benefit_ID,EmployeeType_ID,GID,Gross_Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Benefit_ID = new SelectList(db.Benefits, "Benefit_ID", "Benefit_Type", employee.Benefit_ID);
            ViewBag.DID = new SelectList(db.Departments, "DID", "DName", employee.DID);
            ViewBag.DesId = new SelectList(db.Designations, "DesId", "DesName", employee.DesId);
            ViewBag.DivID = new SelectList(db.Divisions, "DivID", "Division_Name", employee.DivID);
            ViewBag.EmployeeType_ID = new SelectList(db.Employee_Type, "EmployeeType_ID", "Employee_Types", employee.EmployeeType_ID);
            ViewBag.GID = new SelectList(db.Grades, "GID", "Grade_Name", employee.GID);
            ViewBag.SecID = new SelectList(db.Sections, "SecID", "Section_Name", employee.SecID);
            return View(employee);
        }

        // GET: /Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.Benefit_ID = new SelectList(db.Benefits, "Benefit_ID", "Benefit_Type", employee.Benefit_ID);
            ViewBag.DID = new SelectList(db.Departments, "DID", "DName", employee.DID);
            ViewBag.DesId = new SelectList(db.Designations, "DesId", "DesName", employee.DesId);
            ViewBag.DivID = new SelectList(db.Divisions, "DivID", "Division_Name", employee.DivID);
            ViewBag.EmployeeType_ID = new SelectList(db.Employee_Type, "EmployeeType_ID", "Employee_Types", employee.EmployeeType_ID);
            ViewBag.GID = new SelectList(db.Grades, "GID", "Grade_Name", employee.GID);
            ViewBag.SecID = new SelectList(db.Sections, "SecID", "Section_Name", employee.SecID);
            return View(employee);
        }

        // POST: /Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EmpID,Name,Father_Name,Mother_Name,DOB,Gender,Nationality,Maritual_status,Religion,Mobile,Email,Home_phone,Present_address,parmanent_address,DID,DesId,SecID,DivID,Benefit_ID,EmployeeType_ID,GID,Gross_Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Benefit_ID = new SelectList(db.Benefits, "Benefit_ID", "Benefit_Type", employee.Benefit_ID);
            ViewBag.DID = new SelectList(db.Departments, "DID", "DName", employee.DID);
            ViewBag.DesId = new SelectList(db.Designations, "DesId", "DesName", employee.DesId);
            ViewBag.DivID = new SelectList(db.Divisions, "DivID", "Division_Name", employee.DivID);
            ViewBag.EmployeeType_ID = new SelectList(db.Employee_Type, "EmployeeType_ID", "Employee_Types", employee.EmployeeType_ID);
            ViewBag.GID = new SelectList(db.Grades, "GID", "Grade_Name", employee.GID);
            ViewBag.SecID = new SelectList(db.Sections, "SecID", "Section_Name", employee.SecID);
            return View(employee);
        }

        // GET: /Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: /Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
