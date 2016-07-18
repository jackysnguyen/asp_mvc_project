using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace quanlyfood.Models
{
    public class MenuModel
    {
        public int id {
            get;
            set;
        }

        public string ten {
            get;
            set;
        }

        public string slug {
            get;
            set;
        }

        public List<MenuModel> childrent {
            get;
            set;
        }


    }
}