﻿using System;
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
    public class HairstylesController : Controller
    {
        private SalonDbContext db = new SalonDbContext();

        // GET: Hairstyles
        public ActionResult Index()
        {
            return View(db.Hairstyles.ToList());
        }

        // GET: Hairstyles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hairstyle hairstyle = db.Hairstyles.Find(id);
            if (hairstyle == null)
            {
                return HttpNotFound();
            }
            return View(hairstyle);
        }

        // GET: Hairstyles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hairstyles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HairstyleId,Name,Description,City,DateCreated,Active")] Hairstyle hairstyle, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        var avatar = new HairstyleFile
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Avatar,
                            ContentType = upload.ContentType

                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            avatar.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        hairstyle.HairstyleFiles = new List<HairstyleFile> { avatar };
                    }
                    db.Hairstyles.Add(hairstyle);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(hairstyle);
        }

        // GET: Hairstyles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hairstyle hairstyle = db.Hairstyles.Find(id);
            if (hairstyle == null)
            {
                return HttpNotFound();
            }
            return View(hairstyle);
        }

        // POST: Hairstyles/Edit/5
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
            var portToUpdate = db.Hairstyles.Find(id);
            if (TryUpdateModel(portToUpdate, "",
                new string[] { "HairstyleId", "Name", "Description", "City", "DateCreated", "Active" }))
            {
                try
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        if (portToUpdate.HairstyleFiles.Any(f => f.FileType == FileType.Avatar))
                        {
                            db.HairstyleFiles.Remove(portToUpdate.HairstyleFiles.First(f => f.FileType == FileType.Avatar));
                        }
                        var avatar = new HairstyleFile
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Avatar,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            avatar.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        portToUpdate.HairstyleFiles = new List<HairstyleFile> { avatar };
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

        // GET: Hairstyles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hairstyle hairstyle = db.Hairstyles.Find(id);
            if (hairstyle == null)
            {
                return HttpNotFound();
            }
            return View(hairstyle);
        }

        // POST: Hairstyles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hairstyle hairstyle = db.Hairstyles.Find(id);
            db.Hairstyles.Remove(hairstyle);
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