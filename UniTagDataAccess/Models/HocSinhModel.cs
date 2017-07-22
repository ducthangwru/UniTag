using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniTagDataAccess.Models
{
    public class HocSinhModel
    {
        public int ID { get; set; }
        public int IDImage { get; set; }
        public LopModel LopOBJ { get; set; }
        public string Ten { get; set; }
        public string NgaySinh { get; set; }
        public GioiTinhModel GioiTinh { get; set; }
        public string DiaChi { get; set; }
    }
}
