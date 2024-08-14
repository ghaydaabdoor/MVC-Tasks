using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aug13.Models;

namespace Aug13.Controllers
{
    public class ProductTable13AuggController : Controller
    {
        private ProductTask13AugEntities1 db = new ProductTask13AugEntities1();

        // GET: ProductTable13Augg
        public ActionResult Index()
        {
            return View(db.ProductTable13Augg.ToList());
        }

        // GET: ProductTable13Augg/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTable13Augg productTable13Augg = db.ProductTable13Augg.Find(id);
            if (productTable13Augg == null)
            {
                return HttpNotFound();
            }
            return View(productTable13Augg);
        }

        // GET: ProductTable13Augg/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductTable13Augg/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,imgURL,ProductName,ProductPrice")] ProductTable13Augg productTable13Augg)
        {
            if (ModelState.IsValid)
            {
                db.ProductTable13Augg.Add(productTable13Augg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productTable13Augg);
        }

        // GET: ProductTable13Augg/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTable13Augg productTable13Augg = db.ProductTable13Augg.Find(id);
            if (productTable13Augg == null)
            {
                return HttpNotFound();
            }
            return View(productTable13Augg);
        }

        // POST: ProductTable13Augg/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,imgURL,ProductName,ProductPrice")] ProductTable13Augg productTable13Augg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productTable13Augg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productTable13Augg);
        }

        // GET: ProductTable13Augg/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTable13Augg productTable13Augg = db.ProductTable13Augg.Find(id);
            if (productTable13Augg == null)
            {
                return HttpNotFound();
            }
            return View(productTable13Augg);
        }

        // POST: ProductTable13Augg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductTable13Augg productTable13Augg = db.ProductTable13Augg.Find(id);
            db.ProductTable13Augg.Remove(productTable13Augg);
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
