using SERVER_ADEN.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTagDataAccess.Objects.App;
using System.Data.SqlClient;

namespace UniTagDataAccess.DataAccess.App
{
    public class HocSinhAppDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public HocSinhAppDB() { }
        public static List<HocSinhAppOBJ> ThongTinHocSinhTheoIDPhuHuynh(int ID)
        {
            List<HocSinhAppOBJ> ds = new List<HocSinhAppOBJ>();
            try
            {
                DataTable dt = db.ExecuteDataSet("sp_AppUniTag_ThongTinHocSinhTheoIDPhuHuynh", new SqlParameter("@id", ID)).Tables[0];
                foreach(DataRow dr in dt.Rows)
                {
                    HocSinhAppOBJ obj = new HocSinhAppOBJ();

                    obj.ID = int.Parse(dr["idhs"].ToString());
                    obj.IDImage = int.Parse(dr["idImageHS"].ToString());
                    obj.Ten = dr["Ten"].ToString();
                    obj.GioiTinh = dr["GioiTinh"].ToString();
                    obj.DiaChi = dr["DiaChi"].ToString();
                    obj.NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
                    obj.Lop = dr["Lop"].ToString();
                    obj.AnhHocSinh = ImagesAppDB.GetThongTinAnhTheoID(obj.IDImage);
                    obj.NgayTao = DateTime.Parse(dr["NgayTao"].ToString()).ToString("dd/MM/yyyy HH:mm:ss");

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
