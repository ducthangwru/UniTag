using SERVER_ADEN.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTagDataAccess.Models;
using UniTagDataAccess.Objects.Web;

namespace UniTagDataAccess.DataAccess.Web
{
    public class HocSinhWebDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public HocSinhWebDB() { }

        public static List<HocSinhWebOBJ> DanhSachHocSinh()
        {
            List<HocSinhWebOBJ> ds = new List<HocSinhWebOBJ>();
            try
            {
                DataTable dt = db.ExecuteDataSet("sp_WebUniTag_DanhSachHocSinh").Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    HocSinhWebOBJ obj = new HocSinhWebOBJ();
                    obj.ID = int.Parse(dr["ID"].ToString());
                    obj.IDImage = int.Parse(dr["IDImage"].ToString());
                    obj.IDLop = int.Parse(dr["IDLop"].ToString());
                    obj.Lop = dr["Lop"].ToString();
                    obj.Ten = dr["Ten"].ToString();
                    obj.NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
                    obj.GioiTinh = dr["GioiTinh"].ToString();
                    obj.DiaChi = dr["DiaChi"].ToString();
                    obj.Path = Utils.Utils.BASEURL + ImagesWebDB.GetPathImage(obj.IDImage);

                    ds.Add(obj);
                }

                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }

        public static List<HocSinhWebOBJ> DanhSachHocSinh(string Ten, string IDLop)
        {
            int id = 0;

            try
            {
                id = int.Parse(IDLop);
            }
            catch { }

            List<HocSinhWebOBJ> ds = new List<HocSinhWebOBJ>();
            try
            {
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("IDLop", id),
                    new SqlParameter("Ten", Ten)
                };

                DataTable dt = db.ExecuteDataSet("sp_WebUniTag_DanhSachHocSinh", param).Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    HocSinhWebOBJ obj = new HocSinhWebOBJ();
                    obj.ID = int.Parse(dr["ID"].ToString());
                    obj.IDImage = int.Parse(dr["IDImage"].ToString());
                    obj.IDLop = int.Parse(dr["IDLop"].ToString());
                    obj.Lop = dr["Lop"].ToString();
                    obj.Ten = dr["Ten"].ToString();
                    obj.NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
                    obj.GioiTinh = dr["GioiTinh"].ToString();
                    obj.DiaChi = dr["DiaChi"].ToString();
                    obj.Path = Utils.Utils.BASEURL + ImagesWebDB.GetPathImage(obj.IDImage);

                    ds.Add(obj);
                }

                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }

        public static List<HocSinhWebModel> DanhSachHS()
        {
            List<HocSinhWebModel> ds = new List<HocSinhWebModel>();
            try
            {
                DataTable dt = db.ExecuteDataSet("sp_WebUniTag_DanhSachHocSinh").Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    HocSinhWebModel obj = new HocSinhWebModel();
                    obj.IDHocSinh = int.Parse(dr["ID"].ToString());
                    obj.TenHocSinh = dr["Ten"].ToString();
                    ds.Add(obj);
                }

                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }

        public static int Insert(HocSinhModel obj, int idAnh)
        {
            string ngaysinh = "";
            try
            {
                ngaysinh = DateTime.Parse(obj.NgaySinh).ToString("yyyy-MM-dd");
            }
            catch { }
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@IDHocSinh", obj.ID),
                new SqlParameter("@IDImage", idAnh),
                new SqlParameter("@IDLop", obj.IDLop.IDLop),
                new SqlParameter("@Ten", obj.Ten),
                new SqlParameter("@NgaySinh", ngaysinh),
                new SqlParameter("@GioiTinh", obj.GioiTinh),
                new SqlParameter("@DiaChi", obj.DiaChi)
            };
            return int.Parse(db.ExecuteScalar("sp_WebUniTag_InsertOrUpdateHocSinh", param).ToString());
        }

        public static bool Update(HocSinhWebOBJ obj)
        {
            string ngaysinh = "";
            try
            {
                ngaysinh = DateTime.Parse(obj.NgaySinh).ToString("yyyy-MM-dd");
            }
            catch { }

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@IDHocSinh", obj.ID),
                new SqlParameter("@IDImage",obj.IDImage),
                new SqlParameter("@IDLop", obj.IDLop),
                new SqlParameter("@Ten", obj.Ten),
                new SqlParameter("@NgaySinh", ngaysinh),
                new SqlParameter("@GioiTinh", obj.GioiTinh),
                new SqlParameter("@DiaChi", obj.DiaChi)
            };

            return db.ExecuteNonQuery("sp_WebUniTag_InsertOrUpdateHocSinh", param) > 0;
        }

        public static bool DeleteHocSinh(int IDHocSinh)
        {
            return db.ExecuteNonQuery("sp_WebUniTag_DeleteHocSinh", new SqlParameter("@IDHocSinh", IDHocSinh)) > 0;
        }
        public static List<HocSinhWebModel> DanhSachHSTheoLop(int idlop)
        {
            List<HocSinhWebModel> ds = new List<HocSinhWebModel>();
            try
            {
                DataTable dt = db.ExecuteDataSet("sp_WebUniTag_DanhSachHocSinhTheoLop", new SqlParameter("@idlop", idlop)).Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    HocSinhWebModel obj = new HocSinhWebModel();
                    obj.IDHocSinh = int.Parse(dr["ID"].ToString());
                    obj.TenHocSinh = dr["Ten"].ToString();
                    ds.Add(obj);
                }

                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }
        public static bool UpdateAnhHocSinh(string path, int idHS)
        {
            try
            {
                string time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                SqlParameter[] param = new SqlParameter[]{
                    new SqlParameter("@path", path),
                    new SqlParameter("@thoigianchup", time)
                };
                int idAnh = int.Parse(db.ExecuteScalar("sp_AppUniTag_ThemAnh", param).ToString());
                SqlParameter[] param1 = new SqlParameter[]{
                    new SqlParameter("@IDHocSinh", idHS),
                    new SqlParameter("@IDImage", idAnh)
                };
                return db.ExecuteNonQuery("sp_WebUniTag_UpdateImageHocSinh", param1) > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static int ThemAnhHocSinh(string path)
        {
            try
            {
                string time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                SqlParameter[] param = new SqlParameter[]{
                    new SqlParameter("@path", path),
                    new SqlParameter("@thoigianchup", time)
                };
                return int.Parse(db.ExecuteScalar("sp_AppUniTag_ThemAnh", param).ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
