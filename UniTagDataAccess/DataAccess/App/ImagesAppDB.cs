using SERVER_ADEN.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTagDataAccess.Objects.App;
using System.Data.SqlClient;
using System.Globalization;

namespace UniTagDataAccess.DataAccess.App
{
    public class ImagesAppDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public ImagesAppDB() { }
        public static ImageAppOBJ GetThongTinAnhTheoID(int idimage)
        {
            ImageAppOBJ obj = new ImageAppOBJ();
            try
            {
                DataTable dt = db.ExecuteDataSet("sp_AppUniTag_GetThongTinAnhTheoID", new SqlParameter("@idimage", idimage)).Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    obj.ID = int.Parse(dr["ID"].ToString());
                    obj.Path = Utils.Utils.BASEURL + dr["Path"].ToString();
                    obj.ThoiGianChup = DateTime.Parse(dr["ThoiGianChup"].ToString()).ToString("dd/MM/yyyy HH:mm:ss");
                    obj.NgayTao = DateTime.Parse(dr["NgayTao"].ToString()).ToString("dd/MM/yyyy HH:mm:ss");
                }

                return obj;
            }
            catch(Exception ex)
            {
                return obj;
            }
        }

        public static int InsertImage(string path, string thoigianchup)
        {
            try
            {
                thoigianchup = DateTime.ParseExact(thoigianchup, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch(Exception ex)
            {}

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@path", path),
                new SqlParameter("@thoigianchup", thoigianchup)
            };

            try
            {
                return int.Parse(db.ExecuteScalar("sp_AppUniTag_ThemAnh", param).ToString());
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
    }
}
