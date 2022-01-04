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
    public class PoliceComplaintsController : Controller
    {
        private Karachi_Complaint_SystemEntities2 db = new Karachi_Complaint_SystemEntities2();

        // GET: PoliceComplaints
        public ActionResult Index()
        {
            var policeComplaints = db.PoliceComplaints.Include(p => p.Department);
            return View(policeComplaints.ToList());
        }

        // GET: PoliceComplaints/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliceComplaint policeComplaint = db.PoliceComplaints.Find(id);
            if (policeComplaint == null)
            {
                return HttpNotFound();
            }
            return View(policeComplaint);
        }

        // GET: PoliceComplaints/Create
        public ActionResult Create()
        {
            ViewBag.S_NO = new SelectList(db.Departments, "S_NO", "DEPT_NAME");
            return View();
        }

        // POST: PoliceComplaints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CNIC_NO,NAME,CNIC_ADDRESS,AREA,COMPLAINT,S_NO")] PoliceComplaint policeComplaint)
        {
            if (ModelState.IsValid)
            {
                db.PoliceComplaints.Add(policeComplaint);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.S_NO = new SelectList(db.Departments, "S_NO", "DEPT_NAME", policeComplaint.S_NO);
            return View(policeComplaint);
        }

        // GET: PoliceComplaints/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliceComplaint policeComplaint = db.PoliceComplaints.Find(id);
            if (policeComplaint == null)
            {
                return HttpNotFound();
            }
            ViewBag.S_NO = new SelectList(db.Departments, "S_NO", "DEPT_NAME", policeComplaint.S_NO);
            return View(policeComplaint);
        }

        // POST: PoliceComplaints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CNIC_NO,NAME,CNIC_ADDRESS,AREA,COMPLAINT,S_NO")] PoliceComplaint policeComplaint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(policeComplaint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.S_NO = new SelectList(db.Departments, "S_NO", "DEPT_NAME", policeComplaint.S_NO);
            return View(policeComplaint);
        }

        // GET: PoliceComplaints/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliceComplaint policeComplaint = db.PoliceComplaints.Find(id);
            if (policeComplaint == null)
            {
                return HttpNotFound();
            }
            return View(policeComplaint);
        }

        // POST: PoliceComplaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            PoliceComplaint policeComplaint = db.PoliceComplaints.Find(id);
            db.PoliceComplaints.Remove(policeComplaint);
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
