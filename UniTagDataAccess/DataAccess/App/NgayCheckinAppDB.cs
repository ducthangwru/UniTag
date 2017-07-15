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
    public class NgayCheckinAppDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public static List<NgayCheckinAppOBJ> DanhSachNgayCheckin(){
            List<NgayCheckinAppOBJ> ds = new List<NgayCheckinAppOBJ>();
            try
            {
                DataTable dt = db.ExecuteDataSet("sp_AppUniTag_DanhSachNgay").Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    NgayCheckinAppOBJ obj = new NgayCheckinAppOBJ();
                    obj.NgaySql = DateTime.Parse(dr["ThoiGian"].ToString()).ToString("yyyy-MM-dd");
                    obj.NgayCheckin = DateTime.Parse(obj.NgaySql).ToString("dd/MM/yyyy");
                    obj.SoLuongCheckin = int.Parse(db.ExecuteScalar("sp_AppUniTag_SoLuongCheckinTheoNgay", new SqlParameter("@date", obj.NgaySql)).ToString());
                    obj.LuotCheckinCuoi = DateTime.Parse(db.ExecuteScalar("sp_AppUniTag_getTimeLuotCheckCuoiTheoNgay",
                        new SqlParameter("@date", obj.NgaySql)).ToString()).ToString("HH:mm:ss");
                    ds.Add(obj);
                    
                }
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }

        }
    }
}
