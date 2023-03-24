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
    public class BaoCaoController : Controller
    {
        // GET: BaoCao
        public object ListtoDataConverter { get; private set; }
        Quan_Ly_Thu_VienEntities databases = new Quan_Ly_Thu_VienEntities();
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstProduct = new List<BAOCAO>();

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
                lstProduct = databases.BAOCAOs.Where(n => n.Ten.Contains(SearchString)).ToList();
            }
            else
            {
                // lấy tất cả sản phẩm trong bảng Product
                lstProduct = databases.BAOCAOs.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            // Số lượng item của 1 trang = 4
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            // sắp xếp theo id sản phẩm, sản phẩm mới lên đầu tiên
            lstProduct = lstProduct.OrderByDescending(n => n.Id).ToList();

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
        public ActionResult Create(BAOCAO baocao)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    databases.BAOCAOs.Add(baocao);
                    databases.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View(baocao);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var objProduct = databases.BAOCAOs.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            BAOCAO item = databases.BAOCAOs.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BAOCAO item = databases.BAOCAOs.Find(id);
            databases.BAOCAOs.Remove(item);
            databases.SaveChanges();
            return RedirectToAction("Index");
        }

        //Chỉnh sửa sản phẩm
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var objProduct = databases.BAOCAOs.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(BAOCAO objProduct)
        {
            databases.Entry(objProduct).State = EntityState.Modified;
            databases.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}