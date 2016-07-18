using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quanlyfood.Repository;
using quanlyfood.Models;

namespace quanlyfood.Controllers
{
    public abstract class BaseController : Controller
    {
        MenuRepository menu_repository = new MenuRepository();
        public BaseController()
        {
            List<MenuModel> list_menu = menu_repository.getListMenu();
            ViewBag.menus = list_menu;
        }
    }
}