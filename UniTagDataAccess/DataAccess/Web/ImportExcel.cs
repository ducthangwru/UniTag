using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using SERVER_ADEN.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UniTagDataAccess.DataAccess.Web
{
    public class ImportExcel
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public ImportExcel() { }
        public static DataTable ExcelToDataTable(HttpPostedFileBase upload)
        {
            DataTable dt = new DataTable();
            Stream stream = upload.InputStream;
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(stream);
            ISheet sheet = hssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;

            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                dt.Columns.Add(cell.ToString());
            }

            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = dt.NewRow();
                if (row == null)
                {
                    break;
                }
                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }

                dt.Rows.Add(dataRow);
            }
            return dt;
        }

        public static bool ImportExcelPhuHuynh(HttpPostedFileBase upload)
        {
            try
            {
                DataTable dt = ExcelToDataTable(upload);
                foreach (DataRow dr in dt.Rows)
                {
                    int idmqh = 0;
                    try
                    {
                        idmqh = int.Parse(db.ExecuteScalar(string.Format("select id from MoiQuanHe where TenMoiQuanHe like '%{0}%'", dr["TenMoiQuanHe"].ToString())).ToString());
                    }
                    catch
                    {
                        idmqh = 0;
                    }
                    SqlParameter[] param = new SqlParameter[]
                    {
                    new SqlParameter("@IDPhuHuynh", 0),
                    new SqlParameter("@IDThe", dr["IDThe"].ToString()),
                    new SqlParameter("@TenPhuHuynh", dr["TenPhuHuynh"].ToString()),
                    new SqlParameter("@DiaChi", dr["DiaChi"].ToString()),
                    new SqlParameter("@NgaySinh", dr["NgaySinh"].ToString()),
                    new SqlParameter("@IDMoiQuanHe", idmqh),
                    new SqlParameter("@GioiTinh", dr["GioiTinh"].ToString())
                    };

                    db.ExecuteNonQuery("sp_WebUniTag_InsertOrUpdatePhuHuynh", param);
                }

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
           
        }

        public static bool ImportExcelHocSinh(HttpPostedFileBase upload)
        {
            try
            {
                DataTable dt = ExcelToDataTable(upload);
                foreach (DataRow dr in dt.Rows)
                {
                    int idmqh = 0;
                    try
                    {
                        idmqh = int.Parse(db.ExecuteScalar(string.Format("select id from MoiQuanHe where TenMoiQuanHe like '%{0}%'", dr["TenMoiQuanHe"].ToString())).ToString());
                    }
                    catch
                    {
                        idmqh = 0;
                    }
                    SqlParameter[] param = new SqlParameter[]
                    {
                    new SqlParameter("@IDPhuHuynh", 0),
                    new SqlParameter("@IDThe", dr["IDThe"].ToString()),
                    new SqlParameter("@TenPhuHuynh", dr["TenPhuHuynh"].ToString()),
                    new SqlParameter("@DiaChi", dr["DiaChi"].ToString()),
                    new SqlParameter("@NgaySinh", dr["NgaySinh"].ToString()),
                    new SqlParameter("@IDMoiQuanHe", idmqh),
                    new SqlParameter("@GioiTinh", dr["GioiTinh"].ToString())
                    };

                    db.ExecuteNonQuery("sp_WebUniTag_InsertOrUpdatePhuHuynh", param);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
