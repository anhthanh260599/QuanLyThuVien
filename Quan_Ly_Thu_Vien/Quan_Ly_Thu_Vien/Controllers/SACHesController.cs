using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Quan_Ly_Thu_Vien.Models;

namespace Quan_Ly_Thu_Vien.Controllers
{
    public class SACHesController : Controller
    {
        private Quan_Ly_Thu_VienEntities1 db = new Quan_Ly_Thu_VienEntities1();
        private char strBulder;
        public object DropDownList1 { get; private set; }

        // GET: SACHes
        public ActionResult Index(List<DAUSACH> dropDownData)
        {
            
            var sACHes = db.SACHes.Include(s => s.DAUSACH);
            return View(sACHes.ToList());
        }
       
        //[HttpPost]
        //public ActionResult Index(string id)
        //{
        //    var sACHes = db.SACHes.Ma;
        //    return View(sACHes.ToList());
        //}

        // GET: SACHes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            return View(sACH);
        }

        // GET: SACHes/Create
        public ActionResult Create()
        {
            ViewBag.MaDS = new SelectList(db.DAUSACHes, "MaDS", "TenSach");
            return View();
        }

        // POST: SACHes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(SACH sACH)
        {

            SetAlert("Tạo mã sách thành công!", 1);
            if (sACH.TinhTrang != 1)
            {
                SetAlert("Tình trạng sách mới phải là 1", 3);
            }
            if (sACH.MaSach.Length != 5)
            {
                SetAlert("Mã sách phải có đúng 5 ký tự", 3);
            }
            if (sACH.MaSach == null)
            {
                SetAlert("Vui lòng nhập mã sách", 3);
            }
            

            try
            {
                // TODO: Add insert logic here
                db.SACHes.Add(sACH);
                db.SaveChanges();
                ViewBag.MaDS = new SelectList(db.DAUSACHes, "MaDS", "TenSach");
                return View();
            }
            catch
            {
                ViewBag.MaDS = new SelectList(db.DAUSACHes, "MaDS", "TenSach");
                return View();
            }
        }

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    var sACHes = db.SACHes.Include(s => s.DAUSACH);
        //    DropDownData.Add(new Data { Value = "emp1", Text = "Adams" });
        //    DropDownData.Add(new Data { Value = "emp2", Text = "James" });
        //    DropDownData.Add(new Data { Value = "emp3", Text = "Maria" });
        //    DropDownData.Add(new Data { Value = "emp4", Text = "Jessica" });
        //    DropDownData.Add(new Data { Value = "emp5", Text = "Jenneth" });
        //    DropDownList1.DataSource = DropDownData;

        //}
        public class Data
        {
            public string Value { get; set; }
            public string Text { get; set; }
        }

        protected void SetAlert(string message, int type)
        {
            TempData["AlertMessage"] = message;
            if (type == 1)
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == 2)
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == 3)
            {
                TempData["AlertType"] = "alert-danger";
            }
            else
            {
                TempData["AlertType"] = "alert-info";
            }
        }

        // GET: SACHes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDS = new SelectList(db.DAUSACHes, "MaDS", "TenSach", sACH.MaDS);
            return View(sACH);
        }

        // POST: SACHes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,TinhTrang,MaDS")] SACH sACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDS = new SelectList(db.DAUSACHes, "MaDS", "TenSach", sACH.MaDS);
            return View(sACH);
        }

        // GET: SACHes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            return View(sACH);
        }

        // POST: SACHes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SACH sACH = db.SACHes.Find(id);
            db.SACHes.Remove(sACH);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public void showMessage(string mess)
        {
            string strBuilder = "<script language='javascript'>alert('" + mess + "')</script>";
            Response.Write(strBulder);
        }
    }
}
