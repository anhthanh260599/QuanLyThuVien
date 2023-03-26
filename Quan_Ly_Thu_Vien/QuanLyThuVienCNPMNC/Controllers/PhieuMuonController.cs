using Microsoft.Ajax.Utilities;
using PagedList;
using QuanLyThuVienCNPMNC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace QuanLyThuVienCNPMNC.Controllers
{
    public class PhieuMuonController : Controller
    {
        // GET: PhieuMuon
        public object ListtoDataConverter { get; private set; }
        Quan_Ly_Thu_VienEntities databases = new Quan_Ly_Thu_VienEntities();




        // GET: DocGia
        public ActionResult Index(/*string currentFilter, string SearchString, int? page*/)
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            var count = databases.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && s.MaChucNang == "CN03");
            if (count == 0)
            {
                TempData["Message"] = "Ban khong co quyen truy cap vao chuc nang nay !!!";
                return RedirectToAction("Index", "TrangChu");

            }
            else
            {

                return View(databases.PHIEUMUONSACHes.ToList());
            }

        }

        //Hàm tự cập nhật mã 
        public string CapNhatKey()
        {

            int newNumber = 1;
            var list = databases.PHIEUMUONSACHes.OrderByDescending(s => s.MaPhieu);
            if (list == null)
            {
                newNumber = 1;
            }
            else
            {
                string convertNewNumber = "PM" + newNumber.ToString("000");
                while (databases.PHIEUMUONSACHes.Any(p => p.MaPhieu == convertNewNumber))
                {
                    newNumber++;
                    convertNewNumber = "PM" + newNumber.ToString("000");
                }
            }
            string newMaPms = "PM" + newNumber.ToString("000");
            return newMaPms;

        }

        //Thêm 
        [HttpGet]
        public ActionResult Create()
        {

            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            var count = databases.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && s.MaChucNang == "CN03");
            if (count == 0)
            {
                TempData["Message"] = "Ban khong co quyen truy cap vao chuc nang nay !!!";
                return RedirectToAction("Index", "TrangChu");

            }


            else
            {
                //ViewBag.sachdrop = databases.SACHes.Select(x => new SelectListItem { Text = x.DAUSACH.TenSach, Value = x.MaSach.ToString() }).ToList();
                
                // Nếu tình trạng = 1 (Còn) thì mới được cho phép mượn, còn lại thì không
                ViewBag.sachdrop = databases.SACHes.Where(s => s.TinhTrang == 1).Select(x => new SelectListItem { Text = x.DAUSACH.TenSach, Value = x.MaSach.ToString() }).ToList();
                ViewBag.mahoivien = databases.HOIVIENs.Where(s=>s.TinhTrang == "Sử dụng được").Select(x => new SelectListItem { Text = x.TenHV, Value = x.MaHV.ToString() }).ToList();
                ViewBag.newkey = CapNhatKey();
                return View();
            }

        }

        [HttpPost]
        public ActionResult Create(string[] masach, string mahoivien, DateTime ngaymuon, int soluong)
        {
            //fix loi null dropdown list
            ViewBag.mahoivien = databases.HOIVIENs.Where(s=> s.TinhTrang == "Sử dụng được").Select(x => new SelectListItem { Text = x.TenHV, Value = x.MaHV.ToString() }).ToList();
            //ViewBag.sachdrop = databases.SACHes.Select(x => new SelectListItem { Text = x.DAUSACH.TenSach, Value = x.MaSach.ToString() }).ToList();
            ViewBag.sachdrop = databases.SACHes.Where(s => (s.TinhTrang == 1) ).Select(x => new SelectListItem { Text = x.DAUSACH.TenSach, Value = x.MaSach.ToString() }).ToList();

            //Kiem tra trong phieu muon hien tai co muon sach nay chua
            /*            int demPMS = databases.PHIEUMUONSACHes.Count(s => s.MaPhieu.ToLower() == maphieumuon.ToLower());
             *            
            */            //kiem tra trung key trong ctpm -- HashSet khong chua gia tri trung nhau
            bool checkCTPMS = masach.Length != new HashSet<string>(masach).Count;
            if (checkCTPMS)
            {
                ViewBag.Message = string.Format("Ban da muon sach nay. Moi ban kiem tra lai !!!");
                return View();
            }
            else
            {
                PHIEUMUONSACH newPMS = new PHIEUMUONSACH
                {
                    MaPhieu = CapNhatKey(),
                    MaHV = mahoivien,
                    NgayMuon = ngaymuon,
                    NgayTra = null,
                    ThoiHan = ngaymuon.AddDays(14),
                    SoLuong = soluong
                };


                List<CHITIETPHIEUMUON> listCTPM = new List<CHITIETPHIEUMUON>(soluong);
                

                for (int i = 0; i < soluong; i++)
                {
                    CHITIETPHIEUMUON newCTPM = new CHITIETPHIEUMUON
                    {
                        MaPhieu = newPMS.MaPhieu,
                        MaSach = masach[i],
                        NgayLapPhieu = newPMS.NgayMuon
                    };
                    listCTPM.Add(newCTPM);
                }
                using (var context1 = new Quan_Ly_Thu_VienEntities())
                {

                    context1.PHIEUMUONSACHes.Add(newPMS);
                    for (int i = 0; i < soluong; i++)
                    {
                        context1.CHITIETPHIEUMUONs.Add(listCTPM[i]);
                    }
                    context1.SaveChanges();
                    //Gọi strore procedure
                    context1.sp_CapNhatSoLuongSachHoiVienMuon(mahoivien);
                    TempData["Message"] = "Them thanh cong !!!";
                    return RedirectToAction("Index");
                }
            }

        }




        public ActionResult Details(string maphieu)
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            var count = databases.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && s.MaChucNang == "CN03");
            if (count == 0)
            {
                TempData["Message"] = "Ban khong co quyen truy cap vao chuc nang nay !!!";
                return RedirectToAction("Index", "TrangChu");

            }
            else
            {
                ViewBag.danhsachSach = databases.CHITIETPHIEUMUONs.Where(s => s.MaPhieu == maphieu).Select(s => s.SACH.DAUSACH.TenSach).ToList();

                return View(databases.PHIEUMUONSACHes.Where(s => s.MaPhieu == maphieu).FirstOrDefault());
            }

        }

        public ActionResult Edit(string maphieu, string mahoivien)
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            var count = databases.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && s.MaChucNang == "CN03");
            if (count == 0)
            {
                TempData["Message"] = "Ban khong co quyen truy cap vao chuc nang nay !!!";
                return RedirectToAction("Index", "TrangChu");

            }
            return View(databases.PHIEUMUONSACHes.Where(s => s.MaPhieu == maphieu && s.MaHV == mahoivien).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(string maphieu, DateTime? ngaytra, PHIEUMUONSACH pms) //DateTime ? -> cho giá trị date == null
        {
            pms = databases.PHIEUMUONSACHes.Where(s => s.MaPhieu == maphieu).FirstOrDefault();
            pms.NgayTra = ngaytra;

            //Gọi strore procedure

            databases.Entry(pms).State = EntityState.Modified;


            databases.SaveChanges();
            using (var context1 = new Quan_Ly_Thu_VienEntities())
            {
                context1.sp_CapNhatSoLuongSachHoiVienMuon(pms.MaHV);
            }
            TempData["Message"] = "Chinh sua thanh cong !!!";
            return RedirectToAction("Index");

        }
        public ActionResult Delete(string maphieu, string mahoivien)
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            var count = databases.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && s.MaChucNang == "CN03");
            if (count == 0)
            {
                TempData["Message"] = "Ban khong co quyen truy cap vao chuc nang nay !!!";
                return RedirectToAction("Index", "TrangChu");

            }
            else
            {
                ViewBag.danhsachSach = databases.CHITIETPHIEUMUONs.Where(s => s.MaPhieu == maphieu).Select(s => s.SACH.DAUSACH.TenSach).ToList();
                return View(databases.PHIEUMUONSACHes.Where(s => s.MaPhieu == maphieu && s.MaHV == mahoivien).FirstOrDefault());
            }

        }
        [HttpPost]
        public ActionResult Delete(string maphieu, string mahoivien, PHIEUMUONSACH pms)
        {
            try
            {
                ViewBag.danhsachSach = databases.CHITIETPHIEUMUONs.Where(s => s.MaPhieu == maphieu).Select(s => s.SACH.DAUSACH.TenSach).ToList();

                pms = databases.PHIEUMUONSACHes.Where(s => s.MaPhieu == maphieu).FirstOrDefault();
                var listDelete = databases.CHITIETPHIEUMUONs.Where(s => s.MaPhieu == maphieu).ToList();
                foreach (var item in listDelete)
                {
                    databases.CHITIETPHIEUMUONs.Remove(item);
                }
                databases.PHIEUMUONSACHes.Remove(pms);

                databases.SaveChanges();
                using (var context1 = new Quan_Ly_Thu_VienEntities())
                {
                    context1.sp_CapNhatSoLuongSachHoiVienMuon(mahoivien);
                }
                TempData["Message"] = "Xoa thanh cong !!!";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = string.Format("Xoa khong thanh cong, moi kiem tra lai !!!");
                return View();
            }

        }
    }
}