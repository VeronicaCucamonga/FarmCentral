using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FarmCentralWebApp.Models;

namespace FarmCentralWebApp.Controllers
{
    //---------- CODE ATTRIBUTION ----------
    //Author: CodeWithGopi
    //Published Date: 7 July 2021
    //Title: Asp .Net MVC Full CRUD Operation Using Entity Framework DB First | CRUD Operations in MVC
    //URL: https://youtu.be/OLBmtRFFwcQ

    //Farmer Controller that preforms CRUD methods
    public class FarmersController : Controller
    {
        private FarmCentralEntities db = new FarmCentralEntities();

        // GET: Farmers
        public ActionResult Index()
        {
            return View(db.tblFarmers.ToList());
        }

        // GET: Farmers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFarmer tblFarmer = db.tblFarmers.Find(id);
            if (tblFarmer == null)
            {
                return HttpNotFound();
            }
            return View(tblFarmer);
        }

        // GET: Farmers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Farmers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fullname,username,password")] tblFarmer tblFarmer)
        {
            if (ModelState.IsValid)
            {
                db.tblFarmers.Add(tblFarmer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblFarmer);
        }

        // GET: Farmers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFarmer tblFarmer = db.tblFarmers.Find(id);
            if (tblFarmer == null)
            {
                return HttpNotFound();
            }
            return View(tblFarmer);
        }

        // POST: Farmers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fullname,username,password")] tblFarmer tblFarmer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblFarmer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblFarmer);
        }

        // GET: Farmers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFarmer tblFarmer = db.tblFarmers.Find(id);
            if (tblFarmer == null)
            {
                return HttpNotFound();
            }
            return View(tblFarmer);
        }

        // POST: Farmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblFarmer tblFarmer = db.tblFarmers.Find(id);
            db.tblFarmers.Remove(tblFarmer);
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
    //---------- CODE ATTRIBUTION ENDS ----------
}
