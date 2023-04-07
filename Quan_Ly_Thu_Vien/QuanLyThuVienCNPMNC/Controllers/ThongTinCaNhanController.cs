using QuanLyThuVienCNPMNC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyThuVienCNPMNC.Controllers
{
    public class ThongTinCaNhanController : Controller
    {
        Quan_Ly_Thu_VienEntities databases = new Quan_Ly_Thu_VienEntities();
        // GET: ThongTinCaNhan
        [HttpGet]
        public ActionResult Detail()
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];

            return View(databases.NHANVIENs.Where(s => s.MaNV == nvSession.MaNV).FirstOrDefault());
        }
        [HttpGet]
        public ActionResult Edit()
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            return View(databases.NHANVIENs.Where(s => s.MaNV == nvSession.MaNV).FirstOrDefault());
        }

    }
}