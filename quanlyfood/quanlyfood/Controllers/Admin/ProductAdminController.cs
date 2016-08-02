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
            ViewBag.categories = new SelectList(data.LOAIs.ToList(), "MaLoai", "TenLoai");
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
            ViewBag.categories = new SelectList(data.LOAIs.ToList(), "MaLoai", "TenLoai");
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

        // GET: BanhAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BanhAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BanhAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BanhAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
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
