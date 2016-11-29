﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using xtrade.Models;

namespace xtrade.Controllers
{
    public class ItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(string CategoryName="")
        {
            List<Item> fulllist = db.Items.ToList();
            List<Item> items;
            if (CategoryName.Length != 0)
                items = fulllist.Where(x => x.Category.CategoryName.CompareTo(CategoryName) == 0).ToList(); 
            else
                items = fulllist;
                       
            items.Sort((x, y) => x.Category.CategoryName.CompareTo(y.Category.CategoryName));

            items.Sort((x, y) => x.Seller.Substring(0,1).CompareTo(y.Seller.Substring(0,1)));
            //return View(db.Items.ToList());
            return View(items);
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Single(s => s.Id == id);
            //db.Entry(item).Collection(u => u.Images)
            //    .Query().Where(image => image.DoNotDisplay == false).Load();


            item.Images = db.Images.Where(s => s.ItemId == item.Id).ToList();

            List<Image> iss = new List<Image>();
            
            foreach (Image i in item.Images)
            {
                if(!i.DoNotDisplay)
                {
                    iss.Add(i);
                }
            }
            item.Images = iss;

            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Seller,Buyer,Amount,Name,Description,CategoryId")] Item item, IEnumerable<HttpPostedFileBase> files)
        {
            item.Seller = User.Identity.Name;
            item.Images = new List<Image>();
            foreach (var upload in files)
            {                
                if (upload != null && upload.ContentLength > 0)
                {

                    //var fileName = Path.GetFileName(upload.FileName);
                    //var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                    //upload.SaveAs(path);

                    Image image = new Image();
                    image.ImageName = System.IO.Path.GetFileName(upload.FileName);
                    image.ContentType = upload.ContentType;
                    image.DoNotDisplay = false;
                    //image.ItemId = item.Id;

                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        image.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    //item.Images = new List<File> { image };
                    item.Images.Add(image);

                }
            }

            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: Items/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Item item = db.Items.Include(s => s.Images).SingleOrDefault(s => s.Id == id);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");

            Item item = db.Items.Single(s => s.Id == id);
            db.Entry(item).Collection(u => u.Images)
                .Query().Where(image => image.DoNotDisplay == false).Load();


            List<Image> iss = new List<Image>();
            foreach (Image i in item.Images)
            {
                if (!i.DoNotDisplay)
                {
                    iss.Add(i);
                }
            }
            item.Images = iss;

            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Seller,Buyer,Amount,Name,Description,DoNotDisplayImages,CategoryId")] Item item, IEnumerable<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {
                item.Seller = User.Identity.Name;
                List<Image> images = db.Images.Where(s => s.ItemId == item.Id).ToList();

                List<string> doNotDisplayIds = item.DoNotDisplayImages != null?
                        item.DoNotDisplayImages.Split(',').ToList(): new List<string>();

                item.Images = new List<Image>();

                foreach (Image image in images){
                    
                    if (image.DoNotDisplay || doNotDisplayIds != null && doNotDisplayIds.Contains(image.ImageId.ToString()))
                    {
                        image.DoNotDisplay = true;
                    }
                    else
                    {
                        image.DoNotDisplay = false;
                    }
                    item.Images.Add(image);
                    //db.Entry(image).State = EntityState.Modified;
                    //db.SaveChanges();
                }

                db.Items.Attach(item);


                
                foreach (var upload in files)
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        Image image = new Image();
                        image.ImageName = System.IO.Path.GetFileName(upload.FileName);
                        image.ContentType = upload.ContentType;
                        image.DoNotDisplay = false;
                        image.ItemId = item.Id;

                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            image.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        //item.Images = new List<File> { image };
                        item.Images.Add(image);
                        //db.Entry(image).State = EntityState.Modified;
                        //db.SaveChanges();
                    }
                }

                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: Items/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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
