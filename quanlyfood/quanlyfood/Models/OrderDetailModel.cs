using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace quanlyfood.Models
{
    public class OrderDetailModel
    {
        dbFoodLinQDataContext data = new dbFoodLinQDataContext();
        public int MaDonHang { get; set; }
        public int MaBanh { get; set; }
        public int Soluong { get; set; }
        public decimal DonGia { get; set; }
        public string TenBanh { get; set; }
    }
}