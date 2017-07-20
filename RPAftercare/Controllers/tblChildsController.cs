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
    public class tblChildsController : Controller
    {
        private AftercareEntities db = new AftercareEntities();

        // GET: tblChilds
        public ActionResult Index()
        {
            return View(db.tblChilds.ToList());
        }

        // GET: tblChilds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChild tblChild = db.tblChilds.Find(id);
            if (tblChild == null)
            {
                return HttpNotFound();
            }
            return View(tblChild);
        }

        // GET: tblChilds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblChilds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChildID,Name,Surname,Grade,Age")] tblChild tblChild)
        {
            if (ModelState.IsValid)
            {
                db.tblChilds.Add(tblChild);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblChild);
        }

        // GET: tblChilds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChild tblChild = db.tblChilds.Find(id);
            if (tblChild == null)
            {
                return HttpNotFound();
            }
            return View(tblChild);
        }

        // POST: tblChilds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChildID,Name,Surname,Grade,Age")] tblChild tblChild)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblChild).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblChild);
        }

        // GET: tblChilds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChild tblChild = db.tblChilds.Find(id);
            if (tblChild == null)
            {
                return HttpNotFound();
            }
            return View(tblChild);
        }

        // POST: tblChilds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblChild tblChild = db.tblChilds.Find(id);
            db.tblChilds.Remove(tblChild);
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
