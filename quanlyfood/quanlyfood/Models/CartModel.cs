using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace quanlyfood.Models
{
    public class CartModel
    {
        dbFoodLinQDataContext data = new dbFoodLinQDataContext();
        public int MaBanh { get; set; }
        public string TenBanh { get; set; }
        public string AnhBia { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien
        {
            get {
                return SoLuong * DonGia;
            }

        }

        public CartModel(int ma_banh)
        {
            MaBanh = ma_banh;
            BANH banh = data.BANHs.Single(n => n.MaMon == MaBanh);
            TenBanh = banh.TenMon;
            AnhBia = banh.AnhBia;
            DonGia = double.Parse(banh.GiaBan.ToString());
            SoLuong = 1;
        }

    }
}