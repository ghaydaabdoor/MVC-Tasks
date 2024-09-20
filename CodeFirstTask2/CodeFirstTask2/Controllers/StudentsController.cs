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

        // GET: Students/Index
        public ActionResult Index()
        {
            // Get list of Students with their StudentDetails
            var students = db.Students.Include(s => s.StudentDetails).ToList();

            // Create a list of StudentViewModel
            var studentViewModels = students.Select(s => new StudentViewModel
            {
                Student = s,
                StudentDetails = s.StudentDetails
            }).ToList();

            return View(studentViewModels);
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
        public ActionResult Create()
        {
            var viewModel = new StudentViewModel
            {
                Student = new Student(),
                StudentDetails = new StudentDetails()
            };

            return View();
        }




        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the Student and StudentDetails to the database
                viewModel.Student.StudentDetails = viewModel.StudentDetails;  // Set the relationship
                db.Students.Add(viewModel.Student);  // Add Student (which also adds StudentDetails due to the relationship)
                db.SaveChanges();  // Save changes to the database

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }


        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var student = db.Students.Include(s => s.StudentDetails).FirstOrDefault(s => s.StudentId == id);
            if (student == null)
            {
                return HttpNotFound();
            }

            var viewModel = new StudentViewModel
            {
                Student = student,
                StudentDetails = student.StudentDetails
            };

            return View(viewModel);
        }



        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Students/Edit/5
        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Update Student
                db.Entry(viewModel.Student).State = EntityState.Modified;

                // Update StudentDetails
                var studentDetails = db.StudentDetails.FirstOrDefault(sd => sd.StudentDetailsId == viewModel.StudentDetails.StudentDetailsId);
                if (studentDetails != null)
                {
                    studentDetails.Address = viewModel.StudentDetails.Address;
                    studentDetails.DateOfBirth = viewModel.StudentDetails.DateOfBirth;
                    db.Entry(studentDetails).State = EntityState.Modified;
                }

                db.SaveChanges();  // Save the changes to the database
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }



        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Get the Student and its StudentDetails
            var student = db.Students.Include(s => s.StudentDetails).FirstOrDefault(s => s.StudentId == id);
            if (student == null)
            {
                return HttpNotFound();
            }

            var viewModel = new StudentViewModel
            {
                Student = student,
                StudentDetails = student.StudentDetails
            };

            return View(viewModel);
        }


        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Find the student by ID
            var student = db.Students.Include(s => s.StudentDetails).FirstOrDefault(s => s.StudentId == id);
            if (student != null)
            {
                // Remove the StudentDetails first if required (depending on cascade delete settings)
                db.StudentDetails.Remove(student.StudentDetails);

                // Remove the Student
                db.Students.Remove(student);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
