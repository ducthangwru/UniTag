using SERVER_ADEN.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTagDataAccess.Objects.App;

namespace UniTagDataAccess.DataAccess.App
{
    public class CaCheckinDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public static List<CaCheckinAppOBJ> DanhSachCaTheoNgay(string date, int idlop)
        {
            List<CaCheckinAppOBJ> OBJ = new List<CaCheckinAppOBJ>();
            try
            {
                SqlParameter[] dt_param = new SqlParameter[]{
                    new SqlParameter("@date",date),
                    new SqlParameter("@idlop", idlop)
                };
                DataTable dt = db.ExecuteDataSet("sp_AppUniTag_getCaTheoNgayVaLop", dt_param).Tables[0];
                foreach (DataRow dr in  dt.Rows)
                {
                    CaCheckinAppOBJ obj = new CaCheckinAppOBJ();
                    obj.idCa = int.Parse(dr["CaDuaDon"].ToString());
                    obj.TenCa = dr["TenCa"].ToString();
                    SqlParameter[] param = new SqlParameter[]{
                        new SqlParameter("@idca", obj.idCa),
                        new SqlParameter("@date", date),
                        new SqlParameter("@idlop", idlop)
                    };
                    obj.SoLuongCheckin = int.Parse(db.ExecuteScalar("sp_AppUniTag_SoLuongCheckinTheoCaVaNgay", param).ToString());
                    SqlParameter[] param1 = new SqlParameter[]{
                        new SqlParameter("@idca", obj.idCa),
                        new SqlParameter("@date", date),
                        new SqlParameter("@idlop", idlop)
                    };
                    obj.SiSo = int.Parse(db.ExecuteScalar("sp_AppUniTag_ThongTinSiSoTheoCaDuaDon", param1).ToString());
                    obj.NgaySql = date;
                    OBJ.Add(obj);
                }
                return OBJ;
            }
            catch (Exception ex)
            {
                return OBJ;
            }
        }
    }
}
