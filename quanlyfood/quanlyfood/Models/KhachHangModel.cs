using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace quanlyfood.Models
{
    public class KhachHangModel
    {
        public int MaKH { get; set; }
        public string HoTen { get; set; }
        public string Taikhoan { get; set; }
        public string Matkhau { get; set; }
        public string Email { get; set; }
        public string DiachiKH { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string DienthoaiKH { get; set; }
        

    }
}