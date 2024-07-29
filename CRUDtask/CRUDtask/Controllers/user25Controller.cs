using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDtask.Models;

namespace CRUDtask.Controllers
{
    public class user25Controller : Controller
    {
        private user28JulEntities2 db = new user28JulEntities2();

        // GET: user25
        public ActionResult Index()
        {
            return View(db.user25.ToList());
        }

        // GET: user25/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user25 user25 = db.user25.Find(id);
            if (user25 == null)
            {
                return HttpNotFound();
            }
            return View(user25);
        }

        // GET: user25/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: user25/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,Email,PasswordNew,images")] user25 user25)
        {
            if (ModelState.IsValid)
            {
                db.user25.Add(user25);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user25);
        }

        // GET: user25/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user25 user25 = db.user25.Find(id);
            if (user25 == null)
            {
                return HttpNotFound();
            }
            return View(user25);
        }

        // POST: user25/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,Email,PasswordNew,images")] user25 user25)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user25).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user25);
        }

        // GET: user25/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user25 user25 = db.user25.Find(id);
            if (user25 == null)
            {
                return HttpNotFound();
            }
            return View(user25);
        }

        // POST: user25/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user25 user25 = db.user25.Find(id);
            db.user25.Remove(user25);
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
