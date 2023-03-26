using QuanLyThuVienCNPMNC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyThuVienCNPMNC.Context
{
    public class HomeModel
    {
        public List<DAUSACH> ListDauSach { get; set; }
        public List<BAOCAO> ListBaoCao { get; set; }
        public List<HOIVIEN> ListHoiVien { get; set; }
        public List<PHIEUMUONSACH> ListPhieuMuonSach { get; set; }
    }
}