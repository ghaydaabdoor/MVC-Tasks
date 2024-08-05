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
    public class TempPartyCandidatesController : Controller
    {
        private ElectionEntities db = new ElectionEntities();

        // GET: TempPartyCandidates
        public ActionResult Index()
        {
            var tempPartyCandidates = db.TempPartyCandidates.Include(t => t.Admin).Include(t => t.PartyCandidate);
            return View(tempPartyCandidates.ToList());
        }

        // GET: TempPartyCandidates/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempPartyCandidate tempPartyCandidate = db.TempPartyCandidates.Find(id);
            if (tempPartyCandidate == null)
            {
                return HttpNotFound();
            }
            return View(tempPartyCandidate);
        }

        // GET: TempPartyCandidates/Create
        public ActionResult Create()
        {
            ViewBag.fk_admin = new SelectList(db.Admins, "id", "name");
            var model = new TempPartyCandidateViewModel();
            // Populate any additional data for dropdowns if necessary
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TempPartyCandidateViewModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var candidate in model.Candidates)
                {
                    candidate.electionarea = model.ElectionArea;
                    candidate.city = model.City;
                    candidate.partyname = model.PartyName; // Assuming party name is common for all
                    db.TempPartyCandidates.Add(candidate);
                }
                db.SaveChanges();
                return RedirectToAction("candMain", "Home");
            }
            return View(model);
        }


        // GET: TempPartyCandidates/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempPartyCandidate tempPartyCandidate = db.TempPartyCandidates.Find(id);
            if (tempPartyCandidate == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_admin = new SelectList(db.Admins, "id", "name", tempPartyCandidate.fk_admin);
            ViewBag.id = new SelectList(db.PartyCandidates, "id", "partyname", tempPartyCandidate.id);
            return View(tempPartyCandidate);
        }

        // POST: TempPartyCandidates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,national_id,electionarea,email,partyname,gender,birthdate,religion,ordercandidate,candidatename,fk_admin,city")] TempPartyCandidate tempPartyCandidate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tempPartyCandidate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_admin = new SelectList(db.Admins, "id", "name", tempPartyCandidate.fk_admin);
            ViewBag.id = new SelectList(db.PartyCandidates, "id", "partyname", tempPartyCandidate.id);
            return View(tempPartyCandidate);
        }

        // GET: TempPartyCandidates/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempPartyCandidate tempPartyCandidate = db.TempPartyCandidates.Find(id);
            if (tempPartyCandidate == null)
            {
                return HttpNotFound();
            }
            return View(tempPartyCandidate);
        }

        // POST: TempPartyCandidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TempPartyCandidate tempPartyCandidate = db.TempPartyCandidates.Find(id);
            db.TempPartyCandidates.Remove(tempPartyCandidate);
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
