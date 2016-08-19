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

        
        public List<OrderModel> getListOrder()
        {
            var order = from don_dat_hang in data.DONDATHANGs
                        select new OrderModel
                        {
                            MaDonHang = don_dat_hang.MaDonHang,
                            TinhTrangGiaoHang = don_dat_hang.TinhTrangGiaoHang.Value,
                            NgayDat = don_dat_hang.NgayDat.Value,
                            NgayGiao = don_dat_hang.NgayGiao.Value
                        };

            return order.ToList();
        }

        public OrderModel getOrderById(int id)
        {
            var order_detail = from chi_tiet_don_hang in data.CHITIETDONTHANGs
                               where chi_tiet_don_hang.MaDonHang == id
                               join product in data.BANHs on chi_tiet_don_hang.MaBanh equals product.MaMon
                               select new OrderDetailModel
                               {
                                   MaBanh = chi_tiet_don_hang.MaBanh,
                                   Soluong = chi_tiet_don_hang.Soluong.Value,
                                   DonGia = chi_tiet_don_hang.DonGia.Value,
                                   TenBanh = product.TenMon
                                  
                               };
            var order = from don_dat_hang in data.DONDATHANGs
                        where don_dat_hang.MaDonHang == id
                        select new OrderModel
                        {
                            MaDonHang = don_dat_hang.MaDonHang,
                            TinhTrangGiaoHang = don_dat_hang.TinhTrangGiaoHang.Value,
                            NgayDat = don_dat_hang.NgayDat.Value,
                            NgayGiao = don_dat_hang.NgayGiao.Value,
                            orderDetail = order_detail.ToList()
                        };


            return order.SingleOrDefault();

        }

    }
}