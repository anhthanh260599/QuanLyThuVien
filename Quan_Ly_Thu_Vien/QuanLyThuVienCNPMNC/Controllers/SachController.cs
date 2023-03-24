using PagedList;
using QuanLyThuVienCNPMNC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using static QuanLyThuVienCNPMNC.Common;

namespace QuanLyThuVienCNPMNC.Controllers
{
    public class SachController : Controller
    {
        public object ListtoDataConverter { get; private set; }
        Quan_Ly_Thu_VienEntities databases = new Quan_Ly_Thu_VienEntities();
        // GET: Sach
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstProduct = new List<SACH>();
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
                lstProduct = databases.SACHes.Where(n => n.MaDS.Contains(SearchString)).ToList();
            }
            else
            {
                // lấy tất cả sản phẩm trong bảng Product
                lstProduct = databases.SACHes.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            // Số lượng item của 1 trang = 4
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            // sắp xếp theo id sản phẩm, sản phẩm mới lên đầu tiên
            lstProduct = lstProduct.OrderByDescending(n => n.MaDS).ToList();

            return View(lstProduct.ToPagedList(pageNumber, pageSize));
        }

        void LoadData()
        {

            Common objCommon = new Common();
            // Lấy dữ liệu danh mục dưới DB, Parse (từ kiểu int sang kiểu chuỗi) (xem class Common)
            var lstMaDauSach = databases.DAUSACHes.ToList();
            // Convert sang select list dạng value, text
            ListtoDataTableConverter converter = new ListtoDataTableConverter();

            DataTable dtMaDauSach = converter.ToDataTable(lstMaDauSach);
            ViewBag.ListMaDauSach = objCommon.ToSelectList(dtMaDauSach, "MaDS", "TenSach");


            //Loại sản phẩm (code cứng)
            List<TinhTrang> lstProductType = new List<TinhTrang>();

            TinhTrang objProductType = new TinhTrang();
            objProductType.Id = 1;
            objProductType.Name = "Mới";
            lstProductType.Add(objProductType);

            objProductType = new TinhTrang();
            objProductType.Id = 2;
            objProductType.Name = "Đang sử dụng";
            lstProductType.Add(objProductType);

            objProductType = new TinhTrang();
            objProductType.Id = 3;
            objProductType.Name = "Đang mượn";
            lstProductType.Add(objProductType);

            objProductType = new TinhTrang();
            objProductType.Id = 4;
            objProductType.Name = "Quá hạn";
            lstProductType.Add(objProductType);

            objProductType = new TinhTrang();
            objProductType.Id = 5;
            objProductType.Name = "Hư hỏng";
            lstProductType.Add(objProductType);

            objProductType = new TinhTrang();
            objProductType.Id = 6;
            objProductType.Name = "Cũ";
            lstProductType.Add(objProductType);

            objProductType = new TinhTrang();
            objProductType.Id = 7;
            objProductType.Name = "Thanh lý";
            lstProductType.Add(objProductType);



            DataTable dtProductType = converter.ToDataTable(lstProductType);
            ViewBag.TinhTrang = objCommon.ToSelectList(dtProductType, "Id", "Name");
        }

        //            < script type = "text/javascript" >
        //    $(function() {
        //        $('.list-searchable').chosen();
        //            })
        //</ script >
        //@Html.DropDownListFor(model => model.TinhTrang, ViewBag.TinhTrang as SelectList, new { @class = "form-control list-searchable" })


        //Thêm 
        [HttpGet]
        public ActionResult Create()
        {
            this.LoadData();
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(SACH sach)
        {
            this.LoadData();
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

        // Xem chi tiết
        [HttpGet]
        public ActionResult Details(string id)
        {
            var objProduct = databases.SACHes.Where(n => n.MaSach == id).FirstOrDefault();
            return View(objProduct);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            SACH item = databases.SACHes.Find(id);
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
            SACH item = databases.SACHes.Find(id);
            databases.SACHes.Remove(item);
            databases.SaveChanges();
            return RedirectToAction("Index");
        }

        //Chỉnh sửa sản phẩm
        [HttpGet]
        public ActionResult Edit(string id)
        {
            this.LoadData();
            var objProduct = databases.SACHes.Where(n => n.MaSach == id).FirstOrDefault();
            return View(objProduct);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(SACH objProduct)
        {
            databases.Entry(objProduct).State = EntityState.Modified;
            databases.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}