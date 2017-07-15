using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniTagDataAccess.Objects.App
{
    public class HocSinhAppOBJ
    {
        public int ID { get; set; }
        public int IDImage { get; set; }
        public string Ten { get; set; }
        public string Lop { get; set; }
        public string GioiTinh { get; set; }
        public string NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string NgayTao { get; set; }
        public ImageAppOBJ AnhHocSinh { get; set; }
    }
}
