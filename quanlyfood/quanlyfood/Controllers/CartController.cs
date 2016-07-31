using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quanlyfood.Repository;
using quanlyfood.Models;

namespace quanlyfood.Controllers
{
     
    public class CartController : BaseController
    {
        CartRepository cart_repository = new CartRepository();
        public List<CartModel> getCart()
        {
            List<CartModel> cart = Session["cart"] as List<CartModel>;
            if(cart == null)
            {
                cart = new List<CartModel>();
                Session["cart"] = cart;
            }
            return cart;
        }

        public ActionResult addToCart(int ma_banh, string redirect_url)
        {
            List<CartModel> cart = getCart();
            CartModel cake = cart.Find(n => n.MaBanh == ma_banh);
            if(cake == null)
            {
                cake = new CartModel(ma_banh);
                cart.Add(cake);
                return Redirect(redirect_url);
            }else
            {
                cake.SoLuong++;
                return Redirect(redirect_url);
            }
        }

        private int totalNumber()
        {
            int total_number = 0;
            List<CartModel> cart = Session["cart"] as List<CartModel>;
            if(cart != null)
            {
                total_number = cart.Sum(n => n.SoLuong); 
            }

            return total_number;
        }

        private double totalPay()
        {
            double total_pay = 0;
            List<CartModel> cart = Session["cart"] as List<CartModel>;
            if (cart != null)
            {
                total_pay = cart.Sum(n => n.ThanhTien);
            }
            return total_pay;
        }

        public ActionResult Cart()
        {
            List<CartModel> cart = getCart();
            if(cart.Count() == 0)
            {
                return RedirectToAction("List", "Product");
            }

            ViewBag.total_number = totalNumber();
            ViewBag.total_pay = totalPay();
            return View(cart);
        }

        public ActionResult DeleteBanh(int id)
        {
            List<CartModel> cart = getCart();
            CartModel item = cart.SingleOrDefault(n => n.MaBanh == id);
            if (item != null)
            {
                cart.RemoveAll(n => n.MaBanh == id);
                return RedirectToAction("cart");
            }

            if (cart.Count == 0)
            {
                return RedirectToAction("list", "product");
            }

            return RedirectToAction("cart");
        }

        public ActionResult UpdateCart(int ma_banh, FormCollection form)
        {
            List<CartModel> cart = getCart();
            CartModel item = cart.SingleOrDefault(n => n.MaBanh == ma_banh);
            if(item != null)
            {
                item.SoLuong = int.Parse(form["number"].ToString());

            }
            return RedirectToAction("cart");
        }

       
        [HttpGet]
        public ActionResult Checkout()
        {
            if(Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("Login", "Customer");
            }
            if(Session["cart"] == null)
            {
                return RedirectToAction("Index", "Product");
            }

            List<CartModel> cart = getCart();
            ViewBag.total_number = totalNumber();
            ViewBag.total_pay = totalPay();
            return View(cart);
        }

        [HttpPost]
        public ActionResult Checkout(FormCollection form)
        {
            DONDATHANG ddh = new DONDATHANG();
            KhachHangModel kh = (KhachHangModel)Session["TaiKhoan"];
            List<CartModel> cart = getCart();
            ddh.MaKH = kh.MaKH;
            ddh.NgayDat = DateTime.Now;
            var ngay_giao = String.Format("{0:MM/dd/yyyy}", form["ngay_giao"]);
            ddh.NgayGiao = DateTime.Parse(ngay_giao);
            ddh.TinhTrangGiaoHang = false;
            var is_ddh = cart_repository.addCart(ddh, cart);
            if (is_ddh)
            {
                Session["cart"] = null;
                return RedirectToAction("confirm", "cart");
            }

            return RedirectToAction("cart", "cart");

        }

        public ActionResult Confirm()
        {
            return View();
        }
    }
}