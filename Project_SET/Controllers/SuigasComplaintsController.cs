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
    public class SuigasComplaintsController : Controller
    {
        private Karachi_Complaint_SystemEntities2 db = new Karachi_Complaint_SystemEntities2();

        // GET: SuigasComplaints
        public ActionResult Index()
        {
            var suigasComplaints = db.SuigasComplaints.Include(s => s.Department);
            return View(suigasComplaints.ToList());
        }

        // GET: SuigasComplaints/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuigasComplaint suigasComplaint = db.SuigasComplaints.Find(id);
            if (suigasComplaint == null)
            {
                return HttpNotFound();
            }
            return View(suigasComplaint);
        }

        // GET: SuigasComplaints/Create
        public ActionResult Create()
        {
            ViewBag.S_NO = new SelectList(db.Departments, "S_NO", "DEPT_NAME");
            return View();
        }

        // POST: SuigasComplaints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CNIC_NO,NAME,CNIC_ADDRESS,AREA,COMPLAINT,S_NO")] SuigasComplaint suigasComplaint)
        {
            if (ModelState.IsValid)
            {
                db.SuigasComplaints.Add(suigasComplaint);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.S_NO = new SelectList(db.Departments, "S_NO", "DEPT_NAME", suigasComplaint.S_NO);
            return View(suigasComplaint);
        }

        // GET: SuigasComplaints/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuigasComplaint suigasComplaint = db.SuigasComplaints.Find(id);
            if (suigasComplaint == null)
            {
                return HttpNotFound();
            }
            ViewBag.S_NO = new SelectList(db.Departments, "S_NO", "DEPT_NAME", suigasComplaint.S_NO);
            return View(suigasComplaint);
        }

        // POST: SuigasComplaints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CNIC_NO,NAME,CNIC_ADDRESS,AREA,COMPLAINT,S_NO")] SuigasComplaint suigasComplaint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suigasComplaint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.S_NO = new SelectList(db.Departments, "S_NO", "DEPT_NAME", suigasComplaint.S_NO);
            return View(suigasComplaint);
        }

        // GET: SuigasComplaints/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuigasComplaint suigasComplaint = db.SuigasComplaints.Find(id);
            if (suigasComplaint == null)
            {
                return HttpNotFound();
            }
            return View(suigasComplaint);
        }

        // POST: SuigasComplaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            SuigasComplaint suigasComplaint = db.SuigasComplaints.Find(id);
            db.SuigasComplaints.Remove(suigasComplaint);
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
