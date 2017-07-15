using SERVER_ADEN.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using UniTagDataAccess.Objects.App;

namespace UniTagDataAccess.DataAccess.App
{
    public class PhuHuynhAppDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public PhuHuynhAppDB() { }
        public static PhuHuynhAppOBJ GetThongTinPhuHuynhTheoIDThe(string id)
        {
            PhuHuynhAppOBJ obj = new PhuHuynhAppOBJ();
            try
            {
                DataTable dt = db.ExecuteDataSet("sp_AppUniTag_GetThongTinPHTheoIDThe", new SqlParameter("@idthe", id)).Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    obj.ID = int.Parse(dr["ID"].ToString());
                    obj.IDThe = dr["IDThe"].ToString();
                    obj.IDImage = int.Parse(dr["IDImage"].ToString());
                    obj.TenPhuHuynh = dr["TenPhuHuynh"].ToString();
                    obj.DiaChi = dr["DiaChi"].ToString();
                    obj.NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
                    obj.IDMoiQuanHe = int.Parse(dr["IDMoiQuanHe"].ToString());
                    obj.MoiQuanHe = dr["TenMoiQuanHe"].ToString();
                    obj.GioiTinh = dr["GioiTinh"].ToString();
                    obj.isActive = bool.Parse(dr["isActive"].ToString());
                    obj.HocSinh = HocSinhAppDB.ThongTinHocSinhTheoIDPhuHuynh(obj.ID);
                    obj.Image = ImagesAppDB.GetThongTinAnhTheoID(obj.IDImage);
                    obj.NgayTao = DateTime.Parse(dr["NgayTao"].ToString()).ToString("dd/MM/yyyy HH:mm:ss");
                }

                return obj;
            }
            catch(Exception ex)
            {
                return obj;
            }
        }
    }
}
