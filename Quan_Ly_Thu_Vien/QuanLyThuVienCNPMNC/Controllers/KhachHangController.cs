using QuanLyThuVienCNPMNC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FuzzySharp;
using FuzzySharp.SimilarityRatio;
using Microsoft.Ajax.Utilities;

namespace QuanLyThuVienCNPMNC.Controllers
{
    public class KhachHangController : Controller
    {
        Quan_Ly_Thu_VienEntities databases = new Quan_Ly_Thu_VienEntities();

        // GET: KhachHang
        public ActionResult Index(string searchTerm)
        {
            if (searchTerm.IsNullOrWhiteSpace())
            {
                return View(databases.SACHes
                    .Where(s => s.TinhTrang == 1)
                    .DistinctBy(s => s.MaDS)
                    .ToList());

            }
            else
            {
                var searchResult = databases.SACHes.ToList()
                                    .Where(s => Fuzz.Ratio(s.DAUSACH.TenSach.ToLower(), searchTerm.ToLower()) >= 30
                                                           || s.DAUSACH.TenSach.ToLower().StartsWith(searchTerm.ToLower())
                                                || Fuzz.Ratio(s.DAUSACH.Theloai.ToLower(), searchTerm.ToLower()) >= 30
                                                           || s.DAUSACH.Theloai.ToLower().StartsWith(searchTerm.ToLower()))
                                    .DistinctBy(s => s.MaDS)
                                    .ToList();
                return View(searchResult);
            }
        }

        public ActionResult Details(string mads)
        {
            return View(databases.SACHes.Where(s => s.MaDS == mads && s.TinhTrang == 1).FirstOrDefault());
        }

    }
}