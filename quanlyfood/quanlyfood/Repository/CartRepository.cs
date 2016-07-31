using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using quanlyfood.Models;

namespace quanlyfood.Repository
{
    public class CartRepository
    {
        dbFoodLinQDataContext data = new dbFoodLinQDataContext();
        public Boolean addCart(DONDATHANG ddh, List<CartModel> cart)
        {
            data.DONDATHANGs.InsertOnSubmit(ddh);
            data.SubmitChanges();
            foreach (var item in cart)
            {
                CHITIETDONTHANG chi_tiet = new CHITIETDONTHANG();
                chi_tiet.MaDonHang = ddh.MaDonHang;
                chi_tiet.MaBanh = item.MaBanh;
                chi_tiet.Soluong = item.SoLuong;
                chi_tiet.DonGia = (decimal)item.ThanhTien;
                data.CHITIETDONTHANGs.InsertOnSubmit(chi_tiet);
            }
            data.SubmitChanges();
            if(ddh.MaDonHang != null)
            {
                return true;

            }
            return false;
        }
        

    }
}