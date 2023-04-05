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
        public ActionResult Index()
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            var count = databases.PhanQuyens.Count(s => s.MaNhanVien == nvSession.MaNV && s.MaChucNang == "CN01");
            if (count == 1)
            {
                return View(databases.BAOCAOs.ToList());

            }
            else
            {
                return View(databases.BAOCAOs.Where(s => s.MaNhanVien == nvSession.MaNV).ToList());
            }

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
            NHANVIEN nvSession = (NHANVIEN)Session["user"];

            baocao.MaNhanVien = nvSession.MaNV;
            if (ModelState.IsValid)
            {
                try
                {
                    databases.BAOCAOs.Add(baocao);
                    databases.SaveChanges();
                    TempData["Message"] = "Them thanh cong !!!";
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
            TempData["Message"] = "Xoa thanh cong !!!";
            return RedirectToAction("Index");
        }

        //Chỉnh sửa sản phẩm
        [HttpGet]
        public ActionResult Edit(int id)
        {
            NHANVIEN nvSession = (NHANVIEN)Session["user"];
            BAOCAO bc = databases.BAOCAOs.Where(n => n.Id == id).FirstOrDefault();
            if (bc.MaNhanVien == nvSession.MaNV)
            {
                return View(bc);
            }
            else
            {
                TempData["Permission"] = "Ban chua co quyen de chinh sua bao cao cua nguoi khac !!!";
                return RedirectToAction("Index", "BaoCao");
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, BAOCAO bc)
        {
            try
            {
                NHANVIEN nvSession = (NHANVIEN)Session["user"];
                bc.NgayLapBaoCao = DateTime.Now;
                bc.MaNhanVien = nvSession.MaNV;

                databases.Entry(bc).State = EntityState.Modified;
                databases.SaveChanges();
                TempData["Message"] = "Chinh sua thanh cong !!!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Error"] = "Error !!!";
                return RedirectToAction("Index");
            }
            
        }
    }
}