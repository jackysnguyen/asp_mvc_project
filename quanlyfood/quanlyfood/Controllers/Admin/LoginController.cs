using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quanlyfood.Models;
using quanlyfood.Repository;

namespace quanlyfood.Controllers.Admin
{
    [RoutePrefix("admin")]
    public class LoginController : BaseAdminController
    {
        AdminRepository admin_repository = new AdminRepository();
        [Route("login")]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [Route("login")]
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            var username = form["username"];
            var password = form["password"];
            if (String.IsNullOrEmpty(username))
            {
                ViewData["loi_username"] = "Tên đăng nhập không được trống";
            }else if (String.IsNullOrEmpty(password))
            {
                ViewData["loi_password"] = "Mật khẩu không được trống";
            }
            else
            {
                ADMIN admin = new ADMIN();
                admin.username = username;
                admin.password = password;
                AdminModel admin_model = admin_repository.getAdminLogin(admin);
                if (admin_model != null)
                {
                    Session["admin"] = admin_model;
                    return RedirectToAction("index", "indexadmin");
                }
                else
                    ViewData["error_login"] = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();

        }
    }
}