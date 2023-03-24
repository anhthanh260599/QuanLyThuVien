using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyThuVienCNPMNC.Models;

namespace QuanLyThuVienCNPMNC.Context
{
    public class DauSachModel
    {
        public List<DAUSACH> ListDauSach { get; set; }
        public List<NhaXuatBan> ListNXB { get; set; }
    }
}