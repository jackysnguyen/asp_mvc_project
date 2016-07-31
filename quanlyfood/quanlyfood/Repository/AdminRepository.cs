using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using quanlyfood.Models;

namespace quanlyfood.Repository
{
    public class AdminRepository
    {
        dbFoodLinQDataContext data = new dbFoodLinQDataContext();

        public AdminModel getAdminLogin(ADMIN admin)
        {
            var admin_model = from ad in data.ADMINs
                              where ad.username == admin.username && ad.password == admin.password
                              select new AdminModel()
                              {
                                  name = ad.name,
                                  username = ad.username,
                                  password = ad.password
                              };
            return admin_model.SingleOrDefault();

        }

    }
}