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
    public class MoiQuanHeWebDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public MoiQuanHeWebDB() {  }
        public static List<MoiQuanHeWebOBJ> DanhSachMoiQuanHe()
        {
            List<MoiQuanHeWebOBJ> ds = new List<MoiQuanHeWebOBJ>();
            try
            {
                DataTable dt = db.ExecuteDataSet("sp_WebUniTag_DanhSachMoiQuanHe").Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    MoiQuanHeWebOBJ obj = new MoiQuanHeWebOBJ();
                    obj.ID = int.Parse(dr["ID"].ToString());
                    obj.TenMoiQuanHe = dr["TenMoiQuanHe"].ToString();
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
