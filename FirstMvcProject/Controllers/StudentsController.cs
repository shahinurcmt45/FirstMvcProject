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
        private StudentDbEntities2 db = new StudentDbEntities2();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.StudentsDatas.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsData studentsData = db.StudentsDatas.Find(id);
            if (studentsData == null)
            {
                return HttpNotFound();
            }
            return View(studentsData);
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
        public ActionResult Create([Bind(Include = "Id,Name,Email,PhoneNumber,Dob,State,City")] StudentsData studentsData)
        {
            if (ModelState.IsValid)
            {
                db.StudentsDatas.Add(studentsData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentsData);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsData studentsData = db.StudentsDatas.Find(id);
            if (studentsData == null)
            {
                return HttpNotFound();
            }
            return View(studentsData);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,PhoneNumber,Dob,State,City")] StudentsData studentsData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentsData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentsData);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsData studentsData = db.StudentsDatas.Find(id);
            if (studentsData == null)
            {
                return HttpNotFound();
            }
            return View(studentsData);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentsData studentsData = db.StudentsDatas.Find(id);
            db.StudentsDatas.Remove(studentsData);
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
