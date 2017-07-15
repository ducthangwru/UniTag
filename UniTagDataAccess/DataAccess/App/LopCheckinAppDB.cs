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
    public class LopCheckinAppDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public static List<LopCheckinAppOBJ> DanhSachLopHocTheoNgay(string NgaySql)
        {
            List<LopCheckinAppOBJ> OBJ = new List<LopCheckinAppOBJ>();
            try
            {
                DataTable dt = db.ExecuteDataSet("sp_AppUniTag_DanhSachLopHocCheckinTheoNgay", new SqlParameter("@date", NgaySql)).Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    LopCheckinAppOBJ obj = new LopCheckinAppOBJ();
                    obj.idLop = int.Parse(dr["IDLop"].ToString());
                    obj.TenLop = dr["Lop"].ToString();
                    obj.NgaySql = NgaySql;
                    SqlParameter[] param = new SqlParameter[]{
                        new SqlParameter("@date", NgaySql),
                        new SqlParameter("@idlop", obj.idLop)
                    };
                    obj.SoLuongCheckin = int.Parse(db.ExecuteScalar("sp_AppUniTag_SoLuongCheckinTheoLopHoc", param).ToString());
                    SqlParameter[] param1 = new SqlParameter[]{
                        new SqlParameter("@date", NgaySql),
                        new SqlParameter("@idlop", obj.idLop)
                    };
                    obj.SiSoCheckin = int.Parse(db.ExecuteScalar("sp_AppUniTag_SiSoLopHocCheckinTheoNgay", param1).ToString());
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
