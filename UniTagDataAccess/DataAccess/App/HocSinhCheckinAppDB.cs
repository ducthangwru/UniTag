using SERVER_ADEN.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTagDataAccess.Utils;
using UniTagDataAccess.Objects.App;
using System.Globalization;

namespace UniTagDataAccess.DataAccess.App
{

    public class HocSinhCheckinAppDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public static List<HocSinhCheckinAppOBJ> DanhSachCheckinCuoiCungTheoCa(string NgaySql, int idLop, int idCa, string timkiem)
        {
            List<HocSinhCheckinAppOBJ> OBJ = new List<HocSinhCheckinAppOBJ>();
            try
            {
                try
                {
                    NgaySql = DateTime.ParseExact(NgaySql, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                }
                catch { }

                SqlParameter[] param = new SqlParameter[]{
                    new SqlParameter("@date", NgaySql),
                    new SqlParameter("@idlop", idLop),
                    new SqlParameter("@idca", idCa),
                    new SqlParameter("@timkiem", timkiem)
                };
                DataTable dt = db.ExecuteDataSet("sp_AppUniTag_DanhSachHocSinhCheckinTheoCa", param).Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    HocSinhCheckinAppOBJ obj = new HocSinhCheckinAppOBJ();
                    obj.idCheck = long.Parse(dr["ID"].ToString());
                    obj.CaDuaDon = int.Parse(dr["CaDuaDon"].ToString());
                    obj.XacNhan = Boolean.Parse((dr["XacNhan"]).ToString());
                    obj.TgianXacNhan = DateTime.Parse(dr["ThoiGian"].ToString()).ToString("dd/MM/yyyy HH:mm:ss");
                    HocSinhAppOBJ HocSinh = new HocSinhAppOBJ();
                    HocSinh.ID = int.Parse(dr["IDHocSinh"].ToString());
                    DataRow dr1 = db.ExecuteDataSet("sp_AppUniTag_ThongTinHocSinhTheoID", new SqlParameter("@id", HocSinh.ID)).Tables[0].Rows[0];
                    HocSinh.IDImage = int.Parse(dr1["idImage"].ToString());
                    HocSinh.Ten = dr1["Ten"].ToString();
                    HocSinh.GioiTinh = dr1["GioiTinh"].ToString();
                    HocSinh.DiaChi = dr1["DiaChi"].ToString();
                    HocSinh.NgaySinh = DateTime.Parse(dr1["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
                    HocSinh.Lop = dr1["Lop"].ToString();
                    HocSinh.AnhHocSinh = ImagesAppDB.GetThongTinAnhTheoID(HocSinh.IDImage);
                    HocSinh.NgayTao = DateTime.Parse(dr1["NgayTao"].ToString()).ToString("dd/MM/yyyy HH:mm:ss");

                    obj.PhuHuynh.ID = int.Parse(dr["IDPhuHuynh"].ToString());
                    DataRow dr2 = db.ExecuteDataSet("sp_AppUniTag_GetThongTinPHTheoID", new SqlParameter("@id", obj.PhuHuynh.ID)).Tables[0].Rows[0];
                    obj.PhuHuynh.IDThe = dr2["IDThe"].ToString();
                    obj.PhuHuynh.IDImage = int.Parse(dr2["IDImage"].ToString());
                    obj.PhuHuynh.TenPhuHuynh = dr2["TenPhuHuynh"].ToString();
                    obj.PhuHuynh.DiaChi = dr2["DiaChi"].ToString();
                    obj.PhuHuynh.NgaySinh = DateTime.Parse(dr2["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
                    DataRow dr3 = db.ExecuteDataSet("sp_AppUniTag_getMQH", new SqlParameter("@idph", obj.PhuHuynh.ID), new SqlParameter("@idhs", HocSinh.ID)).Tables[0].Rows[0];
                    obj.PhuHuynh.IDMoiQuanHe = int.Parse(dr3["id"].ToString());
                    obj.PhuHuynh.MoiQuanHe = dr3["TenMoiQuanHe"].ToString();
                    obj.PhuHuynh.GioiTinh = dr2["GioiTinh"].ToString();
                    obj.PhuHuynh.isActive = bool.Parse(dr2["isActive"].ToString());
                    obj.PhuHuynh.HocSinh = HocSinh;
                    obj.PhuHuynh.Image = ImagesAppDB.GetThongTinAnhTheoID(obj.PhuHuynh.IDImage);
                    obj.PhuHuynh.NgayTao = DateTime.Parse(dr2["NgayTao"].ToString()).ToString("dd/MM/yyyy HH:mm:ss");

                    obj.imageCheckin.ID = long.Parse(dr["IDImage"].ToString());
                    obj.imageCheckin = ImagesAppDB.GetThongTinAnhTheoID(obj.imageCheckin.ID);
                    OBJ.Add(obj);
                }
                return OBJ;
            }
            catch (Exception ex)
            {
                return OBJ;
            }
        }

        public static List<HocSinhCheckinAppOBJ> DanhSachHocSinhCheckinTheoCa(string NgaySql, int idLop, int idCa, int idHS, string timkiem)
        {
            List<HocSinhCheckinAppOBJ> OBJ = new List<HocSinhCheckinAppOBJ>();
            try
            {
                try
                {
                    NgaySql = DateTime.ParseExact(NgaySql, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                }
                catch { }

                SqlParameter[] param = new SqlParameter[]{
                    new SqlParameter("@date", NgaySql),
                    new SqlParameter("@idlop", idLop),
                    new SqlParameter("@idca", idCa),
                    new SqlParameter("@idhs", idHS),
                    new SqlParameter("@timkiem", timkiem)
                };
                DataTable dt = db.ExecuteDataSet("sp_AppUniTag_DanhSachCheckinCuaHocSinh", param).Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    HocSinhCheckinAppOBJ obj = new HocSinhCheckinAppOBJ();
                    obj.idCheck = long.Parse(dr["ID"].ToString());
                    obj.CaDuaDon = int.Parse(dr["CaDuaDon"].ToString());
                    obj.XacNhan = Boolean.Parse((dr["XacNhan"]).ToString());
                    obj.TgianXacNhan = DateTime.Parse(dr["ThoiGian"].ToString()).ToString("dd/MM/yyyy HH:mm:ss");
                    HocSinhAppOBJ HocSinh = new HocSinhAppOBJ();
                    HocSinh.ID = int.Parse(dr["IDHocSinh"].ToString());
                    DataRow dr1 = db.ExecuteDataSet("sp_AppUniTag_ThongTinHocSinhTheoID", new SqlParameter("@id", HocSinh.ID)).Tables[0].Rows[0];
                    HocSinh.IDImage = int.Parse(dr1["idImage"].ToString());
                    HocSinh.Ten = dr1["Ten"].ToString();
                    HocSinh.GioiTinh = dr1["GioiTinh"].ToString();
                    HocSinh.DiaChi = dr1["DiaChi"].ToString();
                    HocSinh.NgaySinh = DateTime.Parse(dr1["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
                    HocSinh.Lop = dr1["Lop"].ToString();
                    HocSinh.AnhHocSinh = ImagesAppDB.GetThongTinAnhTheoID(HocSinh.IDImage);
                    HocSinh.NgayTao = DateTime.Parse(dr1["NgayTao"].ToString()).ToString("dd/MM/yyyy HH:mm:ss");

                    obj.PhuHuynh.ID = int.Parse(dr["IDPhuHuynh"].ToString());
                    DataRow dr2 = db.ExecuteDataSet("sp_AppUniTag_GetThongTinPHTheoID", new SqlParameter("@id", obj.PhuHuynh.ID)).Tables[0].Rows[0];
                    obj.PhuHuynh.IDThe = dr2["IDThe"].ToString();
                    obj.PhuHuynh.IDImage = int.Parse(dr2["IDImage"].ToString());
                    obj.PhuHuynh.TenPhuHuynh = dr2["TenPhuHuynh"].ToString();
                    obj.PhuHuynh.DiaChi = dr2["DiaChi"].ToString();
                    obj.PhuHuynh.NgaySinh = DateTime.Parse(dr2["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
                    DataRow dr3 = db.ExecuteDataSet("sp_AppUniTag_getMQH", new SqlParameter("@idph", obj.PhuHuynh.ID), new SqlParameter("@idhs", HocSinh.ID)).Tables[0].Rows[0];
                    obj.PhuHuynh.IDMoiQuanHe = int.Parse(dr3["id"].ToString());
                    obj.PhuHuynh.MoiQuanHe = dr3["TenMoiQuanHe"].ToString();
                    obj.PhuHuynh.GioiTinh = dr2["GioiTinh"].ToString();
                    obj.PhuHuynh.isActive = bool.Parse(dr2["isActive"].ToString());
                    obj.PhuHuynh.HocSinh = HocSinh;
                    obj.PhuHuynh.Image = ImagesAppDB.GetThongTinAnhTheoID(obj.PhuHuynh.IDImage);
                    obj.PhuHuynh.NgayTao = DateTime.Parse(dr2["NgayTao"].ToString()).ToString("dd/MM/yyyy HH:mm:ss");

                    obj.imageCheckin.ID = long.Parse(dr["IDImage"].ToString());
                    obj.imageCheckin = ImagesAppDB.GetThongTinAnhTheoID(obj.imageCheckin.ID);
                    OBJ.Add(obj);
                }
                return OBJ;
            }
            catch (Exception ex)
            {
                return OBJ;
            }
        }
    }
}
