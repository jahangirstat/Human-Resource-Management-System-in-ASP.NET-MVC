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
    public class SalaryHeadController : Controller
    {
        private MVC4ProjectEntities2 db = new MVC4ProjectEntities2();

        // GET: /SalaryHead/
        public ActionResult Index()
        {
            return View(db.SalaryHeads.ToList());
        }

        // GET: /SalaryHead/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryHead salaryhead = db.SalaryHeads.Find(id);
            if (salaryhead == null)
            {
                return HttpNotFound();
            }
            return View(salaryhead);
        }

        // GET: /SalaryHead/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /SalaryHead/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Head_Name,Rate,Activity")] SalaryHead salaryhead)
        {
            if (ModelState.IsValid)
            {
                db.SalaryHeads.Add(salaryhead);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salaryhead);
        }

        // GET: /SalaryHead/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryHead salaryhead = db.SalaryHeads.Find(id);
            if (salaryhead == null)
            {
                return HttpNotFound();
            }
            return View(salaryhead);
        }

        // POST: /SalaryHead/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Head_Name,Rate,Activity")] SalaryHead salaryhead)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salaryhead).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salaryhead);
        }

        // GET: /SalaryHead/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryHead salaryhead = db.SalaryHeads.Find(id);
            if (salaryhead == null)
            {
                return HttpNotFound();
            }
            return View(salaryhead);
        }

        // POST: /SalaryHead/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalaryHead salaryhead = db.SalaryHeads.Find(id);
            db.SalaryHeads.Remove(salaryhead);
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
