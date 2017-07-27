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
                foreach(DataRow dr in dt.Rows)
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
            catch(Exception ex)
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

        public static bool Insert(HocSinhModel obj)
        {
            string ngaysinh = "";
            try
            {
                ngaysinh = DateTime.ParseExact(obj.NgaySinh, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            }
            catch { }

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@IDHocSinh", obj.ID),
                new SqlParameter("@IDLop", obj.LopOBJ.IDLop),
                new SqlParameter("@Ten", obj.Ten),
                new SqlParameter("@NgaySinh", ngaysinh),
                new SqlParameter("@GioiTinh", obj.GioiTinh.value),
                new SqlParameter("@DiaChi", obj.DiaChi)
            };

            return db.ExecuteNonQuery("sp_WebUniTag_InsertOrUpdateHocSinh", param) > 0;
        }

        public static bool Update(HocSinhWebOBJ obj)
        {
            string ngaysinh = "";
            try
            {
                ngaysinh = DateTime.ParseExact(obj.NgaySinh, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            }
            catch { }

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@IDHocSinh", obj.ID),
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
    }
}
