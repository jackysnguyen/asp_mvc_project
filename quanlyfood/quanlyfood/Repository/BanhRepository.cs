using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using quanlyfood.Models;


namespace quanlyfood.Repository
{
    public class BanhRepository
    {
        dbFoodLinQDataContext data = new dbFoodLinQDataContext();
        public List<BanhModel> getListProduct(string cat_id = "all")
        {
            int id;
            var banh_lists = from banhs in data.BANHs
                             join loai in data.LOAIs on banhs.MaLoai.Value equals loai.MaLoai
                             where banhs.TrangThai == 1
                             select new BanhModel()
                             {
                                 MaMon = banhs.MaMon,
                                 TenMon = banhs.TenMon,
                                 GiaBan = banhs.GiaBan,
                                 MoTaNgan = banhs.MoTaNgan,
                                 MoTa = banhs.MoTa,
                                 AnhBia = banhs.AnhBia,
                                 Ngaycapnhat = banhs.Ngaycapnhat,
                                 MaLoai = banhs.MaLoai,
                                 TrangThai = banhs.TrangThai
                             };
            ;

            if (int.TryParse(cat_id, out id))
            {
                
                banh_lists = from banhs in data.BANHs
                                 join loai in data.LOAIs on banhs.MaLoai.Value equals loai.MaLoai
                                 where banhs.MaLoai == id
                                 where banhs.TrangThai == 1
                                 select new BanhModel()
                                 {
                                     MaMon = banhs.MaMon,
                                     TenMon = banhs.TenMon,
                                     GiaBan = banhs.GiaBan,
                                     MoTaNgan = banhs.MoTaNgan,
                                     MoTa = banhs.MoTa,
                                     AnhBia = banhs.AnhBia,
                                     Ngaycapnhat = banhs.Ngaycapnhat,
                                     MaLoai = banhs.MaLoai,
                                     TrangThai = banhs.TrangThai
                                 };
                ;
            }




            return banh_lists.ToList();

        }

        public List<LoaiModel> getListProductCategory()
        {

            var loai_lists = from loais in data.LOAIs
                             select new LoaiModel()
                             {
                                 MaLoai = loais.MaLoai,
                                 TenLoai = loais.TenLoai
                             };
            ;

            return loai_lists.ToList();

        }

        public BanhModel getBanhDetail(int id)
        {
            var banh_detail = from banh in data.BANHs
                              where banh.MaMon == id
            select new BanhModel()
            {
                MaMon = banh.MaMon,
                TenMon = banh.TenMon,
                GiaBan = banh.GiaBan,
                MoTaNgan = banh.MoTaNgan,
                MoTa = banh.MoTa,
                AnhBia = banh.AnhBia,
                Ngaycapnhat = banh.Ngaycapnhat,
                MaLoai = banh.MaLoai,
                TrangThai = banh.TrangThai
            };

            return banh_detail.First();
        }

        public BanhModel addProduct(BANH product)
        {
            data.BANHs.InsertOnSubmit(product);
            data.SubmitChanges();
            BanhModel product_model = new BanhModel();
            product_model.MaMon = product.MaMon;
            product_model.TenMon = product.TenMon;
            return product_model;

        }


    }
}