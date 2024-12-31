using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FirstMvcProject.Models;

namespace FirstMvcProject.Controllers
{
    public class StudentsController : Controller
    {
        private StudentDbEntities db = new StudentDbEntities();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Student_Data.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Data student_Data = db.Student_Data.Find(id);
            if (student_Data == null)
            {
                return HttpNotFound();
            }
            return View(student_Data);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,PhoneNumber,Dob,State,City")] Student_Data student_Data)
        {
            if (ModelState.IsValid)
            {
                db.Student_Data.Add(student_Data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student_Data);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Data student_Data = db.Student_Data.Find(id);
            if (student_Data == null)
            {
                return HttpNotFound();
            }
            return View(student_Data);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,PhoneNumber,Dob,State,City")] Student_Data student_Data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_Data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student_Data);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Data student_Data = db.Student_Data.Find(id);
            if (student_Data == null)
            {
                return HttpNotFound();
            }
            return View(student_Data);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_Data student_Data = db.Student_Data.Find(id);
            db.Student_Data.Remove(student_Data);
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
