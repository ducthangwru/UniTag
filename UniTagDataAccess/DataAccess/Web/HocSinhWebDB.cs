using SERVER_ADEN.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTagDataAccess.Objects.Web;

namespace UniTagDataAccess.DataAccess.Web
{
    public class HocSinhWebDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public HocSinhWebDB() { }

        public static List<HocSinhWebOBJ> DanhSachHocSinh()
        {
            List<HocSinhWebOBJ> ds = new List<HocSinhWebOBJ>();
            try
            {
                DataTable dt = db.ExecuteDataSet("sp_WebUniTag_DanhSachHocSinh").Tables[0];
                foreach(DataRow dr in dt.Rows)
                {
                    HocSinhWebOBJ obj = new HocSinhWebOBJ();
                    obj.ID = int.Parse(dr["ID"].ToString());
                    obj.IDImage = int.Parse(dr["IDImage"].ToString());
                    obj.IDLop = int.Parse(dr["IDLop"].ToString());
                    obj.Lop = dr["Lop"].ToString();
                    obj.Ten = dr["Ten"].ToString();
                    obj.NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
                    obj.GioiTinh = dr["GioiTinh"].ToString();
                    obj.DiaChi = dr["DiaChi"].ToString();
                    obj.Path = Utils.Utils.BASEURL + ImagesWebDB.GetPathImage(obj.IDImage);

                    ds.Add(obj);
                }

                return ds;
            }
            catch(Exception ex)
            {
                return ds;
            }
        }

        public static bool InsertOrUpdateHocSinh(HocSinhWebOBJ obj)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@IDHocSinh", obj.ID),
                new SqlParameter("@IDLop", obj.IDLop),
                new SqlParameter("@Ten", obj.Ten),
                new SqlParameter("@NgaySinh", obj.NgaySinh),
                new SqlParameter("@GioiTinh", obj.GioiTinh),
                new SqlParameter("@DiaChi", obj.DiaChi)
            };

            return db.ExecuteNonQuery("sp_WebUniTag_InsertOrUpdateHocSinh", param) > 0;
        }

        public static bool DeleteHocSinh(int IDHocSinh)
        {
            return db.ExecuteNonQuery("sp_WebUniTag_DeleteHocSinh", new SqlParameter("@IDHocSinh", IDHocSinh)) > 0;
        }
    }
}
