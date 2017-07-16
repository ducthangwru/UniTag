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

namespace UniTagDataAccess.DataAccess.App
{
    
    public  class HocSinhCheckinAppDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public static List<HocSinhCheckinAppOBJ> DanhSachHocSinhCheckinTheoCa(string NgaySql, int idLop, int idCa)
        {
            List<HocSinhCheckinAppOBJ> OBJ = new List<HocSinhCheckinAppOBJ>();
            try
            {
                SqlParameter[] param = new SqlParameter[]{
                    new SqlParameter("@date", NgaySql),
                    new SqlParameter("@idlop", idLop),
                    new SqlParameter("@idca", idCa)
                };
                DataTable dt = db.ExecuteDataSet("sp_AppUniTag_DanhSachHocSinhCheckinTheoCa", param).Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    HocSinhCheckinAppOBJ obj = new HocSinhCheckinAppOBJ();
                    obj.idCheck = long.Parse(dr["ID"].ToString());
                    obj.idHocSinh = int.Parse(dr["IDHocSinh"].ToString());
                    obj.NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
                    obj.Ten = dr["Ten"].ToString();
                    obj.GioiTinh = dr["GioiTinh"].ToString();
                    obj.XacNhan = Boolean.Parse((dr["XacNhan"]).ToString());
                    int idImage = int.Parse(dr["IDImage"].ToString());
                    DataRow dr1 = db.ExecuteDataSet("sp_AppUniTag_GetThongTinAnhTheoID", new SqlParameter("@idimage", idImage)).Tables[0].Rows[0];
                    obj.image = new ImageAppOBJ();
                    obj.image.ID = long.Parse(dr1["ID"].ToString());
                    obj.image.NgayTao = DateTime.Parse(dr1["NgayTao"].ToString()).ToString("dd/MM/yyyy HH:mm:ss");
                    obj.image.Path = Utils.Utils.BASEURL + dr1["Path"].ToString();
                    obj.image.ThoiGianChup = DateTime.Parse(dr1["ThoiGianChup"].ToString()).ToString("dd/MM/yyyy HH:mm:ss");
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
