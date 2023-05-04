using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyThuVienCNPMNC.Models;

namespace QuanLyThuVienCNPMNC.Controllers
{
    public class BoiThuongController : Controller
    {
        private Quan_Ly_Thu_VienEntities db = new Quan_Ly_Thu_VienEntities();

        // GET: BoiThuong
        public ActionResult Index()
        {
            var bOITHUONGs = db.BOITHUONGs.Include(b => b.HOIVIEN).Include(b => b.SACH);
            return View(bOITHUONGs.ToList());
        }

        // GET: BoiThuong/Details/5
        public ActionResult Details(string id, string id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOITHUONG bOITHUONG = db.BOITHUONGs.Where(s => s.MaHV == id && s.MaSach == id1).FirstOrDefault();
            if (bOITHUONG == null)
            {
                return HttpNotFound();
            }
            return View(bOITHUONG);
        }

        // GET: BoiThuong/Create
        public ActionResult Create()
        {
            ViewBag.MaHV = db.HOIVIENs.Select(x => new SelectListItem { Text = x.MaHV + " - " + x.TenHV, Value = x.MaHV.ToString() }).ToList();
            //ViewBag.MaHV = new SelectList(db.HOIVIENs, "MaHV", "TenHV");

            ViewBag.MaSach = db.SACHes.Select(x => new SelectListItem { Text = x.MaSach + " - " + x.DAUSACH.TenSach, Value = x.MaSach.ToString() }).ToList();
            //ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "MaDS");
            var tinhtrangList = new List<SelectListItem>
            {
                    new SelectListItem { Value = "1", Text = "Chưa đóng phạt" },
                    new SelectListItem { Value = "2", Text = "Đã đóng" }
            };
            ViewBag.tinhtrangthe = new SelectList(tinhtrangList, "Value", "Text");

            return View();
        }

        // POST: BoiThuong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHV,MaSach,GiaTien,TinhTrang")] BOITHUONG bOITHUONG)
        {
            if (ModelState.IsValid)
            {
                db.BOITHUONGs.Add(bOITHUONG);
                db.SaveChanges();
                using (var context1 = new Quan_Ly_Thu_VienEntities())
                {
                    context1.sp_CapNhatTinhTrangTheHoiVien(bOITHUONG.MaHV);
                }
                TempData["Message"] = "Them thanh cong !!!";
                return RedirectToAction("Index");
            }

            ViewBag.MaHV = new SelectList(db.HOIVIENs, "MaHV", "TenHV", bOITHUONG.MaHV);
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "MaDS", bOITHUONG.MaSach);
            var tinhtrangList = new List<SelectListItem>
            {
                    new SelectListItem { Value = "1", Text = "Chưa đóng phạt" },
                    new SelectListItem { Value = "2", Text = "Đã đóng" }
            };
            ViewBag.tinhtrangthe = new SelectList(tinhtrangList, "Value", "Text", bOITHUONG.TinhTrang);

            return View(bOITHUONG);
        }

        // GET: BoiThuong/Edit/5
        public ActionResult Edit(string id, string id1)
        {

            if (id == null || id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOITHUONG bOITHUONG = db.BOITHUONGs.Where(s => s.MaHV == id && s.MaSach == id1).FirstOrDefault();
            if (bOITHUONG == null)
            {
                return HttpNotFound();
            }
            var tinhtrangList = new List<SelectListItem>
            {
                    new SelectListItem { Value = "1", Text = "Chưa đóng phạt" },
                    new SelectListItem { Value = "2", Text = "Đã đóng" }
            };
            ViewBag.MaHV = new SelectList(db.HOIVIENs, "MaHV", "TenHV", bOITHUONG.MaHV);
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "MaDS", bOITHUONG.MaSach);
            ViewBag.tinhtrangthe = new SelectList(tinhtrangList, "Value", "Text", bOITHUONG.TinhTrang);
      
            return View(bOITHUONG);
        }

        // POST: BoiThuong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHV,MaSach,GiaTien,TinhTrang")] BOITHUONG bOITHUONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bOITHUONG).State = EntityState.Modified;
                db.SaveChanges();
                using (var context1 = new Quan_Ly_Thu_VienEntities())
                {
                    context1.sp_CapNhatTinhTrangTheHoiVien(bOITHUONG.MaHV);
                }
                TempData["Message"] = "Cap nhat thanh cong !!!";
                return RedirectToAction("Index");
            }
            ViewBag.MaHV = new SelectList(db.HOIVIENs, "MaHV", "TenHV", bOITHUONG.MaHV);
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "MaDS", bOITHUONG.MaSach);
            var tinhtrangList = new List<SelectListItem>
            {
                    new SelectListItem { Value = "1", Text = "Chưa đóng phạt" },
                    new SelectListItem { Value = "2", Text = "Đã đóng" }
            };
            ViewBag.tinhtrangthe = new SelectList(tinhtrangList, "Value", "Text", bOITHUONG.TinhTrang);

            return View(bOITHUONG);
        }

        // GET: BoiThuong/Delete/5
        public ActionResult Delete(string id,string id1)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOITHUONG bOITHUONG = db.BOITHUONGs.Where(s => s.MaHV == id && s.MaSach == id1).FirstOrDefault();
            if (bOITHUONG == null)
            {
                return HttpNotFound();
            }

            return View(bOITHUONG);
        }

        // POST: BoiThuong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, string id1)
        {
            BOITHUONG bOITHUONG = db.BOITHUONGs.Where(s => s.MaHV == id && s.MaSach == id1).FirstOrDefault();
            db.BOITHUONGs.Remove(bOITHUONG);
            db.SaveChanges();
            using (var context1 = new Quan_Ly_Thu_VienEntities())
            {
                context1.sp_CapNhatTinhTrangTheHoiVien(bOITHUONG.MaHV);
            }
            TempData["Message"] = "Xoa thanh cong !!!";
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
