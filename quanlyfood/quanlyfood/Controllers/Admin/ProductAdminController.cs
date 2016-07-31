using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quanlyfood.Repository;
using quanlyfood.Models;
using PagedList;
using PagedList.Mvc;

namespace quanlyfood.Controllers.Admin
{
    [RoutePrefix("admin")]
    public class ProductAdminController : Controller
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

        // GET: BanhAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BanhAdmin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
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
