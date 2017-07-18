using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniTagDataAccess.Objects.App
{
    public class TaiKhoanAppOBJ
    {
        public TaiKhoanAppOBJ()
        {
            username = "";
            password = "";
            TenTK = "";
            DiaChi = "";
            Email = "";
            sdt = "";
        }
        public long id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string TenTK { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string sdt { get; set; }
    }
}
