﻿using SERVER_ADEN.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    obj.idImage = int.Parse(dr["IDImage"].ToString());
                    obj.NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
                    obj.Ten = dr["Ten"].ToString();
                    obj.GioiTinh = dr["GioiTinh"].ToString();
                    obj.XacNhan = Boolean.Parse((dr["XacNhan"]).ToString());
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