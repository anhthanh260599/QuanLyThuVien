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
    
    public partial class PHIEUMUONSACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUMUONSACH()
        {
            this.CHITIETPHIEUMUONs = new HashSet<CHITIETPHIEUMUON>();
        }
    
        public string MaPhieu { get; set; }
        public string MaHV { get; set; }
        public System.DateTime NgayMuon { get; set; }
        public Nullable<System.DateTime> NgayTra { get; set; }
        public System.DateTime ThoiHan { get; set; }
        public int SoLuong { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUMUON> CHITIETPHIEUMUONs { get; set; }
        public virtual HOIVIEN HOIVIEN { get; set; }
    }
}
