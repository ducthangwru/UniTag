using SERVER_ADEN.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTagDataAccess.Objects.App;

namespace UniTagDataAccess.DataAccess.App
{
    public class CheckinAppDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public CheckinAppDB() { }

        public static bool InsertCheckin(int IDPhuHuynh, int IDHocSinh, int Lop, long IDImage, int CaDuaDon, bool XacNhan)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@IDPhuHuynh", IDPhuHuynh),
                new SqlParameter("@IDHocSinh", IDHocSinh),
                new SqlParameter("@IDLop", Lop),
                new SqlParameter("@IDImage", IDImage),
                new SqlParameter("@CaDuaDon", CaDuaDon),
                new SqlParameter("@XacNhan", XacNhan)
            };

            return db.ExecuteNonQuery("sp_AppUniTag_InsertCheckin", param) > 0;
        }
    }
}
