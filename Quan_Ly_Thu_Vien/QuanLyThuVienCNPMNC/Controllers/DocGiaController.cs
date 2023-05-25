using PagedList;
using QuanLyThuVienCNPMNC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static QuanLyThuVienCNPMNC.Common;

namespace QuanLyThuVienCNPMNC.Controllers
{
    public class DocGiaController : Controller
    {
        public object ListtoDataConverter { get; private set; }
        Quan_Ly_Thu_VienEntities databases = new Quan_Ly_Thu_VienEntities();
        // GET: DocGia
        public ActionResult Index()
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            var count = databases.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && (s.MaChucNang == "CN01" || s.MaChucNang == "CN02"));
            if (count == 0)
            {
                TempData["MessageErRole"] = "Ban khong co quyen truy cap vao chuc nang nay !!!";
                return RedirectToAction("Index", "DocGia");

            }
            else
            {
                return View(databases.HOIVIENs.ToList());
            }

        }

        void LoadData()
        {

            Common objCommon = new Common();
            // Lấy dữ liệu danh mục dưới DB, Parse (từ kiểu int sang kiểu chuỗi) (xem class Common)
            // Convert sang select list dạng value, text
            ListtoDataTableConverter converter = new ListtoDataTableConverter();

            //Loại sản phẩm (code cứng)
            List<TinhTrang> lstProductType = new List<TinhTrang>();

            TinhTrang objProductType = new TinhTrang();
            objProductType.Id = 1;
            objProductType.Name = "Khóa";
            lstProductType.Add(objProductType);

            objProductType = new TinhTrang();
            objProductType.Id = 2;
            objProductType.Name = "Bình thường";
            lstProductType.Add(objProductType);

            DataTable dtProductType = converter.ToDataTable(lstProductType);
            ViewBag.TrangThai = objCommon.ToSelectList(dtProductType, "Id", "Name");
        }

        //Tu tao key
        public string CapNhatKey()
        {

            int newNumber = 1;
            var list = databases.HOIVIENs.OrderByDescending(s => s.MaHV);
            if (list == null)
            {
                newNumber = 1;
            }
            else
            {
                string convertNewNumber = "HVS" + newNumber.ToString("00");
                while (databases.HOIVIENs.Any(p => p.MaHV == convertNewNumber))
                {
                    newNumber++;
                    convertNewNumber = "HVS" + newNumber.ToString("00");
                }
            }
            string newMaPms = "HVS" + newNumber.ToString("00");
            return newMaPms;

        }
        //Thêm 
        [HttpGet]
        public ActionResult Create()
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            var count = databases.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && s.MaChucNang == "CN02");
            if (count == 0)
            {
                TempData["MessageErRole"] = "Ban khong co quyen truy cap vao chuc nang nay !!!";
                return RedirectToAction("Index", "DocGia");
            }
            else
            {
                ViewBag.newkey = CapNhatKey();
                return View();

            }
        }

        [HttpPost]
        public ActionResult Create(HOIVIEN hoivien)
        {

            try
            {
                hoivien.MaHV = CapNhatKey();
                hoivien.DangMuon = 0;
                hoivien.NgayHetHan = hoivien.NgayLapThe.AddYears(4);
                hoivien.SDT.Trim();
                databases.HOIVIENs.Add(hoivien);
                databases.SaveChanges();

                using (var context1 = new Quan_Ly_Thu_VienEntities())
                {
                    context1.sp_CapNhatTinhTrangTheHoiVien(hoivien.MaHV);
                }

                TempData["MessageAdd"] = "Them thanh cong !!!";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // Xem chi tiết
        [HttpGet]
        public ActionResult Details(string id)
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            var count = databases.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && (s.MaChucNang == "CN01" || s.MaChucNang == "CN02"));
            if (count == 0)
            {
                TempData["MessageErRole"] = "Ban khong co quyen truy cap vao chuc nang nay !!!";
                return RedirectToAction("Index", "DocGia");

            }
            else
            {
                var objProduct = databases.HOIVIENs.Where(n => n.MaHV == id).FirstOrDefault();
                return View(objProduct);
            }

        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            var count = databases.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && s.MaChucNang == "CN02");
            if (count == 0)
            {
                TempData["MessageErRole"] = "Ban khong co quyen truy cap vao chuc nang nay !!!";
                return RedirectToAction("Index", "DocGia");

            }
            else
            {
                HOIVIEN item = databases.HOIVIENs.Find(id);
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
            try
            {
                HOIVIEN item = databases.HOIVIENs.Where(s => s.MaHV == id).FirstOrDefault();
                databases.HOIVIENs.Remove(item);
                databases.SaveChanges();
                using (var context1 = new Quan_Ly_Thu_VienEntities())
                {
                    context1.sp_CapNhatSoLuongSachHoiVienMuon(id);
                }

                TempData["MessageDelete"] = "Xoa thanh cong !!!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Error"] = string.Format("Xoa khong thanh cong, moi kiem tra lai !!!");
                return RedirectToAction("Index");
            }

        }

        //Chỉnh sửa sản phẩm
        [HttpGet]
        public ActionResult Edit(string id)
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            var count = databases.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && s.MaChucNang == "CN02");
            if (count == 0)
            {
                TempData["MessageErRole"] = "Ban khong co quyen truy cap vao chuc nang nay !!!";
                return RedirectToAction("Index", "DocGia");

            }
            else
            {
                this.LoadData();
                var objProduct = databases.HOIVIENs.Where(n => n.MaHV == id).FirstOrDefault();


                return View(objProduct);
            }

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(DateTime? ngayhethan, HOIVIEN hoivien)
        {

            databases.Entry(hoivien).State = EntityState.Modified;
            hoivien.NgayHetHan = hoivien.NgayLapThe.AddYears(4);

            databases.SaveChanges();
            using (var context1 = new Quan_Ly_Thu_VienEntities())
            {
                context1.sp_CapNhatTinhTrangTheHoiVien(hoivien.MaHV);
            }
            TempData["MessageEdit"] = "Chinh sua thanh cong !!!";
            return RedirectToAction("Index");
        }
    }
}