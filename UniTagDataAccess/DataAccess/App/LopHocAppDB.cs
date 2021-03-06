﻿using SERVER_ADEN.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using UniTagDataAccess.Objects.App;
using System.Data;

namespace UniTagDataAccess.DataAccess.App
{
    public class LopHocAppDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public LopHocAppDB() { }

        public static string ThongTinSiSoTheoLopTrongNgay(int IDLop, string ThoiGianCheckin)
        {
            int siso = int.Parse(db.ExecuteScalar("sp_AppUniTag_SiSoTrongLopCuaHocSinh", new SqlParameter("@idlop", IDLop)).ToString());
            
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@idlop", IDLop),
                new SqlParameter("@date", ThoiGianCheckin)
            };

            int sisohientai = int.Parse(db.ExecuteScalar("sp_AppUniTag_SiSoHienTaiCuaLop", param).ToString());

            return sisohientai + "/" + siso;
        }

        public static List<LopHocAppOBJ> DanhSachLopHoc()
        {
            List<LopHocAppOBJ> ds = new List<LopHocAppOBJ>();

            try
            {
                DataTable dt = db.ExecuteDataSet("sp_AppUniTag_DanhSachLopHoc").Tables[0];
                foreach(DataRow dr in dt.Rows)
                {
                    LopHocAppOBJ obj = new LopHocAppOBJ();
                    obj.ID = int.Parse(dr["ID"].ToString());
                    obj.Lop = dr["Lop"].ToString();
                    obj.SiSo = int.Parse(dr["SiSo"].ToString());
                    obj.MaMau = dr["MaMau"].ToString();
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
