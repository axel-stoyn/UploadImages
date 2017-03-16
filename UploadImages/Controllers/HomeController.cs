using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UploadImages.DataBaseContext;
using UploadImages.Models;

namespace UploadImages.Controllers
{
    public class HomeController : Controller
    {
        private ImageDbContext db = new ImageDbContext();

        public ActionResult Index()
        {
            return View(db.Images);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Picture pic, HttpPostedFileBase uploadImage)
        {
            try
            {
                if (ModelState.IsValid && uploadImage != null)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    pic.Image = imageData;

                    db.Images.Add(pic);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch(DataException)
            {
                ModelState.AddModelError("", "Unable to add. Try again, and if the problem persists see your system administrator.");

            }
            return View("Index");

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }


        [HttpPost, ActionName("EditPartial")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(Picture img)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(img).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(img);
        }

        public JsonResult GetData()
        {
            List<Picture> images = new List<Picture>();
            foreach(var item in images)
            {
                images.Add(new Picture()
                {
                    GeoLat = item.GeoLat,
                    GeoLong = item.GeoLong
                });
            }

            return Json(images, JsonRequestBehavior.AllowGet);
        }

    }
}