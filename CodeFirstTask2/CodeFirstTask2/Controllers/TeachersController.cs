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
    public class TeachersController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Teachers
        public ActionResult Index()
        {
            // Get list of Teachers with their associated Course
            var teachers = db.Teachers.Include(t => t.Courses).ToList();

            // Create a list of TeacherViewModel
            var teacherViewModels = teachers.Select(t => new TeacherViewModel
            {
                teacher = t,
                course = t.Courses.FirstOrDefault()
            }).ToList();

            return View(teacherViewModels);
        }

        // GET: Teachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Get the Teacher and their Course
            Teacher teacher = db.Teachers.Include(t => t.Courses).FirstOrDefault(t => t.TeacherId == id);
            if (teacher == null)
            {
                return HttpNotFound();
            }

            var viewModel = new TeacherViewModel
            {
                teacher = teacher,
                course = teacher.Courses.FirstOrDefault()
            };

            return View(viewModel);
        }

        // GET: Teachers/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName"); // Assuming you're using dropdown for Courses
            return View();
        }

        // POST: Teachers/Create
        // POST: Teachers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeacherViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the new Teacher to the context
                db.Teachers.Add(viewModel.teacher);
                db.SaveChanges(); // Save the teacher first to ensure the TeacherId is generated

                // Now retrieve the selected Course based on the CourseId from the view model
                var course = db.Courses.Find(viewModel.course.CourseId);

                if (course != null)
                {
                    // Assign the teacher to the course
                    course.TeacherId = viewModel.teacher.TeacherId;
                    db.Entry(course).State = EntityState.Modified;
                }

                db.SaveChanges(); // Save the changes again to ensure the course is linked
                return RedirectToAction("Index");
            }

            // If model state is invalid, reload the dropdown list and return the view
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", viewModel.course.CourseId);
            return View(viewModel);
        }


        // GET: Teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Teacher teacher = db.Teachers.Include(t => t.Courses).FirstOrDefault(t => t.TeacherId == id);
            if (teacher == null)
            {
                return HttpNotFound();
            }

            var viewModel = new TeacherViewModel
            {
                teacher = teacher,
                course = teacher.Courses.FirstOrDefault()
            };

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", teacher.Courses);
            return View(viewModel);
        }

        // POST: Teachers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TeacherViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viewModel.teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", viewModel.course.CourseId);
            return View(viewModel);
        }

        // GET: Teachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Teacher teacher = db.Teachers.Include(t => t.Courses).FirstOrDefault(t => t.TeacherId == id);
            if (teacher == null)
            {
                return HttpNotFound();
            }

            var viewModel = new TeacherViewModel
            {
                teacher = teacher,
                course = teacher.Courses.FirstOrDefault()
            };

            return View(viewModel);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = db.Teachers.Include(t => t.Courses).FirstOrDefault(t => t.TeacherId == id);
            if (teacher != null)
            {
                db.Teachers.Remove(teacher);
                db.SaveChanges();
            }

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
