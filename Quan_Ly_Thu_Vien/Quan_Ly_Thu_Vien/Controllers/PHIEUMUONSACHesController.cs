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
    public class PHIEUMUONSACHesController : Controller
    {
        private Quan_Ly_Thu_VienEntities1 db = new Quan_Ly_Thu_VienEntities1();

        // GET: PHIEUMUONSACHes
        public ActionResult Index()
        {
            var pHIEUMUONSACHes = db.PHIEUMUONSACHes.Include(p => p.GIAHAN).Include(p => p.HOIVIEN);
            return View(pHIEUMUONSACHes.ToList());
        }

        // GET: PHIEUMUONSACHes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUMUONSACH pHIEUMUONSACH = db.PHIEUMUONSACHes.Find(id);
            if (pHIEUMUONSACH == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUMUONSACH);
        }

        // GET: PHIEUMUONSACHes/Create
        public ActionResult Create()
        {
            ViewBag.MaPhieu = new SelectList(db.GIAHANs, "MaPhieu", "MaPhieu");
            ViewBag.MaHV = new SelectList(db.HOIVIENs, "MaHV", "TenHV");
            return View();
        }

        // POST: PHIEUMUONSACHes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieu,MaHV,NgayMuon,NgayTra,ThoiHan,SoLuong")] PHIEUMUONSACH pHIEUMUONSACH)
        {
            SetAlert("Tạo phiếu mượn sách thành công!", 1);
            if (pHIEUMUONSACH.SoLuong < 1)
            {
                SetAlert("Vui lòng nhập số lượng sách mượn", 3);
            }
            if (pHIEUMUONSACH.ThoiHan == null)
            {
                SetAlert("Vui lòng nhập thời hạn mượn", 3);
            }
            if (pHIEUMUONSACH.NgayMuon == null)
            {
                SetAlert("Vui lòng nhập ngày mượn", 3);
            }

            try
            {
                db.PHIEUMUONSACHes.Add(pHIEUMUONSACH);
                db.SaveChanges();
                ViewBag.MaPhieu = new SelectList(db.GIAHANs, "MaPhieu", "MaPhieu", pHIEUMUONSACH.MaPhieu);
                ViewBag.MaHV = new SelectList(db.HOIVIENs, "MaHV", "TenHV", pHIEUMUONSACH.MaHV);
                return View(pHIEUMUONSACH);
            }
            catch
            {
                ViewBag.MaPhieu = new SelectList(db.GIAHANs, "MaPhieu", "MaPhieu", pHIEUMUONSACH.MaPhieu);
                ViewBag.MaHV = new SelectList(db.HOIVIENs, "MaHV", "TenHV", pHIEUMUONSACH.MaHV);
                return View(pHIEUMUONSACH);
            }
            
        }

        protected void SetAlert(string message, int type)
        {
            TempData["AlertMessage"] = message;
            if (type == 1)
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == 2)
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == 3)
            {
                TempData["AlertType"] = "alert-danger";
            }
            else
            {
                TempData["AlertType"] = "alert-info";
            }
        }

        // GET: PHIEUMUONSACHes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUMUONSACH pHIEUMUONSACH = db.PHIEUMUONSACHes.Find(id);
            if (pHIEUMUONSACH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPhieu = new SelectList(db.GIAHANs, "MaPhieu", "MaPhieu", pHIEUMUONSACH.MaPhieu);
            ViewBag.MaHV = new SelectList(db.HOIVIENs, "MaHV", "TenHV", pHIEUMUONSACH.MaHV);
            return View(pHIEUMUONSACH);
        }

        // POST: PHIEUMUONSACHes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieu,MaHV,NgayMuon,NgayTra,ThoiHan,SoLuong")] PHIEUMUONSACH pHIEUMUONSACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEUMUONSACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPhieu = new SelectList(db.GIAHANs, "MaPhieu", "MaPhieu", pHIEUMUONSACH.MaPhieu);
            ViewBag.MaHV = new SelectList(db.HOIVIENs, "MaHV", "TenHV", pHIEUMUONSACH.MaHV);
            return View(pHIEUMUONSACH);
        }

        // GET: PHIEUMUONSACHes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUMUONSACH pHIEUMUONSACH = db.PHIEUMUONSACHes.Find(id);
            if (pHIEUMUONSACH == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUMUONSACH);
        }

        // POST: PHIEUMUONSACHes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHIEUMUONSACH pHIEUMUONSACH = db.PHIEUMUONSACHes.Find(id);
            db.PHIEUMUONSACHes.Remove(pHIEUMUONSACH);
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
