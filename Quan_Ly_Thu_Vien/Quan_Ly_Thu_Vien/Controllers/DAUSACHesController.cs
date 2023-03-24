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
    public class DAUSACHesController : Controller 
    {
        private Quan_Ly_Thu_VienEntities1 db = new Quan_Ly_Thu_VienEntities1();

        // GET: DAUSACHes
        public ActionResult Index()
        {
            return View(db.DAUSACHes.ToList());
        }

        // GET: DAUSACHes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAUSACH dAUSACH = db.DAUSACHes.Find(id);
            if (dAUSACH == null)
            {
                return HttpNotFound();
            }
            return View(dAUSACH);
        }

        // GET: DAUSACHes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DAUSACHes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDS,TenSach,Theloai,NXB,NgayXuatBan,TenTG")] DAUSACH dAUSACH)
        {

            SetAlert("Tạo đầu sách thành công!", 1);
            if (dAUSACH.TenTG==null)
            {
                SetAlert("Vui lòng nhập tên tác giả", 3);
            }
            if (dAUSACH.NgayXuatBan == null)
            {
                SetAlert("Vui lòng nhập ngày xuất bản", 3);
            }
            if (dAUSACH.NXB == null)
            {
                SetAlert("Vui lòng nhập nhà xuất bản", 3);
            }
            if (dAUSACH.Theloai == null)
            {
                SetAlert("Vui lòng nhập thể loại", 3);
            }
            if (dAUSACH.TenSach == null)
            {
                SetAlert("Vui lòng nhập tên sách", 3);
            }
            if (dAUSACH.TenTG == null)
            {
                SetAlert("Vui lòng nhập mã đầu sách", 3);
            }

            try
            {
                    // TODO: Add insert logic here
                    db.DAUSACHes.Add(dAUSACH);
                    db.SaveChanges();
                    return View();
            }
            catch
            {
                return View();
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
        // GET: DAUSACHes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAUSACH dAUSACH = db.DAUSACHes.Find(id);
            if (dAUSACH == null)
            {
                return HttpNotFound();
            }
            return View(dAUSACH);
        }

        // POST: DAUSACHes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDS,TenSach,Theloai,NXB,NgayXuatBan,TenTG")] DAUSACH dAUSACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dAUSACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dAUSACH);
        }

        // GET: DAUSACHes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAUSACH dAUSACH = db.DAUSACHes.Find(id);
            if (dAUSACH == null)
            {
                return HttpNotFound();
            }
            return View(dAUSACH);
        }

        // POST: DAUSACHes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DAUSACH dAUSACH = db.DAUSACHes.Find(id);
            db.DAUSACHes.Remove(dAUSACH);
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
