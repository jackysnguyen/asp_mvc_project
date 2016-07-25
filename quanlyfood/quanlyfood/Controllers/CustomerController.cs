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
    public class CustomerController : BaseController
    {
        KhachHangRepository customer_repository = new KhachHangRepository();
        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }
        
        [HttpPost]
        public ActionResult Register(FormCollection form, KHACHHANG kh)
        {
            var name = form["name"];
            var username = form["username"];
            var password = form["password"];
            var repassword = form["repassword"];
            var phone = form["phone"];
            var email = form["email"];
            
            if (String.IsNullOrEmpty(name))
            {
                ViewData["loi_name"] = "Họ và tên không được trống";
                return this.Register();
            }
            else if (String.IsNullOrEmpty(username))
            {
                ViewData["loi_username"] = "Username không được trống";
                return this.Register();
            }
            else if (String.IsNullOrEmpty(password))
            {
                ViewData["loi_password"] = "Mật khẩu không được trống";
                return this.Register();
            }
            else if (String.IsNullOrEmpty(repassword))
            {
                ViewData["loi_repassword"] = "Xác nhận mật khẩu không được trống";
                return this.Register();
            }

            if (String.IsNullOrEmpty(email))
            {
                ViewData["loi_email"] = "Email không được trống";
                return this.Register();
            }
            if (String.IsNullOrEmpty(phone))
            {
                ViewData["loi_phone"] = "Số điện thoại không được trống";
                return this.Register();
            }
            if (!password.Equals(repassword))
            {
                return this.Register();
            }
            else
            {
                
                kh.HoTen = name;
                kh.Matkhau = password;
                kh.Taikhoan = username;
                kh.Email = email;
                kh.DienthoaiKH = phone;
                if (form["dateofbirh"].ToString().Equals(""))
                {
                    kh.Ngaysinh = null;
                }else
                {
                    var dateofbirth = String.Format("{0:MM/dd/yyyy}", form["dateofbirh"]);
                    kh.Ngaysinh = DateTime.Parse(dateofbirth);
                }
                
                var is_success = customer_repository.addCustomer(kh);
                if (is_success)
                {
                    return RedirectToAction("login");
                }
            }

            return this.Register();


        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }




    }
}