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
    public class tblParentChildsController : Controller
    {
        private AftercareEntities db = new AftercareEntities();

        // GET: tblParentChilds
        public ActionResult Index()
        {
            var tblParentChilds = db.tblParentChilds.Include(t => t.tblChild).Include(t => t.tblParent);
            return View(tblParentChilds.ToList());
        }

        // GET: tblParentChilds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblParentChild tblParentChild = db.tblParentChilds.Find(id);
            if (tblParentChild == null)
            {
                return HttpNotFound();
            }
            return View(tblParentChild);
        }

        // GET: tblParentChilds/Create
        public ActionResult Create()
        {
            ViewBag.ChildID = new SelectList(db.tblChilds, "ChildID", "Name");
            ViewBag.ParentID = new SelectList(db.tblParents, "ParentID", "Name");
            ViewBag.ParentChildID = new SelectList(db.tblParentChilds, "ParentChildID", "ParentChildID");
            ViewBag.ParentChildID = new SelectList(db.tblParentChilds, "ParentChildID", "ParentChildID");
            return View();
        }

        // POST: tblParentChilds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParentChildID,ParentID,ChildID,Date")] tblParentChild tblParentChild)
        {
            if (ModelState.IsValid)
            {
                db.tblParentChilds.Add(tblParentChild);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChildID = new SelectList(db.tblChilds, "ChildID", "Name", tblParentChild.ChildID);
            ViewBag.ParentID = new SelectList(db.tblParents, "ParentID", "Name", tblParentChild.ParentID);
            ViewBag.ParentChildID = new SelectList(db.tblParentChilds, "ParentChildID", "ParentChildID", tblParentChild.ParentChildID);
            ViewBag.ParentChildID = new SelectList(db.tblParentChilds, "ParentChildID", "ParentChildID", tblParentChild.ParentChildID);
            return View(tblParentChild);
        }

        // GET: tblParentChilds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblParentChild tblParentChild = db.tblParentChilds.Find(id);
            if (tblParentChild == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChildID = new SelectList(db.tblChilds, "ChildID", "Name", tblParentChild.ChildID);
            ViewBag.ParentID = new SelectList(db.tblParents, "ParentID", "Name", tblParentChild.ParentID);
            ViewBag.ParentChildID = new SelectList(db.tblParentChilds, "ParentChildID", "ParentChildID", tblParentChild.ParentChildID);
            ViewBag.ParentChildID = new SelectList(db.tblParentChilds, "ParentChildID", "ParentChildID", tblParentChild.ParentChildID);
            return View(tblParentChild);
        }

        // POST: tblParentChilds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParentChildID,ParentID,ChildID,Date")] tblParentChild tblParentChild)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblParentChild).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChildID = new SelectList(db.tblChilds, "ChildID", "Name", tblParentChild.ChildID);
            ViewBag.ParentID = new SelectList(db.tblParents, "ParentID", "Name", tblParentChild.ParentID);
            ViewBag.ParentChildID = new SelectList(db.tblParentChilds, "ParentChildID", "ParentChildID", tblParentChild.ParentChildID);
            ViewBag.ParentChildID = new SelectList(db.tblParentChilds, "ParentChildID", "ParentChildID", tblParentChild.ParentChildID);
            return View(tblParentChild);
        }

        // GET: tblParentChilds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblParentChild tblParentChild = db.tblParentChilds.Find(id);
            if (tblParentChild == null)
            {
                return HttpNotFound();
            }
            return View(tblParentChild);
        }

        // POST: tblParentChilds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblParentChild tblParentChild = db.tblParentChilds.Find(id);
            db.tblParentChilds.Remove(tblParentChild);
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
