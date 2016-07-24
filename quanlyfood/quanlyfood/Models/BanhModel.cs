using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace quanlyfood.Models
{
    public class BanhModel
    {
        public int MaMon { get; set; }
        public string TenMon { get; set; }
        public decimal? GiaBan { get; set; }
        public string MoTaNgan { get; set; }
        public string MoTa { get; set; }
        public string AnhBia { get; set; }
        public DateTime? Ngaycapnhat { get; set; }
        public int? MaLoai { get; set; }
        public byte? TrangThai { get; set; }
        

    }
}