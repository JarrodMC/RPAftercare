using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using RPAftercare.Models;

namespace RPAftercare.Controllers
{
    public class UploadsController : Controller
    {
        private AftercareEntities db = new AftercareEntities();

        // GET: Uploads
        public ActionResult Index()
        {
            return View(db.tblUploads.ToList());
        }

        // GET: Uploads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUpload tblUpload = db.tblUploads.Find(id);
            if (tblUpload == null)
            {
                return HttpNotFound();
            }
            return View(tblUpload);
        }

        // GET: Uploads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Uploads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblUpload upload, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var path = Path.Combine(Server.MapPath("~/UploadedFiles"), Path.GetFileName(file.FileName));
                file.SaveAs(path);

                db.tblUploads.Add(new tblUpload
                {
                    UploadID = upload.UploadID, fileName = upload.fileName, filePath = "~/UploadedFiles/" + file.FileName
                });

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Uploads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUpload tblUpload = db.tblUploads.Find(id);
            if (tblUpload == null)
            {
                return HttpNotFound();
            }
            return View(tblUpload);
        }

        // POST: Uploads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UploadID,fileName,filePath")] tblUpload tblUpload)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblUpload).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblUpload);
        }

        // GET: Uploads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUpload tblUpload = db.tblUploads.Find(id);
            if (tblUpload == null)
            {
                return HttpNotFound();
            }
            return View(tblUpload);
        }

        // POST: Uploads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblUpload tblUpload = db.tblUploads.Find(id);
            db.tblUploads.Remove(tblUpload);
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
