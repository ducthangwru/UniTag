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
    public class ClassWebDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public static List<ClassWebOBJ> DanhSachLopHoc()
        {
            List<ClassWebOBJ> ds = new List<ClassWebOBJ>();

            try
            {
                DataTable dt = db.ExecuteDataSet("sp_AppUniTag_DanhSachLopHoc").Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    ClassWebOBJ obj = new ClassWebOBJ();
                    obj.IDLop = int.Parse(dr["ID"].ToString());
                    obj.Lop = dr["Lop"].ToString();
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
