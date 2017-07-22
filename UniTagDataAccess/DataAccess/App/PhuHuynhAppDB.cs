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
        public static PhuHuynhAppOBJ GetThongTinPhuHuynhTheoIDThe(string id, int idLop, int idCa)
        {
            PhuHuynhAppOBJ obj = new PhuHuynhAppOBJ();
            try
            {
                DataTable dt = db.ExecuteDataSet("sp_AppUniTag_GetThongTinPHTheoIDThe", new SqlParameter("@idthe", id), new SqlParameter("idca", idCa)).Tables[0];
                DataRow dr = dt.Rows[0];
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
                int count = int.Parse(dr["SoLanCheckinTheoCa"].ToString());
                obj.HocSinh = HocSinhAppDB.ThongTin1HocSinhTheoIDPhuHuynh(obj.ID, idLop, count);
                obj.Image = ImagesAppDB.GetThongTinAnhTheoID(obj.IDImage);
                obj.NgayTao = DateTime.Parse(dr["NgayTao"].ToString()).ToString("dd/MM/yyyy HH:mm:ss");
                return obj;
            }
            catch (Exception ex)
            {
                return obj;
            }
        }
    }
}
