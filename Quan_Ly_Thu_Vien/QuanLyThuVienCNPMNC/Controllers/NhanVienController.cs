using PagedList;
using QuanLyThuVienCNPMNC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyThuVienCNPMNC.Controllers
{
    public class NhanVienController : Controller
    {
        public object ListtoDataConverter { get; private set; }
        Quan_Ly_Thu_VienEntities databases = new Quan_Ly_Thu_VienEntities();
        // GET: DocGia
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstProduct = new List<NHANVIEN>();

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
                lstProduct = databases.NHANVIENs.Where(n => n.TenNV.Contains(SearchString)).ToList();
            }
            else
            {
                // lấy tất cả sản phẩm trong bảng Product
                lstProduct = databases.NHANVIENs.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            // Số lượng item của 1 trang = 4
            int pageSize = 5;
            int pageNumber = (page ?? 1);



            // sắp xếp theo id sản phẩm, sản phẩm mới lên đầu tiên
            lstProduct = lstProduct.OrderByDescending(n => n.MaNV).ToList();

            return View(lstProduct.ToPagedList(pageNumber, pageSize));
        }

        //Thêm 
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(NHANVIEN nhanvien)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    databases.NHANVIENs.Add(nhanvien);
                    databases.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View(nhanvien);
        }

        // Xem chi tiết
        [HttpGet]
        public ActionResult Details(string id)
        {
            var objProduct = databases.NHANVIENs.Where(n => n.MaNV == id).FirstOrDefault();
            return View(objProduct);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            NHANVIEN item = databases.NHANVIENs.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NHANVIEN item = databases.NHANVIENs.Find(id);
            databases.NHANVIENs.Remove(item);
            databases.SaveChanges();
            return RedirectToAction("Index");
        }


        //Chỉnh sửa sản phẩm
        [HttpGet]
        public ActionResult Edit(string id)
        {

            var objProduct = databases.NHANVIENs.Where(n => n.MaNV == id).FirstOrDefault();
            return View(objProduct);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(NHANVIEN objProduct)
        {
            databases.Entry(objProduct).State = EntityState.Modified;
            databases.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}