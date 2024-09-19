using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirstTask2.Models;

namespace CodeFirstTask2.Controllers
{
    public class StudentsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.StudentDetails);
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

        // GET: Students/Create
        // GET: Students/Create
        public ActionResult Create()
        {
            var student = new Student
            {
                StudentDetails = new StudentDetails()
            };

            return View(student);  // Passing an empty Student object with initialized StudentDetails
        }


        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,FirstName,LastName,StudentDetails.Address,StudentDetails.DateOfBirth")] Student student)
        {
            if (ModelState.IsValid)
            {
                if (student.StudentDetails != null)
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }


        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = db.Students.Include(s => s.StudentDetails).FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }


        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,FirstName,LastName,StudentDetails.Address,StudentDetails.DateOfBirth")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;

                var studentDetails = db.StudentDetails.FirstOrDefault(sd => sd.StudentDetailsId == student.StudentDetails.StudentDetailsId);
                if (studentDetails != null)
                {
                    studentDetails.Address = student.StudentDetails.Address;
                    studentDetails.DateOfBirth = student.StudentDetails.DateOfBirth;
                    db.Entry(studentDetails).State = EntityState.Modified;
                }
                else
                {
                    db.StudentDetails.Add(student.StudentDetails);
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }


        // GET: Students/Delete/5
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
