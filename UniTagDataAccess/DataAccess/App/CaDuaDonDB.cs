using SERVER_ADEN.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTagDataAccess.Objects.App;

namespace UniTagDataAccess.DataAccess.App
{
    public class CaDuaDonDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public CaDuaDonDB() { }

        public static List<CaDuaDonAppOBJ> DanhSachCaDuaDon()
        {
            List<CaDuaDonAppOBJ> ds = new List<CaDuaDonAppOBJ>();
            try
            {
                DataTable dt = db.ExecuteDataSet("sp_AppUniTag_DanhSachCaDuaDon").Tables[0];
                foreach(DataRow dr in dt.Rows)
                {
                    CaDuaDonAppOBJ obj = new CaDuaDonAppOBJ();
                    obj.ID = int.Parse(dr["ID"].ToString());
                    obj.TenCa = dr["TenCa"].ToString();

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
