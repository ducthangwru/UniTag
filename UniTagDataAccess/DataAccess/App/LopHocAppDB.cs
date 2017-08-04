using SERVER_ADEN.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using UniTagDataAccess.Objects.App;
using System.Data;

namespace UniTagDataAccess.DataAccess.App
{
    public class LopHocAppDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public LopHocAppDB() { }

        public static string ThongTinSiSoTheoCaDuaDon(int CaDuaDon, int IDHocSinh, int IDLop, string ThoiGianCheckin)
        {
            int siso = int.Parse(db.ExecuteScalar("sp_AppUniTag_SiSoLopCuaHocSinh", new SqlParameter("@idhs", IDHocSinh)).ToString());
            int sisodd = int.Parse(db.ExecuteScalar("sp_AppUniTag_SiSoTrongLopCuaHocSinh", new SqlParameter("@idhs", IDHocSinh), new SqlParameter("@date", ThoiGianCheckin)).ToString());
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@idca", CaDuaDon),
                new SqlParameter("@idlop", IDLop),
                new SqlParameter("@date", ThoiGianCheckin)
            };

            int sisohientai = int.Parse(db.ExecuteScalar("sp_AppUniTag_ThongTinSiSoTheoCaDuaDon", param).ToString());

            if (CaDuaDon == 1)
                return sisohientai + "/" + siso;


            return (sisodd - sisohientai) + "/" + siso;

        }

        public static List<LopHocAppOBJ> DanhSachLopHoc()
        {
            List<LopHocAppOBJ> ds = new List<LopHocAppOBJ>();

            try
            {
                DataTable dt = db.ExecuteDataSet("sp_AppUniTag_DanhSachLopHoc").Tables[0];
                foreach(DataRow dr in dt.Rows)
                {
                    LopHocAppOBJ obj = new LopHocAppOBJ();
                    obj.ID = int.Parse(dr["ID"].ToString());
                    obj.Lop = dr["Lop"].ToString();
                    obj.SiSo = int.Parse(dr["SiSo"].ToString());
                    obj.MaMau = dr["MaMau"].ToString();
                    ds.Add(obj);
                }

                return ds;
            }
            catch(Exception ex)
            {
                return ds;
            }

        }
    }
}
