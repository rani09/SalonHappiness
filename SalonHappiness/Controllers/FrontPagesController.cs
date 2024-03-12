using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SalonHappiness.Models;

namespace SalonHappiness.Controllers
{
    [Authorize(Roles = "User, Administrator")]
    public class FrontPagesController : Controller
    {
        private SalonDbContext db = new SalonDbContext();

        // GET: FrontPages
        public ActionResult Index()
        {
            return View(db.FrontPages.ToList());
        }

        // GET: FrontPages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FrontPage frontPage = db.FrontPages.Find(id);
            if (frontPage == null)
            {
                return HttpNotFound();
            }
            return View(frontPage);
        }

        // GET: FrontPages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FrontPages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FrontPageId,Title,Description,Active")] FrontPage frontPage, HttpPostedFileBase upload)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        var avatar = new FrontPageFile
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Avatar,
                            ContentType = upload.ContentType

                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            avatar.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        frontPage.FrontPageFiles = new List<FrontPageFile> { avatar };
                    }
                    db.FrontPages.Add(frontPage);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(frontPage);
        }

        // GET: FrontPages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FrontPage frontPage = db.FrontPages.Find(id);
            if (frontPage == null)
            {
                return HttpNotFound();
            }
            return View(frontPage);
        }

        // POST: FrontPages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, HttpPostedFileBase upload)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var portToUpdate = db.FrontPages.Find(id);
            if (TryUpdateModel(portToUpdate, "",
                new string[] { "FrontPageId", "Title", "Description", "Active" }))
            {
                try
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        if (portToUpdate.FrontPageFiles.Any(f => f.FileType == FileType.Avatar))
                        {
                            db.FrontPageFiles.Remove(portToUpdate.FrontPageFiles.First(f => f.FileType == FileType.Avatar));
                        }
                        var avatar = new FrontPageFile
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Avatar,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            avatar.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        portToUpdate.FrontPageFiles = new List<FrontPageFile> { avatar };
                    }
                    db.Entry(portToUpdate).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(portToUpdate);
        }

        // GET: FrontPages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FrontPage frontPage = db.FrontPages.Find(id);
            if (frontPage == null)
            {
                return HttpNotFound();
            }
            return View(frontPage);
        }

        // POST: FrontPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FrontPage frontPage = db.FrontPages.Find(id);
            db.FrontPages.Remove(frontPage);
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
