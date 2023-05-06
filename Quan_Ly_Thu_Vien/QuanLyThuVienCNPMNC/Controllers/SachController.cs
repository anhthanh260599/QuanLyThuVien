using PagedList;
using QuanLyThuVienCNPMNC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using static QuanLyThuVienCNPMNC.Common;

namespace QuanLyThuVienCNPMNC.Controllers
{
    public class SachController : Controller
    {
        public object ListtoDataConverter { get; private set; }
        Quan_Ly_Thu_VienEntities databases = new Quan_Ly_Thu_VienEntities();
        // GET: Sach
        public ActionResult Index()
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            var count = databases.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && (s.MaChucNang == "CN01" || s.MaChucNang == "CN03"));
            if (count == 0)
            {
                TempData["Message"] = "Ban khong co quyen truy cap vao chuc nang nay !!!";
                return RedirectToAction("Index", "TrangChu");

            }
            else
            {
                return View(databases.SACHes.ToList());
            }

        }

        void LoadData()
        {

            Common objCommon = new Common();
            // Lấy dữ liệu danh mục dưới DB, Parse (từ kiểu int sang kiểu chuỗi) (xem class Common)
            var lstMaDauSach = databases.DAUSACHes.ToList();
            // Convert sang select list dạng value, text
            ListtoDataTableConverter converter = new ListtoDataTableConverter();

            DataTable dtMaDauSach = converter.ToDataTable(lstMaDauSach);
            ViewBag.ListMaDauSach = objCommon.ToSelectList(dtMaDauSach, "MaDS", "TenSach");


            //Loại sản phẩm (code cứng)
            List<TinhTrang> lstProductType = new List<TinhTrang>();

            TinhTrang objProductType = new TinhTrang();
            objProductType.Id = 1;
            objProductType.Name = "Còn";
            lstProductType.Add(objProductType);

            objProductType = new TinhTrang();
            objProductType.Id = 2;
            objProductType.Name = "Cho mượn";
            lstProductType.Add(objProductType);

            objProductType = new TinhTrang();
            objProductType.Id = 3;
            objProductType.Name = "Mất";
            lstProductType.Add(objProductType);

            objProductType = new TinhTrang();
            objProductType.Id = 4;
            objProductType.Name = "Hỏng";
            lstProductType.Add(objProductType);





            DataTable dtProductType = converter.ToDataTable(lstProductType);
            ViewBag.TinhTrang = objCommon.ToSelectList(dtProductType, "Id", "Name");
        }

        //            < script type = "text/javascript" >
        //    $(function() {
        //        $('.list-searchable').chosen();
        //            })
        //</ script >
        //@Html.DropDownListFor(model => model.TinhTrang, ViewBag.TinhTrang as SelectList, new { @class = "form-control list-searchable" })

        //Tu tao key
        /* public string CapNhatKey(soluongsach)
         {

             int newNumber = 1;
             var list = databases.SACHes.OrderByDescending(s => s.MaSach);
             if (list == null)
             {
                 newNumber = 1;
             }
             else
             {
                 string convertNewNumber = "SVH" + newNumber.ToString("00");
                 while (databases.SACHes.Any(p => p.MaSach == convertNewNumber))
                 {
                     newNumber++;
                     convertNewNumber = "SVH" + newNumber.ToString("00");
                 }
             }
             string newMaPms = "SVH" + newNumber.ToString("00");
             return newMaPms;

         }*/
        public List<string> CapNhatKey(int soluongsach)
        {
            List<string> newMaPmsList = new List<string>();
            int newNumber = 1;
            var list = databases.SACHes.OrderByDescending(s => s.MaSach);
            if (list == null)
            {
                newNumber = 1;
            }
            else
            {
                newNumber = int.Parse(list.First().MaSach.Substring(3)) + 1;
            }

            for (int i = 1; i <= soluongsach; i++)
            {
                string convertNewNumber = "SVH" + newNumber.ToString("00");
                while (databases.SACHes.Any(p => p.MaSach == convertNewNumber))
                {
                    newNumber++;
                    convertNewNumber = "SVH" + newNumber.ToString("00");
                }
                newMaPmsList.Add(convertNewNumber);
                newNumber++;
            }

            return newMaPmsList;
        }

        //Thêm 
        [HttpGet]
        public ActionResult Create()
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
                return View();
            }

        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(int soluongsach, SACH sach, DAUSACH ds)
        {
            this.LoadData();
            if (ModelState.IsValid)
            {
                try
                {
                    ds = databases.DAUSACHes.Where(s => s.MaDS == sach.MaDS).FirstOrDefault();
                    ds.SoLuong = soluongsach;
                    List<SACH> danhSachSach = new List<SACH>(soluongsach);
                    List<string> danhSachKey = new List<string>(soluongsach);
                    danhSachKey = CapNhatKey(soluongsach);

                    for (int i = 0; i < soluongsach; i++)
                    {
                        SACH sachMoi = new SACH();
                        sachMoi.MaSach = danhSachKey[i];
                        sachMoi.MaDS = sach.MaDS;
                        sachMoi.TinhTrang = sach.TinhTrang;
                        sachMoi.GhiChu = sach.GhiChu;

                        danhSachSach.Add(sachMoi);
                    }
                    /*foreach (string item in danhSachKey)
                    {


                        sach.MaSach = item;
                        danhSachSach.Add(sach);
                    }*/

                    foreach (var item in danhSachSach)
                    {
                        databases.SACHes.Add(item);
                    }
                    databases.SaveChanges();
                    TempData["Message"] = "Them thanh cong !!!";
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View(sach);
        }

        // Xem chi tiết
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
                var objProduct = databases.SACHes.Where(n => n.MaSach == id).FirstOrDefault();
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
                SACH item = databases.SACHes.Find(id);
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
                SACH item = databases.SACHes.Find(id);
                databases.SACHes.Remove(item);
                databases.SaveChanges();
                TempData["Message"] = "Xoa thanh cong !!!";
                return RedirectToAction("Index");

            }
            catch
            {
                TempData["Error"] = "Khong the xoa vi sach dang duoc muon !!!";
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
                var objProduct = databases.SACHes.Where(n => n.MaSach == id).FirstOrDefault();
                return View(objProduct);
            }

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(SACH objProduct)
        {
            try
            {
                databases.Entry(objProduct).State = EntityState.Modified;
                databases.SaveChanges();
                TempData["Message"] = "Chinh sua thanh cong !!!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Error"] = "Error ...";
                return RedirectToAction("Index");
            }

        }
    }
}