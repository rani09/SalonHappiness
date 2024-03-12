﻿using SalonHappiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonHappiness.Controllers
{
    public class AboutUsFileController : Controller
    {
        private SalonDbContext db = new SalonDbContext();
        // GET: EducationFile
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.AboutUsFiles.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}