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
    public class Employee_TypeController : Controller
    {
        private MVC4ProjectEntities2 db = new MVC4ProjectEntities2();

        // GET: /Employee_Type/
        public ActionResult Index()
        {
            return View(db.Employee_Type.ToList());
        }

        // GET: /Employee_Type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Type employee_type = db.Employee_Type.Find(id);
            if (employee_type == null)
            {
                return HttpNotFound();
            }
            return View(employee_type);
        }

        // GET: /Employee_Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Employee_Type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EmployeeType_ID,Employee_Types")] Employee_Type employee_type)
        {
            if (ModelState.IsValid)
            {
                db.Employee_Type.Add(employee_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee_type);
        }

        // GET: /Employee_Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Type employee_type = db.Employee_Type.Find(id);
            if (employee_type == null)
            {
                return HttpNotFound();
            }
            return View(employee_type);
        }

        // POST: /Employee_Type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EmployeeType_ID,Employee_Types")] Employee_Type employee_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee_type);
        }

        // GET: /Employee_Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Type employee_type = db.Employee_Type.Find(id);
            if (employee_type == null)
            {
                return HttpNotFound();
            }
            return View(employee_type);
        }

        // POST: /Employee_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee_Type employee_type = db.Employee_Type.Find(id);
            db.Employee_Type.Remove(employee_type);
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
