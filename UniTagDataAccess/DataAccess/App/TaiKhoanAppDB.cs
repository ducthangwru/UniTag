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
    public class TaiKhoanAppDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public static TaiKhoanAppOBJ ThongTinTaiKhoan(string username, string password){
            TaiKhoanAppOBJ obj = new TaiKhoanAppOBJ();
            try{
                SqlParameter[] param = new SqlParameter[]{
                    new SqlParameter("@username", username),
                    new SqlParameter("@password", password)
                };
                DataRow dr = db.ExecuteDataSet("sp_AppUniTag_Login", param).Tables[0].Rows[0];
                obj.id = long.Parse(dr["id"].ToString());
                obj.username = dr["username"].ToString();
                obj.password = dr["password"].ToString();
                obj.sdt = dr["SDT"].ToString();
                obj.TenTK = dr["TenTK"].ToString();
                obj.DiaChi = dr["DiaChi"].ToString();
                obj.Email = dr["Email"].ToString();
                return obj;
            }
            catch (Exception ex){
                return obj;
            }
            

        }
    }
}
