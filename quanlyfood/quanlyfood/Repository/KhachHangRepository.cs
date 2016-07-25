using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using quanlyfood.Models;

namespace quanlyfood.Repository
{
    public class KhachHangRepository
    {
        dbFoodLinQDataContext data = new dbFoodLinQDataContext();
        public Boolean addCustomer(KHACHHANG kh)
        {
            data.KHACHHANGs.InsertOnSubmit(kh);
            data.SubmitChanges();
            if(kh.MaKH != null)
            {
                return true;
            }
            return false;

        }

    }
}