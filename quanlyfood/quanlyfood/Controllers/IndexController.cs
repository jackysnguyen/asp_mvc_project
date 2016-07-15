using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quanlyfood.Models;

namespace quanlyfood.Controllers
{
    public class IndexController : Controller
    {
        dbFoodLinQDataContext data = new dbFoodLinQDataContext();
        // GET: Index
        public ActionResult Index()
        {
            var all_user = from user in data.KHACHHANGs select user;
            ViewBag.users = all_user;
            return View(all_user);
        }
    }
}