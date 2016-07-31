using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quanlyfood.Models;
using quanlyfood.Repository;

namespace quanlyfood.Controllers.Admin
{
    public abstract class BaseAdminController : Controller
    {
        public dbFoodLinQDataContext data = new dbFoodLinQDataContext();
    }
}