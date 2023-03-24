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
    public class HOIVIENsController : Controller
    {
        private Quan_Ly_Thu_VienEntities1 db = new Quan_Ly_Thu_VienEntities1();

        // GET: HOIVIENs
        public ActionResult Index()
        {
            return View(db.HOIVIENs.ToList());
        }

        // GET: HOIVIENs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOIVIEN hOIVIEN = db.HOIVIENs.Find(id);
            if (hOIVIEN == null)
            {
                return HttpNotFound();
            }
            return View(hOIVIEN);
        }

        // GET: HOIVIENs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HOIVIENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHV,TenHV,SDT,NgayLapThe,TinhTrang,DangMuon")] HOIVIEN hOIVIEN)
        {
            SetAlert("Thêm hội viên thành công!", 1);
            if (hOIVIEN.TinhTrang ==null)
            {
                SetAlert("Vui lòng nhập tình trạng", 3);
            }
            if (hOIVIEN.NgayLapThe == null)
            {
                SetAlert("Vui lòng nhập ngày lập thẻ", 3);
            }
            if (hOIVIEN.SDT == null)
            {
                SetAlert("Vui lòng nhập số điện thoại hội viên", 3);
            }
            if (hOIVIEN.TenHV == null)
            {
                SetAlert("Vui lòng nhập tên hội viên", 3);
            }
            if (hOIVIEN.MaHV == null)
            {
                SetAlert("Vui lòng nhập mã hội viên", 3);
            }

            try
            {
                db.HOIVIENs.Add(hOIVIEN);
                db.SaveChanges();
                return View();
            }
            catch
            {
                return View(hOIVIEN);
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

        // GET: HOIVIENs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOIVIEN hOIVIEN = db.HOIVIENs.Find(id);
            if (hOIVIEN == null)
            {
                return HttpNotFound();
            }
            return View(hOIVIEN);
        }

        // POST: HOIVIENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHV,TenHV,SDT,NgayLapThe,TinhTrang,DangMuon")] HOIVIEN hOIVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOIVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hOIVIEN);
        }

        // GET: HOIVIENs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOIVIEN hOIVIEN = db.HOIVIENs.Find(id);
            if (hOIVIEN == null)
            {
                return HttpNotFound();
            }
            return View(hOIVIEN);
        }

        // POST: HOIVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HOIVIEN hOIVIEN = db.HOIVIENs.Find(id);
            db.HOIVIENs.Remove(hOIVIEN);
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
