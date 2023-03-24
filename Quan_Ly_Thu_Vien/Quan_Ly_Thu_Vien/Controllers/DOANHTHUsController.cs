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
    public class DOANHTHUsController : Controller
    {
        private Quan_Ly_Thu_VienEntities1 db = new Quan_Ly_Thu_VienEntities1();

        // GET: DOANHTHUs
        public ActionResult Index()
        {
            return View(db.DOANHTHUs.ToList());
        }

        // GET: DOANHTHUs/Details/5
        public ActionResult Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOANHTHU dOANHTHU = db.DOANHTHUs.Find(id);
            if (dOANHTHU == null)
            {
                return HttpNotFound();
            }
            return View(dOANHTHU);
        }

        // GET: DOANHTHUs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DOANHTHUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NgayTK,KhoangThoiGian,TongTien")] DOANHTHU dOANHTHU)
        {
            if (ModelState.IsValid)
            {
                db.DOANHTHUs.Add(dOANHTHU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dOANHTHU);
        }

        // GET: DOANHTHUs/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOANHTHU dOANHTHU = db.DOANHTHUs.Find(id);
            if (dOANHTHU == null)
            {
                return HttpNotFound();
            }
            return View(dOANHTHU);
        }

        // POST: DOANHTHUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NgayTK,KhoangThoiGian,TongTien")] DOANHTHU dOANHTHU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOANHTHU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dOANHTHU);
        }

        // GET: DOANHTHUs/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOANHTHU dOANHTHU = db.DOANHTHUs.Find(id);
            if (dOANHTHU == null)
            {
                return HttpNotFound();
            }
            return View(dOANHTHU);
        }

        // POST: DOANHTHUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            DOANHTHU dOANHTHU = db.DOANHTHUs.Find(id);
            db.DOANHTHUs.Remove(dOANHTHU);
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
