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
    public class IndexAdminController : BaseAdminController
    {
        AdminRepository admin_repository = new AdminRepository();
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}