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
        public static HocSinhAppOBJ ThongTin1HocSinhTheoIDPhuHuynh(int ID, int idLop, int count)
        {
            HocSinhAppOBJ obj = new HocSinhAppOBJ();
            try
            {
                DataTable dt = db.ExecuteDataSet("sp_AppUniTag_ThongTinHocSinhTheoIDPhuHuynh", new SqlParameter("@id", ID), new SqlParameter("@idlop", idLop)).Tables[0];
                DataRow dr = dt.Rows[count % (dt.Rows.Count)];


                obj.ID = int.Parse(dr["idhs"].ToString());
                obj.IDImage = int.Parse(dr["idImageHS"].ToString());
                obj.Ten = dr["Ten"].ToString();
                obj.GioiTinh = dr["GioiTinh"].ToString();
                obj.DiaChi = dr["DiaChi"].ToString();
                obj.NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
                obj.Lop = dr["Lop"].ToString();
                obj.AnhHocSinh = ImagesAppDB.GetThongTinAnhTheoID(obj.IDImage);
                obj.NgayTao = DateTime.Parse(dr["NgayTao"].ToString()).ToString("dd/MM/yyyy HH:mm:ss");
                return obj;
            }
            catch (Exception ex)
            {
                return obj;
            }
        }
    }
}
