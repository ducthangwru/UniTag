using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniTagDataAccess.Objects.App
{
    public class HocSinhCheckinAppOBJ
    {
        public HocSinhCheckinAppOBJ()
        {
            imageCheckin = new ImageAppOBJ();
            PhuHuynh = new PhuHuynhAppOBJ();
        }
        public long idCheck { get; set; }
        public int CaDuaDon { get; set; }
        public bool XacNhan { get; set; }
        public string TgianXacNhan { get; set; }
        public ImageAppOBJ imageCheckin { get; set; }
        public PhuHuynhAppOBJ PhuHuynh { get; set; }
    }
}
