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
    public class PhuHuynhWebDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public PhuHuynhWebDB() { }
        public static List<PhuHuynhWebOBJ> DanhSachPhuHuynh()
        {
            List<PhuHuynhWebOBJ> ds = new List<PhuHuynhWebOBJ>();
            try
            {
                DataTable dt = db.ExecuteDataSet("sp_WebUniTag_DanhSachPhuHuynh").Tables[0];
                foreach(DataRow dr in dt.Rows)
                {
                    PhuHuynhWebOBJ obj = new PhuHuynhWebOBJ();
                    obj.ID = int.Parse(dr["ID"].ToString());
                    obj.IDThe = dr["IDThe"].ToString();
                    obj.IDImage = int.Parse(dr["IDImage"].ToString());
                    obj.NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
                    obj.DiaChi = dr["DiaChi"].ToString();
                    obj.TenPhuHuynh = dr["TenPhuHuynh"].ToString();
                    obj.Path = Utils.Utils.BASEURL + ImagesWebDB.GetPathImage(obj.IDImage);
                    obj.GioiTinh = dr["GioiTinh"].ToString();
                    obj.IDMoiQuanHe = int.Parse(dr["IDMoiQuanHe"].ToString());
                    obj.TenMoiQuanHe = dr["TenMoiQuanHe"].ToString();
                    obj.isActive = (bool.Parse(dr["isActive"].ToString()) == true) ? "Đã kích hoạt" : "Chưa kích hoạt";

                    ds.Add(obj);
                }

                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }

        public static bool InsertOrUpdatePhuHuynh(PhuHuynhWebOBJ obj)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@IDPhuHuynh", obj.ID),
                new SqlParameter("@IDThe", obj.IDThe),
                new SqlParameter("@TenPhuHuynh", obj.TenPhuHuynh),
                new SqlParameter("@DiaChi", obj.DiaChi),
                new SqlParameter("@NgaySinh", obj.NgaySinh),
                new SqlParameter("@IDMoiQuanHe", obj.IDMoiQuanHe),
                new SqlParameter("@GioiTinh", obj.GioiTinh)
            };

            return db.ExecuteNonQuery("sp_WebUniTag_InsertOrUpdatePhuHuynh", param) > 0;
        }

        public static bool DeletePhuHuynh(int IDPhuHuynh)
        {
            return db.ExecuteNonQuery("sp_WebUniTag_DeletePhuHuynh", new SqlParameter("@IDPhuHuynh", IDPhuHuynh)) > 0;
        }

        public static bool UpdateImagePhuHuynh(int IDPhuHuynh, int IDImage)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@IDPhuHuynh", IDPhuHuynh),
                new SqlParameter("@IDImage", IDImage)
            };

            return db.ExecuteNonQuery("sp_WebUniTag_UpdateImagePhuHuynh", param) > 0;
        }

        public static bool ActiveThePhuHuynh(int IDPhuHuynh, bool isActive)
        {
            SqlParameter[] param = new SqlParameter[]
           {
                new SqlParameter("@IDPhuHuynh", IDPhuHuynh),
                new SqlParameter("@isActive", isActive)
           };
            return db.ExecuteNonQuery("sp_WebUniTag_ActiveThePhuHuynh", param) > 0;
        }
    }
}
