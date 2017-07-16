using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniTagDataAccess.Objects.App
{
    public class HocSinhCheckinAppOBJ
    {
        public long idCheck { get; set; }
        public int idHocSinh { get; set; }
        public ImageAppOBJ image { get; set; }
        public string Ten { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public bool XacNhan { get; set; }
    }
}
