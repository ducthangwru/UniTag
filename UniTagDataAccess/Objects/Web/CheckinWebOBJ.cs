using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniTagDataAccess.Objects.Web
{
    public class CheckinWebOBJ
    {
        public int ID { get; set; }
        public int IDPhuHuynh { get; set; }
        public string TenPhuHuynh { get; set; }
        public string AnhPhuHuynh { get; set; }
        public int IDHocSinh { get; set; }
        public string TenHocSinh { get; set; }
        public string AnhHocSinh { get; set; }
        public int IDLop { get; set; }
        public string TenLop { get; set; }
        public int CaDuaDon { get; set; }
        public string TenCa { get; set; }
        public int IDImage { get; set; }
        public string AnhChup { get; set; }
        public string NgayCheckin { get; set; }
        public string GioCheckin { get; set; }
        public string XacNhan { get; set; }
    }
}
