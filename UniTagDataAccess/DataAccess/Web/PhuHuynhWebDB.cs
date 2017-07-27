using SERVER_ADEN.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
                    obj.TenHocSinh = "";
                    DataTable dt2 = db.ExecuteDataSet("sp_WebUniTag_DanhSachHocSinhTheoPhuHuynh", new SqlParameter("@IDPhuHuynh", obj.ID)).Tables[0];
                    foreach(DataRow dr2 in dt2.Rows)
                    {
                        obj.TenHocSinh += dr2["Ten"].ToString();
                    }
                    ds.Add(obj);
                }

                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }

        public static List<PhuHuynhWebOBJ> DanhSachPhuHuynh(string Ten, string MaThe)
        {
            List<PhuHuynhWebOBJ> ds = new List<PhuHuynhWebOBJ>();
            try
            {
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@Ten", Ten),
                    new SqlParameter("@MaThe", MaThe)
                };
            
                DataTable dt = db.ExecuteDataSet("sp_WebUniTag_DanhSachPhuHuynh", param).Tables[0];
                foreach (DataRow dr in dt.Rows)
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
                    obj.TenHocSinh = "";
                    DataTable dt2 = db.ExecuteDataSet("sp_WebUniTag_DanhSachHocSinhTheoPhuHuynh", new SqlParameter("@IDPhuHuynh", obj.ID)).Tables[0];
                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        obj.TenHocSinh += dr2["Ten"].ToString();
                    }
                    ds.Add(obj);
                }

                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }

        public static bool Insert(PhuHuynhWebOBJ obj)
        {
            string ngaysinh = "";
            try
            {
                ngaysinh = DateTime.ParseExact(obj.NgaySinh, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            }
            catch { }

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@IDPhuHuynh", obj.ID),
                new SqlParameter("@IDThe", obj.IDThe),
                new SqlParameter("@TenPhuHuynh", obj.TenPhuHuynh),
                new SqlParameter("@DiaChi", obj.DiaChi),
                new SqlParameter("@NgaySinh", ngaysinh),
                new SqlParameter("@IDMoiQuanHe", obj.IDMoiQuanHe),
                new SqlParameter("@GioiTinh", obj.GioiTinh)
            };

            return db.ExecuteNonQuery("sp_WebUniTag_InsertOrUpdatePhuHuynh", param) > 0;
        }

        public static bool Update(PhuHuynhWebOBJ obj)
        {
            string ngaysinh = "";
            try
            {
                ngaysinh = DateTime.ParseExact(obj.NgaySinh, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            }
            catch {  }

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@IDPhuHuynh", obj.ID),
                new SqlParameter("@IDThe", obj.IDThe),
                new SqlParameter("@TenPhuHuynh", obj.TenPhuHuynh),
                new SqlParameter("@DiaChi", obj.DiaChi),
                new SqlParameter("@NgaySinh", ngaysinh),
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

        public static bool GanHocSinh(string IDPhuHuynh, string IDHocSinh)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@IDPhuHuynh", IDPhuHuynh),
                    new SqlParameter("@IDHocSinh", IDHocSinh)
                };

                return db.ExecuteNonQuery("sp_WebUniTag_GanMoiQuanHePHHS", param) > 0;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static bool ActiveThePhuHuynh(string IDThe)
        {
            return db.ExecuteNonQuery("sp_WebUniTag_ActiveThePhuHuynh", new SqlParameter("@IDThe", IDThe)) > 0;
        }
    }
}
