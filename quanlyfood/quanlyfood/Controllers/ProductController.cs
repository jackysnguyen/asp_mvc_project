using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quanlyfood.Repository;
using PagedList;
using quanlyfood.Models;
using PagedList;
using PagedList.Mvc;


namespace quanlyfood.Controllers
{ 
    public class ProductController : BaseController
    {
        BanhRepository product = new BanhRepository();
        // GET: Index
        public ActionResult List(int ?page, string id = "all")
        {
            int page_number = (page ?? 1);
            int page_size = 7;

            var page_info = new Dictionary<string, int>();
            

            page_info["page_number"] = page_number;
            page_info["page_size"] = page_size; 
            
            
            List<BanhModel> list_products = product.getListProduct(id);
            List<LoaiModel> list_product_category = product.getListProductCategory();
            ViewBag.list_product = list_products.ToPagedList(page_number, 7);
            ViewBag.list_categories = list_product_category;
            ViewBag.category_id = id;
            return View();
        }

        public ActionResult Detail(int id)
        {
            BanhModel product_detail = product.getBanhDetail(id);
            List<LoaiModel> list_product_category = product.getListProductCategory();
            if (product_detail == null)
            {

            }
            else
            {
                ViewBag.list_categories = list_product_category;
                ViewBag.product_detail = product_detail;
            }

            return View();
        }


    }
}