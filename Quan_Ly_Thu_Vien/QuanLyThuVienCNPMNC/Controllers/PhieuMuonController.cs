using PagedList;
using QuanLyThuVienCNPMNC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstProduct = new List<PHIEUMUONSACH>();

            // Phân trang
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                // lấy ds sản phẩm theo từ khóa tìm kiếm
                lstProduct = databases.PHIEUMUONSACHes.Where(n => n.MaPhieu.Contains(SearchString)).ToList();
            }
            else
            {
                // lấy tất cả sản phẩm trong bảng Product
                lstProduct = databases.PHIEUMUONSACHes.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            // Số lượng item của 1 trang = 4
            int pageSize = 5;
            int pageNumber = (page ?? 1);



            // sắp xếp theo id sản phẩm, sản phẩm mới lên đầu tiên
            lstProduct = lstProduct.OrderByDescending(n => n.MaPhieu).ToList();

            return View(lstProduct.ToPagedList(pageNumber, pageSize));
        }

        //Thêm 
        [HttpGet]
        public ActionResult Create()
        {
            //this.LoadData();
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(SACH sach)
        {
            //this.LoadData();
            if (ModelState.IsValid)
            {
                try
                {
                    databases.SACHes.Add(sach);
                    databases.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View(sach);
        }
    }
}