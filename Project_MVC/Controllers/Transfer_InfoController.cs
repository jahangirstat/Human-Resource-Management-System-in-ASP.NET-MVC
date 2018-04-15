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
    public class Transfer_InfoController : Controller
    {
        private MVC4ProjectEntities2 db = new MVC4ProjectEntities2();

        // GET: /Transfer_Info/
        public ActionResult Index()
        {
            var transfer_info = db.Transfer_Info.Include(t => t.Employee);
            return View(transfer_info.ToList());
        }

        // GET: /Transfer_Info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transfer_Info transfer_info = db.Transfer_Info.Find(id);
            if (transfer_info == null)
            {
                return HttpNotFound();
            }
            return View(transfer_info);
        }

        // GET: /Transfer_Info/Create
        public ActionResult Create()
        {
            ViewBag.EmpID = new SelectList(db.Employees, "EmpID", "Name");
            return View();
        }

        // POST: /Transfer_Info/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TransferID,EmpID,OldDepartment,NewDepartment,OldDivision,NewDivision,OldSection,NewSection,TransferActiveDate,TransferDate,Remark,StatusState")] Transfer_Info transfer_info)
        {
            if (ModelState.IsValid)
            {
                db.Transfer_Info.Add(transfer_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpID = new SelectList(db.Employees, "EmpID", "Name", transfer_info.EmpID);
            return View(transfer_info);
        }

        // GET: /Transfer_Info/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transfer_Info transfer_info = db.Transfer_Info.Find(id);
            if (transfer_info == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpID = new SelectList(db.Employees, "EmpID", "Name", transfer_info.EmpID);
            return View(transfer_info);
        }

        // POST: /Transfer_Info/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TransferID,EmpID,OldDepartment,NewDepartment,OldDivision,NewDivision,OldSection,NewSection,TransferActiveDate,TransferDate,Remark,StatusState")] Transfer_Info transfer_info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transfer_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpID = new SelectList(db.Employees, "EmpID", "Name", transfer_info.EmpID);
            return View(transfer_info);
        }

        // GET: /Transfer_Info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transfer_Info transfer_info = db.Transfer_Info.Find(id);
            if (transfer_info == null)
            {
                return HttpNotFound();
            }
            return View(transfer_info);
        }

        // POST: /Transfer_Info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transfer_Info transfer_info = db.Transfer_Info.Find(id);
            db.Transfer_Info.Remove(transfer_info);
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
