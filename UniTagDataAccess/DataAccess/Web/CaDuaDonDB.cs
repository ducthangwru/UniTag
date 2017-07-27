using SERVER_ADEN.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTagDataAccess.Objects.Web;

namespace UniTagDataAccess.DataAccess.Web
{
    public class CaDuaDonDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public CaDuaDonDB() { }

        public static List<CaDuaDonWebOBJ> DanhSachCa()
        {
            List<CaDuaDonWebOBJ> ds = new List<CaDuaDonWebOBJ>();
            try
            {
                DataTable dt = db.ExecuteDataSet("sp_AppUniTag_DanhSachCaDuaDon").Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    CaDuaDonWebOBJ obj = new CaDuaDonWebOBJ();
                    obj.IDCa = int.Parse(dr["ID"].ToString());
                    obj.TenCa = dr["TenCa"].ToString();

                    ds.Add(obj);
                }

                return ds;

            }
            catch
            {
                return ds;
            }
        }
    }
}
