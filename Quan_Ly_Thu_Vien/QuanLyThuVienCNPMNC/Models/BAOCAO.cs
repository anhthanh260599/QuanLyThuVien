//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class BAOCAO
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string Description { get; set; }
        public string MaNhanVien { get; set; }
        public Nullable<System.DateTime> NgayLapBaoCao { get; set; }
    
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}