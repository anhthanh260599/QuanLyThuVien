using QuanLyThuVienCNPMNC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyThuVienCNPMNC.Context;
using System.Globalization;

namespace QuanLyThuVienCNPMNC.Controllers
{
    public class TrangChuController : Controller
    {
        Quan_Ly_Thu_VienEntities databases = new Quan_Ly_Thu_VienEntities();
        // GET: TrangChu

        public ActionResult Index()
        {
            // Đếm tổng số lượng sách trong database
            int totalBookCount = databases.DAUSACHes.Count();
            ViewBag.TotalBookCount = totalBookCount;

            // Đếm tổng số lượng độc giả trong database
            int totalMemberCount = databases.HOIVIENs.Count();
            ViewBag.TotalMemberCount = totalMemberCount;

            // Đếm tổng số phiếu mượn trong database
            int totalPhieuMuon = databases.PHIEUMUONSACHes.Count();
            ViewBag.TotalPhieuMuon = totalPhieuMuon;

            // Đếm tổng số báo cáo trong database
            int totalBaoCao = databases.BAOCAOs.Count();
            ViewBag.TotalBaoCao = totalBaoCao;

            //Goi session của nhân viên
            NHANVIEN nvSession = (NHANVIEN)Session["user"];

            if (totalBookCount != 0 || totalMemberCount != 0 || totalPhieuMuon != 0 || totalBaoCao != 0)
            {
                // Tính tỷ lệ phần trăm số lượng sách so với tổng số lượng
                ViewBag.TotalBookCountPercent = (totalBookCount * 100) / (totalBookCount + totalMemberCount + totalPhieuMuon + totalBaoCao);
                ViewBag.TotalMemberCountPercent = (totalMemberCount * 100) / (totalBookCount + totalMemberCount + totalPhieuMuon + totalBaoCao);
                ViewBag.TotalPhieuMuonPercent = (totalPhieuMuon * 100) / (totalBookCount + totalMemberCount + totalPhieuMuon + totalBaoCao);
                ViewBag.TotalBaoCaoPercent = (totalBaoCao * 100) / (totalBookCount + totalMemberCount + totalPhieuMuon + totalBaoCao);

                // Trả về MyTodo_List của nhân viên theo từng nhân viên
                return View(databases.MyTodo_List.Where(s => s.MaNV == nvSession.MaNV).ToList());

            }
            else return View(databases.MyTodo_List.Where(s => s.MaNV == nvSession.MaNV).ToList());
        }

        [HttpPost]
        public ActionResult CreateTodo(MyTodo_List todo_List, string mota)
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            todo_List.NgayTao = DateTime.Now;
            todo_List.MaNV = nvSession.MaNV;
            todo_List.MoTa = mota;

            try
            {
                databases.MyTodo_List.Add(todo_List);
                databases.SaveChanges();
                TempData["MessageAdd"] = "Them thanh cong !!!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Error"] = "Them khong thanh cong !!!";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult DeleteTodo(string ngaytao, string manv)
        {
            try
            {
                TimeSpan targetTime = TimeSpan.ParseExact(ngaytao, "hh\\:mm\\:ss", CultureInfo.InvariantCulture);

                MyTodo_List item = databases.MyTodo_List.FirstOrDefault(s =>
                    s.NgayTao.Hour == targetTime.Hours &&
                    s.NgayTao.Minute == targetTime.Minutes &&
                    s.NgayTao.Second == targetTime.Seconds &&
                    s.MaNV == manv);

                databases.MyTodo_List.Remove(item);
                databases.SaveChanges();
                TempData["MessageDelete"] = "Xoa thanh cong !!!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Error"] = "Khong the xoa, do da ton tai sach thuoc dau sach nay";
                return RedirectToAction("Index");
            }
        }

    }
}