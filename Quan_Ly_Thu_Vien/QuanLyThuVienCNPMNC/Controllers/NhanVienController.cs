using PagedList;
using QuanLyThuVienCNPMNC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyThuVienCNPMNC.Controllers
{
    public class NhanVienController : Controller
    {
        public object ListtoDataConverter { get; private set; }
        Quan_Ly_Thu_VienEntities databases = new Quan_Ly_Thu_VienEntities();
        // GET: DocGia
        public ActionResult Index()
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            var count = databases.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && s.MaChucNang == "CN04");
            if (count == 0)
            {
                TempData["Message"] = "Ban khong co quyen truy cap vao chuc nang nay !!!";
                return RedirectToAction("Index", "TrangChu");

            }
            else
            {

                return View(databases.NHANVIENs.ToList());
            }

        }
        //Tu tao key
        public string CapNhatKey()
        {

            int newNumber = 1;
            var list = databases.NHANVIENs.OrderByDescending(s => s.MaNV);
            if (list == null)
            {
                newNumber = 1;
            }
            else
            {
                string convertNewNumber = "NV" + newNumber.ToString("000");
                while (databases.NHANVIENs.Any(p => p.MaNV == convertNewNumber))
                {
                    newNumber++;
                    convertNewNumber = "NV" + newNumber.ToString("000");
                }
            }
            string newMaPms = "NV" + newNumber.ToString("000").TrimStart();
            return newMaPms;

        }
        //Thêm 
        [HttpGet]
        public ActionResult Create()
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            var count = databases.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && s.MaChucNang == "CN04");
            if (count == 0)
            {
                TempData["Message"] = "Ban khong co quyen truy cap vao chuc nang nay !!!";
                return RedirectToAction("Index", "TrangChu");

            }
            else
            {
                ViewBag.newkey = CapNhatKey();
                return View();

            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(NHANVIEN nhanvien)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    nhanvien.MaNV = CapNhatKey();
                    databases.NHANVIENs.Add(nhanvien);
                    databases.SaveChanges();
                    TempData["Message"] = "Them thanh cong !!!";
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View(nhanvien);
        }

        // Xem chi tiết
        [HttpGet]
        public ActionResult Details(string id)
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            var count = databases.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && s.MaChucNang == "CN04");
            if (count == 0)
            {
                TempData["Message"] = "Ban khong co quyen truy cap vao chuc nang nay !!!";
                return RedirectToAction("Index", "TrangChu");

            }
            else
            {
                var objProduct = databases.NHANVIENs.Where(n => n.MaNV == id).FirstOrDefault();
                return View(objProduct);
            }

        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            var count = databases.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && s.MaChucNang == "CN04");
            if (count == 0)
            {
                TempData["Message"] = "Ban khong co quyen truy cap vao chuc nang nay !!!";
                return RedirectToAction("Index", "TrangChu");

            }
            else
            {
                NHANVIEN item = databases.NHANVIENs.Find(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                return View(item);
            }

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NHANVIEN item = databases.NHANVIENs.Find(id);
            databases.NHANVIENs.Remove(item);
            databases.SaveChanges();
            TempData["Message"] = "Xoa thanh cong !!!";
            return RedirectToAction("Index");
        }


        //Chỉnh sửa nhân viên
        [HttpGet]
        public ActionResult Edit(string id)
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            var count = databases.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && s.MaChucNang == "CN04");
            if (count == 0)
            {
                TempData["Message"] = "Ban khong co quyen truy cap vao chuc nang nay !!!";
                return RedirectToAction("Index", "TrangChu");

            }
            else
            {
                var objProduct = databases.NHANVIENs.Where(n => n.MaNV == id).FirstOrDefault();
                return View(objProduct);
            }

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(NHANVIEN objProduct)
        {
            databases.Entry(objProduct).State = EntityState.Modified;
            databases.SaveChanges();
            TempData["Message"] = "Chinh sua thanh cong !!!";
            return RedirectToAction("Index");
        }
    }
}