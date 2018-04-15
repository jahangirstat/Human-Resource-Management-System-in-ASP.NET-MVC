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
    public class SalaryHistoryController : Controller
    {
        private MVC4ProjectEntities2 db = new MVC4ProjectEntities2();

        // GET: /SalaryHistory/
        public ActionResult Index()
        {
            var salaryhistories = db.SalaryHistories.Include(s => s.Employee).Include(s => s.Promotion);
            return View(salaryhistories.ToList());
        }

        // GET: /SalaryHistory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryHistory salaryhistory = db.SalaryHistories.Find(id);
            if (salaryhistory == null)
            {
                return HttpNotFound();
            }
            return View(salaryhistory);
        }

        // GET: /SalaryHistory/Create
        public ActionResult Create()
        {
            ViewBag.EmpID = new SelectList(db.Employees, "EmpID", "Name");
            ViewBag.PromotionID = new SelectList(db.Promotions, "PromotionID", "Promotion_type");
            return View();
        }

        // POST: /SalaryHistory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SalaryHistoryID,EmpID,Dates,Basics,HouseRent,Medical,Convences,Taxes,Gross_Salary,PromotionID")] SalaryHistory salaryhistory)
        {
            if (ModelState.IsValid)
            {
                db.SalaryHistories.Add(salaryhistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpID = new SelectList(db.Employees, "EmpID", "Name", salaryhistory.EmpID);
            ViewBag.PromotionID = new SelectList(db.Promotions, "PromotionID", "Promotion_type", salaryhistory.PromotionID);
            return View(salaryhistory);
        }

        // GET: /SalaryHistory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryHistory salaryhistory = db.SalaryHistories.Find(id);
            if (salaryhistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpID = new SelectList(db.Employees, "EmpID", "Name", salaryhistory.EmpID);
            ViewBag.PromotionID = new SelectList(db.Promotions, "PromotionID", "Promotion_type", salaryhistory.PromotionID);
            return View(salaryhistory);
        }

        // POST: /SalaryHistory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SalaryHistoryID,EmpID,Dates,Basics,HouseRent,Medical,Convences,Taxes,Gross_Salary,PromotionID")] SalaryHistory salaryhistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salaryhistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpID = new SelectList(db.Employees, "EmpID", "Name", salaryhistory.EmpID);
            ViewBag.PromotionID = new SelectList(db.Promotions, "PromotionID", "Promotion_type", salaryhistory.PromotionID);
            return View(salaryhistory);
        }

        // GET: /SalaryHistory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryHistory salaryhistory = db.SalaryHistories.Find(id);
            if (salaryhistory == null)
            {
                return HttpNotFound();
            }
            return View(salaryhistory);
        }

        // POST: /SalaryHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalaryHistory salaryhistory = db.SalaryHistories.Find(id);
            db.SalaryHistories.Remove(salaryhistory);
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
