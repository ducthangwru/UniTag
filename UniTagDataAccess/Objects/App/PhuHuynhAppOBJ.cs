using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniTagDataAccess.Objects.App
{
    public class PhuHuynhAppOBJ
    {
        public PhuHuynhAppOBJ()
        {
            IDThe = "";
            TenPhuHuynh = "";
            DiaChi = "";
            NgaySinh = "";
            GioiTinh = "";
            MoiQuanHe = "";
            NgayTao = "";
            Image = new ImageAppOBJ();
            HocSinh = new List<HocSinhAppOBJ>();
        }
        public int ID { get; set; }
        public string IDThe { get; set; }
        public int IDImage { get; set; }
        public string TenPhuHuynh { get; set; }
        public string DiaChi { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public int IDMoiQuanHe { get; set; }
        public string MoiQuanHe { get; set; }
        public string NgayTao { get; set; }
        public bool isActive { get; set; }
        public ImageAppOBJ  Image { get; set; }
        public List<HocSinhAppOBJ> HocSinh { get; set; }
    }
}
