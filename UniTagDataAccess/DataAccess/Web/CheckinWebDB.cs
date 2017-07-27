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
    public class CheckinWebDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public CheckinWebDB() { }

        public static List<CheckinWebOBJ> DanhSachCheckin()
        {
            List<CheckinWebOBJ> ds = new List<CheckinWebOBJ>();
            try
            {
                DataTable dt = db.ExecuteDataSet("sp_WebUniTag_DanhSachCheckin").Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    CheckinWebOBJ obj = new CheckinWebOBJ();
                    obj.ID = int.Parse(dr["ID"].ToString());
                    obj.IDHocSinh = int.Parse(dr["IDHocSinh"].ToString());
                    obj.IDPhuHuynh = int.Parse(dr["IDPhuHuynh"].ToString());
                    obj.IDImage = int.Parse(dr["IDImage"].ToString());
                    obj.IDLop = int.Parse(dr["IDLop"].ToString());
                    obj.CaDuaDon = int.Parse(dr["CaDuaDon"].ToString());
                    obj.TenCa = dr["TenCa"].ToString();
                    obj.TenPhuHuynh = dr["TenPhuHuynh"].ToString();
                    obj.TenLop = dr["Lop"].ToString();
                    obj.TenHocSinh = dr["Ten"].ToString();
                    obj.NgayCheckin = DateTime.Parse(dr["ThoiGian"].ToString()).ToString("dd/MM/yyyy");
                    obj.GioCheckin = DateTime.Parse(dr["ThoiGian"].ToString()).ToString("HH:mm:ss");
                    obj.XacNhan = (bool.Parse(dr["XacNhan"].ToString()) == true) ? "Xác nhận" : "Từ chối";
                    obj.AnhChup = Utils.Utils.BASEURL + ImagesWebDB.GetPathImage(obj.IDImage);
                    obj.AnhHocSinh = Utils.Utils.BASEURL + ImagesWebDB.GetPathImage(int.Parse(dr["IDImageHS"].ToString()));
                    obj.AnhPhuHuynh = Utils.Utils.BASEURL + ImagesWebDB.GetPathImage(int.Parse(dr["IDImagePH"].ToString()));

                    ds.Add(obj);
                }
                return ds;
            }
            catch(Exception ex)
            {
                return ds;
            }
        }

        public static List<CheckinWebOBJ> DanhSachCheckin(string Ngay, string IDLop, string IDCa)
        {
            string ngay = "";
            int idlop = 0;
            int idca = 0;

            try
            {
                idlop = int.Parse(IDLop);
                idca = int.Parse(IDCa);
                ngay = DateTime.ParseExact(Ngay, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            }
            catch { }
            List<CheckinWebOBJ> ds = new List<CheckinWebOBJ>();
            try
            {
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@Ngay", ngay),
                    new SqlParameter("IDLop", idlop),
                    new SqlParameter("@IDCa", idca)
                };

                DataTable dt = db.ExecuteDataSet("sp_WebUniTag_DanhSachCheckin", param).Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    CheckinWebOBJ obj = new CheckinWebOBJ();
                    obj.ID = int.Parse(dr["ID"].ToString());
                    obj.IDHocSinh = int.Parse(dr["IDHocSinh"].ToString());
                    obj.IDPhuHuynh = int.Parse(dr["IDPhuHuynh"].ToString());
                    obj.IDImage = int.Parse(dr["IDImage"].ToString());
                    obj.IDLop = int.Parse(dr["IDLop"].ToString());
                    obj.CaDuaDon = int.Parse(dr["CaDuaDon"].ToString());
                    obj.TenCa = dr["TenCa"].ToString();
                    obj.TenPhuHuynh = dr["TenPhuHuynh"].ToString();
                    obj.TenLop = dr["Lop"].ToString();
                    obj.TenHocSinh = dr["Ten"].ToString();
                    obj.NgayCheckin = DateTime.Parse(dr["ThoiGian"].ToString()).ToString("dd/MM/yyyy");
                    obj.GioCheckin = DateTime.Parse(dr["ThoiGian"].ToString()).ToString("HH:mm:ss");
                    obj.XacNhan = (bool.Parse(dr["XacNhan"].ToString()) == true) ? "Xác nhận" : "Từ chối";
                    obj.AnhChup = Utils.Utils.BASEURL + ImagesWebDB.GetPathImage(obj.IDImage);
                    obj.AnhHocSinh = Utils.Utils.BASEURL + ImagesWebDB.GetPathImage(int.Parse(dr["IDImageHS"].ToString()));
                    obj.AnhPhuHuynh = Utils.Utils.BASEURL + ImagesWebDB.GetPathImage(int.Parse(dr["IDImagePH"].ToString()));

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
