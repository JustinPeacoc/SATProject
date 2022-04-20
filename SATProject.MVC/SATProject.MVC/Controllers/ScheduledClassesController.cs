using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SATProject.MVC.DATA.EF;

namespace SATProject.MVC.Controllers
{
    public class ScheduledClassesController : Controller
    {
        private OrangeTrainingEntities db = new OrangeTrainingEntities();

        // GET: ScheduledClasses
        public ActionResult Index()
        {
            var scheduledClasses = db.ScheduledClasses.Include(s => s.Course).Include(s => s.ScheduledClassStatus);
            return View(scheduledClasses.ToList());
        }

        // GET: ScheduledClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduledClass scheduledClass = db.ScheduledClasses.Find(id);
            if (scheduledClass == null)
            {
                return HttpNotFound();
            }
            return View(scheduledClass);
        }

        // GET: ScheduledClasses/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.SCSID = new SelectList(db.ScheduledClassStatuses, "SCSID", "SCSName");
            return View();
        }

        // POST: ScheduledClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScheduledClassesID,CourseID,StartDate,EndDate,InstructorName,Location,SCSID")] ScheduledClass scheduledClass)
        {
            if (ModelState.IsValid)
            {
                db.ScheduledClasses.Add(scheduledClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", scheduledClass.CourseID);
            ViewBag.SCSID = new SelectList(db.ScheduledClassStatuses, "SCSID", "SCSName", scheduledClass.SCSID);
            return View(scheduledClass);
        }

        // GET: ScheduledClasses/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduledClass scheduledClass = db.ScheduledClasses.Find(id);
            if (scheduledClass == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", scheduledClass.CourseID);
            ViewBag.SCSID = new SelectList(db.ScheduledClassStatuses, "SCSID", "SCSName", scheduledClass.SCSID);
            return View(scheduledClass);
        }

        // POST: ScheduledClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScheduledClassesID,CourseID,StartDate,EndDate,InstructorName,Location,SCSID")] ScheduledClass scheduledClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduledClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", scheduledClass.CourseID);
            ViewBag.SCSID = new SelectList(db.ScheduledClassStatuses, "SCSID", "SCSName", scheduledClass.SCSID);
            return View(scheduledClass);
        }

        // GET: ScheduledClasses/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduledClass scheduledClass = db.ScheduledClasses.Find(id);
            if (scheduledClass == null)
            {
                return HttpNotFound();
            }
            return View(scheduledClass);
        }

        // POST: ScheduledClasses/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScheduledClass scheduledClass = db.ScheduledClasses.Find(id);
            db.ScheduledClasses.Remove(scheduledClass);
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
