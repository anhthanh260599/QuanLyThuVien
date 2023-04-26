using PagedList;
using QuanLyThuVienCNPMNC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

using static QuanLyThuVienCNPMNC.Common;

namespace QuanLyThuVienCNPMNC.Controllers
{

    public class DauSachController : Controller
    {
        public object ListtoDataConverter { get; private set; }
        Quan_Ly_Thu_VienEntities databases = new Quan_Ly_Thu_VienEntities();
        // GET: DauSach
        public ActionResult Index()
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            var count = databases.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && s.MaChucNang == "CN01");
            if (count == 0)
            {
                TempData["Message"] = "Ban khong co quyen truy cap vao chuc nang nay !!!";
                return RedirectToAction("Index", "TrangChu");

            }
            else
            {
               
                return View(databases.DAUSACHes.ToList());
            }
           
        }

        void LoadData()
        {
            Common objCommon = new Common();
            // Lấy dữ liệu danh mục dưới DB, Parse (từ kiểu int sang kiểu chuỗi) (xem class Common)
            var lstNXB = databases.NhaXuatBans.ToList();
            // Convert sang select list dạng value, text
            ListtoDataTableConverter converter = new ListtoDataTableConverter();

            DataTable dtNXB = converter.ToDataTable(lstNXB);
            ViewBag.ListNXB = objCommon.ToSelectList(dtNXB, "NXB", "TenNXB");
        }

        //Hàm tự cập nhật mã 
        public string CapNhatKey()
        {

            int newNumber = 1;
            var list = databases.DAUSACHes.OrderByDescending(s => s.MaDS);
            if (list == null)
            {
                newNumber = 1;
            }
            else
            {
                string convertNewNumber = "DSA" + newNumber.ToString("000");
                while (databases.DAUSACHes.Any(p => p.MaDS == convertNewNumber))
                {
                    newNumber++;
                    convertNewNumber = "DSA" + newNumber.ToString("000");
                }
            }
            string newMaPms = "DSA" + newNumber.ToString("000");
            return newMaPms;

        }
        // Tạo sản phẩm
        [HttpGet]
        public ActionResult Create()
        {   
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            var count = databases.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && s.MaChucNang == "CN01");
            if (count == 0)
            {
                TempData["Message"] = "Bạn không có quyền truy cập chức năng này";

                return RedirectToAction("Index", "TrangChu");

            }
            else
            {
                ViewBag.newkey = CapNhatKey();
                this.LoadData();

                return View();
            }
           
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(DAUSACH dausach)
        {
            //this.LoadData();
            //if (ModelState.IsValid) //Kiểm tra ràng buộc dữ liệu
            //{           
            //        return RedirectToAction("Index");
            //}
            //return View(dausach);
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            var count = databases.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && s.MaChucNang == "CN01");
            if (count == 0)
            {
                TempData["Message"] = "Ban khong co quyen truy cap vao chuc nang nay !!!";
                return RedirectToAction("LichSuNhapHang");

            }
            else
            {
                this.LoadData();
                if (ModelState.IsValid)
                {
                    try
                    {
                        dausach.MaDS = CapNhatKey();
                        databases.DAUSACHes.Add(dausach);
                        databases.SaveChanges();

                        TempData["Message"] = "Tao dau sach thanh cong";


                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        return View();
                    }
                }
                return View(dausach);
            }
           
            //try
            //{
            //    databases.DAUSACHes.Add(dausach);
            //    databases.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return Content("Lỗi tạo mới đầu sách");
            //}
        }



        // Xem chi tiết đầu sách
        [HttpGet]
        public ActionResult Details(string id)
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            var count = databases.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && s.MaChucNang == "CN01");
            if (count == 0)
            {
                TempData["Message"] = "Ban khong co quyen truy cap vao chuc nang nay !!!";
                return RedirectToAction("Index", "TrangChu");

            }
            else
            {
                var objProduct = databases.DAUSACHes.Where(n => n.MaDS == id).FirstOrDefault();

                // Chuyển đổi giá trị kiểu DateTime thành chuỗi theo định dạng "dd/MM/yyyy"
                string ngayNhapString = objProduct.NgayXuatBan.ToString("dd/MM/yyyy");

                // Truyền giá trị chuỗi vào ViewBag để hiển thị trên view
                ViewBag.NgayXuatBan = ngayNhapString;
                return View(objProduct);
            }
          
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            var count = databases.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && s.MaChucNang == "CN01");
            if (count == 0)
            {
                TempData["Message"] = "Ban khong co quyen truy cap vao chuc nang nay !!!";
                return RedirectToAction("Index", "TrangChu");

            }
            else
            {
                DAUSACH item = databases.DAUSACHes.Find(id);
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
                DAUSACH item = databases.DAUSACHes.Find(id);
                databases.DAUSACHes.Remove(item);
                databases.SaveChanges();
                TempData["Message"] = "Xoa thanh cong";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Error"] = "Khong the xoa, do da ton tai sach thuoc dau sach nay";
                return RedirectToAction("Index");
            }
        }

        //Chỉnh sửa sản phẩm
        [HttpGet]
        public ActionResult Edit(string id)
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            var count = databases.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && s.MaChucNang == "CN01");
            if (count == 0)
            {
                TempData["Message"] = "Ban khong co quyen truy cap vao chuc nang nay !!!";
                return RedirectToAction("Index", "TrangChu");

            }
            else
            {
                this.LoadData();
                var objProduct = databases.DAUSACHes.Where(n => n.MaDS == id).FirstOrDefault();
                return View(objProduct);
            }
         
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(DAUSACH objProduct)
        {
            databases.Entry(objProduct).State = EntityState.Modified;
            databases.SaveChanges();
            TempData["Message"] = "";
            return RedirectToAction("Index");
        }
    }
}