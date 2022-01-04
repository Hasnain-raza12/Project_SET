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
    public class WaterAndSewerageComplaintsController : Controller
    {
        private Karachi_Complaint_SystemEntities2 db = new Karachi_Complaint_SystemEntities2();

        // GET: WaterAndSewerageComplaints
        public ActionResult Index()
        {
            var waterAndSewerageComplaints = db.WaterAndSewerageComplaints.Include(w => w.Department);
            return View(waterAndSewerageComplaints.ToList());
        }

        // GET: WaterAndSewerageComplaints/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterAndSewerageComplaint waterAndSewerageComplaint = db.WaterAndSewerageComplaints.Find(id);
            if (waterAndSewerageComplaint == null)
            {
                return HttpNotFound();
            }
            return View(waterAndSewerageComplaint);
        }

        // GET: WaterAndSewerageComplaints/Create
        public ActionResult Create()
        {
            ViewBag.S_NO = new SelectList(db.Departments, "S_NO", "DEPT_NAME");
            return View();
        }

        // POST: WaterAndSewerageComplaints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CNIC_NO,NAME,CNIC_ADDRESS,AREA,COMPLAINT,S_NO")] WaterAndSewerageComplaint waterAndSewerageComplaint)
        {
            if (ModelState.IsValid)
            {
                db.WaterAndSewerageComplaints.Add(waterAndSewerageComplaint);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.S_NO = new SelectList(db.Departments, "S_NO", "DEPT_NAME", waterAndSewerageComplaint.S_NO);
            return View(waterAndSewerageComplaint);
        }

        // GET: WaterAndSewerageComplaints/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterAndSewerageComplaint waterAndSewerageComplaint = db.WaterAndSewerageComplaints.Find(id);
            if (waterAndSewerageComplaint == null)
            {
                return HttpNotFound();
            }
            ViewBag.S_NO = new SelectList(db.Departments, "S_NO", "DEPT_NAME", waterAndSewerageComplaint.S_NO);
            return View(waterAndSewerageComplaint);
        }

        // POST: WaterAndSewerageComplaints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CNIC_NO,NAME,CNIC_ADDRESS,AREA,COMPLAINT,S_NO")] WaterAndSewerageComplaint waterAndSewerageComplaint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(waterAndSewerageComplaint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.S_NO = new SelectList(db.Departments, "S_NO", "DEPT_NAME", waterAndSewerageComplaint.S_NO);
            return View(waterAndSewerageComplaint);
        }

        // GET: WaterAndSewerageComplaints/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterAndSewerageComplaint waterAndSewerageComplaint = db.WaterAndSewerageComplaints.Find(id);
            if (waterAndSewerageComplaint == null)
            {
                return HttpNotFound();
            }
            return View(waterAndSewerageComplaint);
        }

        // POST: WaterAndSewerageComplaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            WaterAndSewerageComplaint waterAndSewerageComplaint = db.WaterAndSewerageComplaints.Find(id);
            db.WaterAndSewerageComplaints.Remove(waterAndSewerageComplaint);
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
