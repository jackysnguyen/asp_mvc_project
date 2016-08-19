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
    public class OrderAdminController : BaseAdminController
    {
        CartRepository order_repository = new CartRepository();
            
        [Route("order/list")]
        // GET: OrderAdmin
        public ActionResult Index(int? page)
        {
            int page_number = (page ?? 1);
            int page_size = 10;

            List<OrderModel> list_orders = order_repository.getListOrder();
            ViewBag.list_orders = list_orders.ToPagedList(page_number, 20);
            return View();
        }

        // GET: BanhAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Route("order/edit/{id:int}")]
        // GET: OrderAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            OrderModel order = order_repository.getOrderById(id);
            
            if (order == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.order = order;
            return View(order);
        }

        
    }
}
