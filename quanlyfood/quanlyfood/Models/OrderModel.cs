using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace quanlyfood.Models
{
    public class OrderModel
    {
        dbFoodLinQDataContext data = new dbFoodLinQDataContext();
        public int MaDonHang { get; set; }
        public string DaThanhToan { get; set; }
        public bool TinhTrangGiaoHang { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime NgayGiao { get; set; }
        public int Soluong { get; set; }
        public decimal DonGia { get; set; }
        public int MaBanh { get; set; }
        public List<OrderDetailModel> orderDetail { get; set; }

        /*public CartModel(int ma_banh)
        {
            MaBanh = ma_banh;
            BANH banh = data.BANHs.Single(n => n.MaMon == MaBanh);
            TenBanh = banh.TenMon;
            AnhBia = banh.AnhBia;
            DonGia = double.Parse(banh.GiaBan.ToString());
            SoLuong = 1;
        }*/

    }
}