using PagedList;
using QuanLyThuVienCNPMNC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using static QuanLyThuVienCNPMNC.Common;

namespace QuanLyThuVienCNPMNC.Controllers
{
    public class DauSachController : Controller
    {
        public object ListtoDataConverter { get; private set; }
        Quan_Ly_Thu_VienEntities databases = new Quan_Ly_Thu_VienEntities();
        // GET: DauSach
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstProduct = new List<DAUSACH>();
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
                lstProduct = databases.DAUSACHes.Where(n => n.TenSach.Contains(SearchString)).ToList();
            }
            else
            {
                // lấy tất cả sản phẩm trong bảng Product
                lstProduct = databases.DAUSACHes.ToList();
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
            var lstNXB = databases.NhaXuatBans.ToList();
            // Convert sang select list dạng value, text
            ListtoDataTableConverter converter = new ListtoDataTableConverter();

            DataTable dtNXB = converter.ToDataTable(lstNXB);
            ViewBag.ListNXB = objCommon.ToSelectList(dtNXB, "NXB", "TenNXB");
        }


        // Tạo sản phẩm
        [HttpGet]
        public ActionResult Create()
        {
            this.LoadData();
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(DAUSACH dausach)
        {
            //this.LoadData();
            //if (ModelState.IsValid) //Kiểm tra ràng buộc dữ liệu
            //{           
            //        return RedirectToAction("Index");
            //}
            //return View(dausach);
            this.LoadData();
            if (ModelState.IsValid)
            {
                try
                {
                    databases.DAUSACHes.Add(dausach);
                    databases.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View(dausach);
            //try
            //{
            //    databases.DAUSACHes.Add(dausach);
            //    databases.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return Content("Lỗi tạo mới đầu sách");
            //}
        }

        // Xem chi tiết đầu sách
        [HttpGet]
        public ActionResult Details(string id)
        {
            var objProduct = databases.DAUSACHes.Where(n => n.MaDS == id).FirstOrDefault();

            // Chuyển đổi giá trị kiểu DateTime thành chuỗi theo định dạng "dd/MM/yyyy"
            string ngayNhapString = objProduct.NgayXuatBan.ToString("dd/MM/yyyy");

            // Truyền giá trị chuỗi vào ViewBag để hiển thị trên view
            ViewBag.NgayXuatBan = ngayNhapString;


            return View(objProduct);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            DAUSACH item = databases.DAUSACHes.Find(id);
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
            DAUSACH item = databases.DAUSACHes.Find(id);
            databases.DAUSACHes.Remove(item);
            databases.SaveChanges();
            return RedirectToAction("Index");
        }

       

        //Chỉnh sửa sản phẩm
        [HttpGet]
        public ActionResult Edit(string id)
        {
            this.LoadData();
            var objProduct = databases.DAUSACHes.Where(n => n.MaDS == id).FirstOrDefault();
            return View(objProduct);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(DAUSACH objProduct)
        {
            databases.Entry(objProduct).State = EntityState.Modified;
            databases.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}