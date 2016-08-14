using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quanlyfood.Repository;
using quanlyfood.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;


namespace quanlyfood.Controllers.Admin
{
    [RoutePrefix("admin")]
    public class ProductAdminController : BaseAdminController
    {
        BanhRepository product_repository = new BanhRepository();

        [Route("product/list")]
        // GET: BanhAdmin
        public ActionResult Index(int? page)
        {
            int page_number = (page ?? 1);
            int page_size = 10;

            List<BanhModel> list_products = product_repository.getListProduct("all");
            ViewBag.list_products = list_products.ToPagedList(page_number, 20);
            return View();
        }

        // GET: BanhAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Route("product/add")]
        // GET: BanhAdmin/Create
        public ActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(data.LOAIs.ToList(), "MaLoai", "TenLoai");
            return View();
        }

        [Route("product/add")]
        // POST: BanhAdmin/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(BANH product, FormCollection collection, HttpPostedFileBase anhbia)
        {
            var anh_bia = Path.GetFileName(anhbia.FileName);
            var path = Path.Combine(Server.MapPath("~/uploads"), anh_bia);
            ViewBag.MaLoai = new SelectList(data.LOAIs.ToList(), "MaLoai", "TenLoai");
            if(anhbia == null)
            {
                ViewBag.thong_bao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.thong_bao = "Hình ảnh đã tồn tại";
                        return View();
                    }
                    else
                    {
                        anhbia.SaveAs(path);
                    }
                    
                }
                
            }

            try
            {
                product.AnhBia = "/uploads/"+anh_bia;
                data.BANHs.InsertOnSubmit(product);
                data.SubmitChanges();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        [Route("product/edit/{id:int}")]
        // GET: BanhAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            BANH product = data.BANHs.SingleOrDefault(n => n.MaMon == id);
            ViewBag.MaLoai = new SelectList(data.LOAIs.ToList(), "MaLoai", "TenLoai", product.MaLoai);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [Route("product/edit/{id:int}")]
        // POST: BanhAdmin/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection collection, HttpPostedFileBase anhbia)
        {
            
            var product = data.BANHs.SingleOrDefault(n => n.MaMon == id);
            ViewBag.MaLoai = new SelectList(data.LOAIs.ToList(), "MaLoai", "TenLoai", product.MaLoai);
            
                if(anhbia != null)
                {
                    var anh_bia = Path.GetFileName(anhbia.FileName);
                    var path = Path.Combine(Server.MapPath("~/uploads"), anh_bia);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.thong_bao = "Hình ảnh đã tồn tại";
                        return View(product);
                    } else{
                        anhbia.SaveAs(path);
                        product.AnhBia = "/uploads/" + anh_bia;
                    }


                }

                product.TenMon = collection["TenMon"];
                product.GiaBan = decimal.Parse(collection["GiaBan"].ToString());
                product.MoTaNgan = collection["MoTaNgan"];
                product.MoTa = collection["MoTa"];
                product.MaLoai = int.Parse(collection["MaLoai"]);
                product.TrangThai = byte.Parse(collection["TrangThai"].ToString());
                data.SubmitChanges();
                return RedirectToAction("Index");
            
        }

        [Route("product/delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            var product = data.BANHs.SingleOrDefault(n => n.MaMon == id);
            try
            {
                product.TrangThai = 0;
                data.SubmitChanges();
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
