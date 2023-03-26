using QuanLyThuVienCNPMNC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyThuVienCNPMNC.Context;

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

            // Đếm tổng số lượng hội viên trong database
            int totalMemberCount = databases.HOIVIENs.Count();
            ViewBag.TotalMemberCount = totalMemberCount;

            // Đếm tổng số phiếu mượn trong database
            int totalPhieuMuon = databases.PHIEUMUONSACHes.Count();
            ViewBag.TotalPhieuMuon = totalPhieuMuon;

            // Đếm tổng số báo cáo trong database
            int totalBaoCao = databases.BAOCAOs.Count();
            ViewBag.TotalBaoCao = totalBaoCao;

            // Tính tỷ lệ phần trăm số lượng sách so với tổng số lượng
            ViewBag.TotalBookCountPercent = (totalBookCount * 100) / (totalBookCount + totalMemberCount + totalPhieuMuon + totalBaoCao);
            ViewBag.TotalMemberCountPercent = (totalMemberCount * 100) / (totalBookCount + totalMemberCount + totalPhieuMuon + totalBaoCao);
            ViewBag.TotalPhieuMuonPercent = (totalPhieuMuon * 100) / (totalBookCount + totalMemberCount + totalPhieuMuon + totalBaoCao);
            ViewBag.TotalBaoCaoPercent = (totalBaoCao * 100) / (totalBookCount + totalMemberCount + totalPhieuMuon + totalBaoCao);

            return View();
        }
    }
}