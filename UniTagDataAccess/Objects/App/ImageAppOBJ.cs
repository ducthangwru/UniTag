using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniTagDataAccess.Objects.App
{
    public class ImageAppOBJ
    {
        public ImageAppOBJ()
        {
            Path = "";
            ThoiGianChup = "";
            NgayTao = "";
        }
        public long ID { get; set; }
        public string Path { get; set; }
        public string ThoiGianChup { get; set; }
        public string NgayTao { get; set; }
    }
}
