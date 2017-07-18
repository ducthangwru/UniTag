using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniTagDataAccess.Objects.Web
{
    public class PhuHuynhWebOBJ
    {
        public int ID { get; set; }
        public string IDThe { get; set; }
        public int IDImage { get; set; }
        public string Path { get; set; }
        public string TenPhuHuynh { get; set; }
        public string DiaChi { get; set; }
        public string NgaySinh { get; set; }
        public int IDMoiQuanHe { get; set; }
        public string TenMoiQuanHe { get; set; }
        public string GioiTinh { get; set; }
        public string isActive { get; set; }
    }
}
