using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RPAftercare.Models;

namespace RPAftercare.Controllers
{
    public class tblParentsController : Controller
    {
        private AftercareEntities db = new AftercareEntities();

        // GET: tblParents
        public ActionResult Index()
        {
            return View(db.tblParents.ToList());
        }

        // GET: tblParents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblParent tblParent = db.tblParents.Find(id);
            if (tblParent == null)
            {
                return HttpNotFound();
            }
            return View(tblParent);
        }

        // GET: tblParents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblParents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParentID,Name,Surname,IDNumber,WorkNo,HomeNo,CellNo,Email")] tblParent tblParent)
        {
            if (ModelState.IsValid)
            {
                db.tblParents.Add(tblParent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblParent);
        }

        // GET: tblParents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblParent tblParent = db.tblParents.Find(id);
            if (tblParent == null)
            {
                return HttpNotFound();
            }
            return View(tblParent);
        }

        // POST: tblParents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParentID,Name,Surname,IDNumber,WorkNo,HomeNo,CellNo,Email")] tblParent tblParent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblParent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblParent);
        }

        // GET: tblParents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblParent tblParent = db.tblParents.Find(id);
            if (tblParent == null)
            {
                return HttpNotFound();
            }
            return View(tblParent);
        }

        // POST: tblParents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblParent tblParent = db.tblParents.Find(id);
            db.tblParents.Remove(tblParent);
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
