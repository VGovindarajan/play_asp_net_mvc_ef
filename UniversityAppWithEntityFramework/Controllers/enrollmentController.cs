using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityAppWithEntityFramework.DataAccessLayer;
using UniversityAppWithEntityFramework.Models;

namespace UniversityAppWithEntityFramework.Content
{
    public class enrollmentController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: enrollment
        public ActionResult Index()
        {
            var enrollments = db.enrollments.Include(e => e.course).Include(e => e.student);
            return View(enrollments.ToList());
        }

        // GET: enrollment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enrollment enrollment = db.enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // GET: enrollment/Create
        public ActionResult Create()
        {
            ViewBag.courseid = new SelectList(db.courses, "courseid", "title");
            ViewBag.studentid = new SelectList(db.students, "studentid", "lastname");
            return View();
        }

        // POST: enrollment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "enrollmentid,courseid,studentid,grade")] enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.enrollments.Add(enrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.courseid = new SelectList(db.courses, "courseid", "title", enrollment.courseid);
            ViewBag.studentid = new SelectList(db.students, "studentid", "lastname", enrollment.studentid);
            return View(enrollment);
        }

        // GET: enrollment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enrollment enrollment = db.enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.courseid = new SelectList(db.courses, "courseid", "title", enrollment.courseid);
            ViewBag.studentid = new SelectList(db.students, "studentid", "lastname", enrollment.studentid);
            return View(enrollment);
        }

        // POST: enrollment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "enrollmentid,courseid,studentid,grade")] enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.courseid = new SelectList(db.courses, "courseid", "title", enrollment.courseid);
            ViewBag.studentid = new SelectList(db.students, "studentid", "lastname", enrollment.studentid);
            return View(enrollment);
        }

        // GET: enrollment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enrollment enrollment = db.enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // POST: enrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            enrollment enrollment = db.enrollments.Find(id);
            db.enrollments.Remove(enrollment);
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
