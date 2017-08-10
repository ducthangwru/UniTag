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
                bool res = Boolean.Parse(db.ExecuteScalar("sp_AppUniTag_CheckIDThe", new SqlParameter("@idthe", id)).ToString());
                if (res == false) { obj.IDThe = "wrong"; return obj; }
                DataRow dr = dt.Rows[0];
                obj.ID = int.Parse(dr["ID"].ToString());
                obj.IDThe = dr["IDThe"].ToString();
                obj.IDImage = int.Parse(dr["IDImage"].ToString());
                obj.TenPhuHuynh = dr["TenPhuHuynh"].ToString();
                obj.DiaChi = dr["DiaChi"].ToString();
                obj.NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
                
                obj.GioiTinh = dr["GioiTinh"].ToString();
                obj.isActive = bool.Parse(dr["isActive"].ToString());
                int count = int.Parse(dr["SoLanCheckinTheoCa"].ToString());
                obj.HocSinh = HocSinhAppDB.ThongTin1HocSinhTheoIDPhuHuynh(obj.ID, idLop, count);
                DataRow dr3 = db.ExecuteDataSet("sp_AppUniTag_getMQH", new SqlParameter("@idph", obj.ID), new SqlParameter("@idhs", obj.HocSinh.ID)).Tables[0].Rows[0];
                obj.IDMoiQuanHe = int.Parse(dr3["id"].ToString());
                obj.MoiQuanHe = dr3["TenMoiQuanHe"].ToString();
                obj.Image = ImagesAppDB.GetThongTinAnhTheoID(obj.IDImage);
                obj.NgayTao = DateTime.Parse(dr["NgayTao"].ToString()).ToString("dd/MM/yyyy HH:mm:ss");
                if (idCa == 2)
                {

                    try
                    {
                        bool check = Boolean.Parse(db.ExecuteScalar("sp_AppUniTag_CheckGuiTre", new SqlParameter("@idhs", obj.HocSinh.ID), new SqlParameter("@idlop", idLop)).ToString());
                        if (!check) return null;
                        string ngay = DateTime.Now.ToString("yyyy-MM-dd");
                        obj.IDImage = int.Parse(db.ExecuteScalar("sp_AppUniTag_IDAnhGuiTre", new SqlParameter("@idhs", obj.HocSinh.ID), new SqlParameter("@date", ngay), new SqlParameter("@idlop", idLop)).ToString());
                        obj.Image = ImagesAppDB.GetThongTinAnhTheoID(obj.IDImage);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                return obj;
            }
        }
    }
}
