﻿using QuanLyThuVienCNPMNC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
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

        [HttpPost]
        public ActionResult Edit(NHANVIEN nv)
        {
            try
            {
                databases.Entry(nv).State = EntityState.Modified;
                databases.SaveChanges();
                TempData["Message"] = "Chinh sua thanh cong !!!";
                return RedirectToAction("Detail");
            }
            catch
            {
                TempData["Error"] = "Error... !!!";
                return RedirectToAction("Detail");
            }
        }

        [HttpGet]
        public ActionResult ChangePass()
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            return View(databases.NHANVIENs.Where(s => s.MaNV == nvSession.MaNV).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult ChangePass(string mkCu, string mkMoi, string checkMk, NHANVIEN nv)
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            nv = databases.NHANVIENs.Where(s => s.MaNV == nvSession.MaNV).FirstOrDefault();
                if (!mkCu.ToString().Equals(nv.MatKhau.Trim()))
                {
                    TempData["Error"] = "Ban da nhap sai mat khau cu !!";
                    return RedirectToAction("ChangePass");
                }
                if (mkCu.Equals(mkMoi))
                {
                    TempData["Error"] = "Mat khau moi khong duoc trung voi mat khau cu !!";
                    return RedirectToAction("ChangePass");
                }                  
            nv.MatKhau = mkMoi;
            databases.Entry(nv).State = EntityState.Modified;
            databases.SaveChanges();
            TempData["Message"] = "Doi mat khau thanh cong !!";
            return RedirectToAction("Detail");

        }

    }
}