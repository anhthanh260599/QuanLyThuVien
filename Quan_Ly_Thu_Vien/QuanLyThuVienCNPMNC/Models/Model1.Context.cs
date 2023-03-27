﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyThuVienCNPMNC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Quan_Ly_Thu_VienEntities : DbContext
    {
        public Quan_Ly_Thu_VienEntities()
            : base("name=Quan_Ly_Thu_VienEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BAOCAO> BAOCAOs { get; set; }
        public virtual DbSet<BOITHUONG> BOITHUONGs { get; set; }
        public virtual DbSet<CHITIETPHIEUMUON> CHITIETPHIEUMUONs { get; set; }
        public virtual DbSet<ChucNang> ChucNangs { get; set; }
        public virtual DbSet<DAUSACH> DAUSACHes { get; set; }
        public virtual DbSet<HOIVIEN> HOIVIENs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<PHIEUMUONSACH> PHIEUMUONSACHes { get; set; }
        public virtual DbSet<SACH> SACHes { get; set; }
        public virtual DbSet<THAMSOQUYDINH> THAMSOQUYDINHs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    
        public virtual int sp_BaoCao(string mABC, string tENBC, Nullable<System.DateTime> ngay, string mANV)
        {
            var mABCParameter = mABC != null ?
                new ObjectParameter("MABC", mABC) :
                new ObjectParameter("MABC", typeof(string));
    
            var tENBCParameter = tENBC != null ?
                new ObjectParameter("TENBC", tENBC) :
                new ObjectParameter("TENBC", typeof(string));
    
            var ngayParameter = ngay.HasValue ?
                new ObjectParameter("Ngay", ngay) :
                new ObjectParameter("Ngay", typeof(System.DateTime));
    
            var mANVParameter = mANV != null ?
                new ObjectParameter("MANV", mANV) :
                new ObjectParameter("MANV", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_BaoCao", mABCParameter, tENBCParameter, ngayParameter, mANVParameter);
        }
    
        public virtual int sp_CapNhatSoLuongSachHoiVienMuon(string mahv)
        {
            var mahvParameter = mahv != null ?
                new ObjectParameter("mahv", mahv) :
                new ObjectParameter("mahv", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CapNhatSoLuongSachHoiVienMuon", mahvParameter);
        }
    
        public virtual int sp_CapNhatTinhTrangTheHoiVien(string mahoivien)
        {
            var mahoivienParameter = mahoivien != null ?
                new ObjectParameter("mahoivien", mahoivien) :
                new ObjectParameter("mahoivien", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CapNhatTinhTrangTheHoiVien", mahoivienParameter);
        }
    
        public virtual int sp_DoanhThu(Nullable<System.DateTime> ngay, string khoanTG, Nullable<int> tongTien)
        {
            var ngayParameter = ngay.HasValue ?
                new ObjectParameter("Ngay", ngay) :
                new ObjectParameter("Ngay", typeof(System.DateTime));
    
            var khoanTGParameter = khoanTG != null ?
                new ObjectParameter("KhoanTG", khoanTG) :
                new ObjectParameter("KhoanTG", typeof(string));
    
            var tongTienParameter = tongTien.HasValue ?
                new ObjectParameter("TongTien", tongTien) :
                new ObjectParameter("TongTien", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DoanhThu", ngayParameter, khoanTGParameter, tongTienParameter);
        }
    
        public virtual ObjectResult<sp_DSBaoCao_Result> sp_DSBaoCao()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_DSBaoCao_Result>("sp_DSBaoCao");
        }
    
        public virtual int sp_DSPhongHopTheoTinhTrang(Nullable<int> tinhTrang)
        {
            var tinhTrangParameter = tinhTrang.HasValue ?
                new ObjectParameter("TinhTrang", tinhTrang) :
                new ObjectParameter("TinhTrang", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DSPhongHopTheoTinhTrang", tinhTrangParameter);
        }
    
        public virtual int sp_GiaHan(string mAPHIEU, Nullable<int> soNgay, Nullable<System.DateTime> thoiHan)
        {
            var mAPHIEUParameter = mAPHIEU != null ?
                new ObjectParameter("MAPHIEU", mAPHIEU) :
                new ObjectParameter("MAPHIEU", typeof(string));
    
            var soNgayParameter = soNgay.HasValue ?
                new ObjectParameter("SoNgay", soNgay) :
                new ObjectParameter("SoNgay", typeof(int));
    
            var thoiHanParameter = thoiHan.HasValue ?
                new ObjectParameter("ThoiHan", thoiHan) :
                new ObjectParameter("ThoiHan", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_GiaHan", mAPHIEUParameter, soNgayParameter, thoiHanParameter);
        }
    
        public virtual ObjectResult<sp_LayThongTinNhanVien_Result> sp_LayThongTinNhanVien()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_LayThongTinNhanVien_Result>("sp_LayThongTinNhanVien");
        }
    
        public virtual int sp_ThemNhanVien(string mANV, string tenNV, string cHUCVU, string email, string matkhau)
        {
            var mANVParameter = mANV != null ?
                new ObjectParameter("MANV", mANV) :
                new ObjectParameter("MANV", typeof(string));
    
            var tenNVParameter = tenNV != null ?
                new ObjectParameter("TenNV", tenNV) :
                new ObjectParameter("TenNV", typeof(string));
    
            var cHUCVUParameter = cHUCVU != null ?
                new ObjectParameter("CHUCVU", cHUCVU) :
                new ObjectParameter("CHUCVU", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var matkhauParameter = matkhau != null ?
                new ObjectParameter("Matkhau", matkhau) :
                new ObjectParameter("Matkhau", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ThemNhanVien", mANVParameter, tenNVParameter, cHUCVUParameter, emailParameter, matkhauParameter);
        }
    
        public virtual int CapNhatTinhTrangSach(string maphieu, string masach)
        {
            var maphieuParameter = maphieu != null ?
                new ObjectParameter("maphieu", maphieu) :
                new ObjectParameter("maphieu", typeof(string));
    
            var masachParameter = masach != null ?
                new ObjectParameter("masach", masach) :
                new ObjectParameter("masach", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CapNhatTinhTrangSach", maphieuParameter, masachParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_CapNhatTinhTrangSach(string maphieu, string masach)
        {
            var maphieuParameter = maphieu != null ?
                new ObjectParameter("maphieu", maphieu) :
                new ObjectParameter("maphieu", typeof(string));
    
            var masachParameter = masach != null ?
                new ObjectParameter("masach", masach) :
                new ObjectParameter("masach", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CapNhatTinhTrangSach", maphieuParameter, masachParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}