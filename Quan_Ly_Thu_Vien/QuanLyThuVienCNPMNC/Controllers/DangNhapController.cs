using QuanLyThuVienCNPMNC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QuanLyThuVienCNPMNC.Controllers
{
    public class DangNhapController : Controller
    {
        public Quan_Ly_Thu_VienEntities database = new Quan_Ly_Thu_VienEntities();
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(string userLogin, string passwordLogin)
        {
            var taikhoan = database.NHANVIENs.Where(s => s.Email == userLogin && s.MatKhau == passwordLogin).FirstOrDefault();

            if (taikhoan != null)
            {
                Session["user"] = taikhoan;
                NHANVIEN nvSession = (NHANVIEN)Session["user"];
                return RedirectToAction("Index", "TrangChu");
                /*var count1 = database.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && s.MaChucNang == "CN01");
                var count2 = database.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && s.MaChucNang == "CN02");
                var count3 = database.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && s.MaChucNang == "CN03");
                var count4 = database.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && s.MaChucNang == "CN04");
                if (count1 == 1)
                {
                    return RedirectToAction("Index", "Home");
                }*/
                /* else if (count2 == 1)
                 {
                     return RedirectToAction("TrangChuThuThu", "TrangChu");
                 }
                 else if (count3 == 1)
                 {
                     return RedirectToAction("TrangChuThuThu", "TrangChu");
                 }
                 else if (count4 == 1)
                 {
                    return RedirectToAction("TrangChuThuThu", "TrangChu");
                 }*//*

                else
                {
                    ViewBag.Message = string.Format("Tai khoan chua duoc cap quyen");
                    return View();
                }*/
            }
            else
            {
                ViewBag.Message = string.Format("Tai khoan hoac mat khau khong dung");
                return View();
            }
        }
        public ActionResult DangXuat()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("DangNhap", "DangNhap");
        }
    }
}




