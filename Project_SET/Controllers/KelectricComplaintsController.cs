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
    public class KelectricComplaintsController : Controller
    {
        private Karachi_Complaint_SystemEntities2 db = new Karachi_Complaint_SystemEntities2();

        // GET: KelectricComplaints
        public ActionResult Index()
        {
            var kelectricComplaints = db.KelectricComplaints.Include(k => k.Department);
            return View(kelectricComplaints.ToList());
        }

        // GET: KelectricComplaints/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KelectricComplaint kelectricComplaint = db.KelectricComplaints.Find(id);
            if (kelectricComplaint == null)
            {
                return HttpNotFound();
            }
            return View(kelectricComplaint);
        }

        // GET: KelectricComplaints/Create
        public ActionResult Create()
        {
            ViewBag.S_NO = new SelectList(db.Departments, "S_NO", "DEPT_NAME");
            return View();
        }

        // POST: KelectricComplaints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CNIC_NO,NAME,CNIC_ADDRESS,AREA,COMPLAINT,S_NO")] KelectricComplaint kelectricComplaint)
        {
            if (ModelState.IsValid)
            {
                db.KelectricComplaints.Add(kelectricComplaint);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.S_NO = new SelectList(db.Departments, "S_NO", "DEPT_NAME", kelectricComplaint.S_NO);
            return View(kelectricComplaint);
        }

        // GET: KelectricComplaints/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KelectricComplaint kelectricComplaint = db.KelectricComplaints.Find(id);
            if (kelectricComplaint == null)
            {
                return HttpNotFound();
            }
            ViewBag.S_NO = new SelectList(db.Departments, "S_NO", "DEPT_NAME", kelectricComplaint.S_NO);
            return View(kelectricComplaint);
        }

        // POST: KelectricComplaints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CNIC_NO,NAME,CNIC_ADDRESS,AREA,COMPLAINT,S_NO")] KelectricComplaint kelectricComplaint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kelectricComplaint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.S_NO = new SelectList(db.Departments, "S_NO", "DEPT_NAME", kelectricComplaint.S_NO);
            return View(kelectricComplaint);
        }

        // GET: KelectricComplaints/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KelectricComplaint kelectricComplaint = db.KelectricComplaints.Find(id);
            if (kelectricComplaint == null)
            {
                return HttpNotFound();
            }
            return View(kelectricComplaint);
        }

        // POST: KelectricComplaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            KelectricComplaint kelectricComplaint = db.KelectricComplaints.Find(id);
            db.KelectricComplaints.Remove(kelectricComplaint);
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
