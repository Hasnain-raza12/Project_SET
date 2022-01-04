using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_SET.Models;

namespace Project_SET.Controllers
{
    public class IncomeTaxComplaintsController : Controller
    {
        private Karachi_Complaint_SystemEntities2 db = new Karachi_Complaint_SystemEntities2();

        // GET: IncomeTaxComplaints
        public ActionResult Index()
        {
            var incomeTaxComplaints = db.IncomeTaxComplaints.Include(i => i.Department);
            return View(incomeTaxComplaints.ToList());
        }

        // GET: IncomeTaxComplaints/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeTaxComplaint incomeTaxComplaint = db.IncomeTaxComplaints.Find(id);
            if (incomeTaxComplaint == null)
            {
                return HttpNotFound();
            }
            return View(incomeTaxComplaint);
        }

        // GET: IncomeTaxComplaints/Create
        public ActionResult Create()
        {
            ViewBag.S_NO = new SelectList(db.Departments, "S_NO", "DEPT_NAME");
            return View();
        }

        // POST: IncomeTaxComplaints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CNIC_NO,NAME,CNIC_ADDRESS,AREA,COMPLAINT,S_NO")] IncomeTaxComplaint incomeTaxComplaint)
        {
            if (ModelState.IsValid)
            {
                db.IncomeTaxComplaints.Add(incomeTaxComplaint);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            ViewBag.S_NO = new SelectList(db.Departments, "S_NO", "DEPT_NAME", incomeTaxComplaint.S_NO);
            return View(incomeTaxComplaint);
        }

        // GET: IncomeTaxComplaints/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeTaxComplaint incomeTaxComplaint = db.IncomeTaxComplaints.Find(id);
            if (incomeTaxComplaint == null)
            {
                return HttpNotFound();
            }
            ViewBag.S_NO = new SelectList(db.Departments, "S_NO", "DEPT_NAME", incomeTaxComplaint.S_NO);
            return View(incomeTaxComplaint);
        }

        // POST: IncomeTaxComplaints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CNIC_NO,NAME,CNIC_ADDRESS,AREA,COMPLAINT,S_NO")] IncomeTaxComplaint incomeTaxComplaint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incomeTaxComplaint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.S_NO = new SelectList(db.Departments, "S_NO", "DEPT_NAME", incomeTaxComplaint.S_NO);
            return View(incomeTaxComplaint);
        }

        // GET: IncomeTaxComplaints/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeTaxComplaint incomeTaxComplaint = db.IncomeTaxComplaints.Find(id);
            if (incomeTaxComplaint == null)
            {
                return HttpNotFound();
            }
            return View(incomeTaxComplaint);
        }

        // POST: IncomeTaxComplaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            IncomeTaxComplaint incomeTaxComplaint = db.IncomeTaxComplaints.Find(id);
            db.IncomeTaxComplaints.Remove(incomeTaxComplaint);
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
