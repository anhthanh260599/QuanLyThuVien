using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Quan_Ly_Thu_Vien.Models;

namespace Quan_Ly_Thu_Vien.Controllers
{
    public class PHONGHOPsController : Controller
    {
        private Quan_Ly_Thu_VienEntities1 db = new Quan_Ly_Thu_VienEntities1();

        // GET: PHONGHOPs
        public ActionResult Index()
        {
            return View(db.PHONGHOPs.ToList());
        }

        // GET: PHONGHOPs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHONGHOP pHONGHOP = db.PHONGHOPs.Find(id);
            if (pHONGHOP == null)
            {
                return HttpNotFound();
            }
            return View(pHONGHOP);
        }

        // GET: PHONGHOPs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PHONGHOPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPH,TinhTrang")] PHONGHOP pHONGHOP)
        {
            if (ModelState.IsValid)
            {
                db.PHONGHOPs.Add(pHONGHOP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pHONGHOP);
        }

        // GET: PHONGHOPs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHONGHOP pHONGHOP = db.PHONGHOPs.Find(id);
            if (pHONGHOP == null)
            {
                return HttpNotFound();
            }
            return View(pHONGHOP);
        }

        // POST: PHONGHOPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPH,TinhTrang")] PHONGHOP pHONGHOP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHONGHOP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pHONGHOP);
        }

        // GET: PHONGHOPs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHONGHOP pHONGHOP = db.PHONGHOPs.Find(id);
            if (pHONGHOP == null)
            {
                return HttpNotFound();
            }
            return View(pHONGHOP);
        }

        // POST: PHONGHOPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHONGHOP pHONGHOP = db.PHONGHOPs.Find(id);
            db.PHONGHOPs.Remove(pHONGHOP);
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
