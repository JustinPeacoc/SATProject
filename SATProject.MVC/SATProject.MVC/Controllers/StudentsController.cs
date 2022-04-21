using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SATProject.MVC.DATA.EF;
using SATProject.MVC.UtilityFolder;

namespace SATProject.MVC.Controllers
{
    public class StudentsController : Controller
    {
        private OrangeTrainingEntities db = new OrangeTrainingEntities();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.StudentStatus);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [Authorize(Roles = "Admin")]
        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.SSID = new SelectList(db.StudentStatuses, "SSID", "SSName");
            return View();
        }


        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "StudentID,FirstName,LastName,Major,Address,City,State,ZipCode,Phone,Email,PhotoURL,SSID")] Student student, HttpPostedFileBase studentImg)
        {
            if (ModelState.IsValid)
            {

                #region File Upload

                string file = "noImage.jpg";

                if (studentImg != null)
                {
                    file = studentImg.FileName;

                    string ext = file.Substring(file.LastIndexOf('.'));


                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif" };

                    //Check that the uploaded file ext is in our list of acceptable extensions
                    //and chekc that the file size <= 4MB, which is the default maximum for ASP.NET

                    if (goodExts.Contains(ext.ToLower()) && studentImg.ContentLength <= 4194304)
                    {
                        //Create a new file name (using a GUID)
                        file = Guid.NewGuid() + ext;

                        #region Resize Image

                        string savePath = Server.MapPath("~/Content/img/");

                        Image convertedImage = Image.FromStream(studentImg.InputStream);

                        int maxImageSize = 1000;

                        int maxThumbSize = 225;

                        ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);

                        #endregion
                    }

                    //No matter what, update the PhotoUrl with the value of the file variable
                    student.PhotoURL = file;
                }

                #endregion

                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            ViewBag.SSID = new SelectList(db.StudentStatuses, "SSID", "SSName", student.SSID);
            return View(student);
        }


        // GET: Students/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.SSID = new SelectList(db.StudentStatuses, "SSID", "SSName", student.SSID);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "StudentID,FirstName,LastName,Major,Address,City,State,ZipCode,Phone,Email,PhotoURL,SSID")] Student student, HttpPostedFileBase studentImg)
        {
            if (ModelState.IsValid)
            {
                #region File Upload

                string file = "noImage.jpg";

                if (studentImg != null)
                {
                    file = studentImg.FileName;

                    string ext = file.Substring(file.LastIndexOf('.'));


                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif" };

                    //Check that the uploaded file ext is in our list of acceptable extensions
                    //and chekc that the file size <= 4MB, which is the default maximum for ASP.NET

                    if (goodExts.Contains(ext.ToLower()) && studentImg.ContentLength <= 4194304)
                    {
                        //Create a new file name (using a GUID)
                        file = Guid.NewGuid() + ext;

                        #region Resize Image

                        string savePath = Server.MapPath("~/Content/img/");

                        Image convertedImage = Image.FromStream(studentImg.InputStream);

                        int maxImageSize = 1000;

                        int maxThumbSize = 225;

                        ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);

                        #endregion
                    }

                }
                //No matter what, update the PhotoUrl with the value of the file variable
                student.PhotoURL = file;

                #endregion
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SSID = new SelectList(db.StudentStatuses, "SSID", "SSName", student.SSID);
            return View(student);
        }


        // GET: Students/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
