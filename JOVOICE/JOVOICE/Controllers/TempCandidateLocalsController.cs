using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JOVOICE.Models;

namespace JOVOICE.Controllers
{
    public class TempCandidateLocalsController : Controller
    {
        private ElectionEntities db = new ElectionEntities();

        // GET: TempCandidateLocals
        public ActionResult Index()
        {
            var tempCandidateLocals = db.TempCandidateLocals.Include(t => t.Admin).Include(t => t.LocalCandidate);
            return View(tempCandidateLocals.ToList());
        }

        // GET: TempCandidateLocals/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempCandidateLocal tempCandidateLocal = db.TempCandidateLocals.Find(id);
            if (tempCandidateLocal == null)
            {
                return HttpNotFound();
            }
            return View(tempCandidateLocal);
        }

        // GET: TempCandidateLocals/Create
        public ActionResult Create()
        {
            ViewBag.fk_admin = new SelectList(db.Admins, "id", "name");
            var model = new TempCandidateLocalsViewModel();
            // Populate any additional data for dropdowns if necessary
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TempCandidateLocalsViewModel model)
        {
            model.MaxCandidates = GetMaxCandidates(model.ElectionArea);
            if (ModelState.IsValid)
            {
                foreach (var candidate in model.Candidates)
                {
                    candidate.electionarea = model.ElectionArea;
                    candidate.city = model.City;
                    candidate.listname = model.ListName; // Assuming party name is common for all
                    db.TempCandidateLocals.Add(candidate);
                }
                db.SaveChanges();
                return RedirectToAction("candMain", "Home");
            }
            return View(model);
        }
        private int GetMaxCandidates(string electionArea)
        {
            switch (electionArea)
            {
                case "إربد الأولى":
                    return 8;
                case "إربد الثانية":
                    return 7;
                case "المفرق":
                    return 4;
                default:
                    return 10; // For all other areas
            }
        }



        // GET: TempCandidateLocals/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempCandidateLocal tempCandidateLocal = db.TempCandidateLocals.Find(id);
            if (tempCandidateLocal == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_admin = new SelectList(db.Admins, "id", "name", tempCandidateLocal.fk_admin);
            ViewBag.id = new SelectList(db.LocalCandidates, "id", "name", tempCandidateLocal.id);
            return View(tempCandidateLocal);
        }

        // POST: TempCandidateLocals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,national_id,name,listname,type_of_chair,gender,birthdate,votes_counter,religion,fk_admin,electionarea,city,email")] TempCandidateLocal tempCandidateLocal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tempCandidateLocal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_admin = new SelectList(db.Admins, "id", "name", tempCandidateLocal.fk_admin);
            ViewBag.id = new SelectList(db.LocalCandidates, "id", "name", tempCandidateLocal.id);
            return View(tempCandidateLocal);
        }

        // GET: TempCandidateLocals/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempCandidateLocal tempCandidateLocal = db.TempCandidateLocals.Find(id);
            if (tempCandidateLocal == null)
            {
                return HttpNotFound();
            }
            return View(tempCandidateLocal);
        }

        // POST: TempCandidateLocals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TempCandidateLocal tempCandidateLocal = db.TempCandidateLocals.Find(id);
            db.TempCandidateLocals.Remove(tempCandidateLocal);
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
