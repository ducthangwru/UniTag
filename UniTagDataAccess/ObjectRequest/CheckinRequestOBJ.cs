using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniTagDataAccess.ObjectRequest
{
    public class CheckinRequestOBJ
    {
        public int IDPhuHuynh { get; set; }
        public int IDHocSinh { get; set; }
        public int CaDuaDon { get; set; }
        public int Lop { get; set; }
        public string ThoiGianChup { get; set; }
        public bool XacNhan { get; set; }
    }
}
