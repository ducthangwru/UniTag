using Excel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using SERVER_ADEN.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UniTagDataAccess.Utils;

namespace UniTagDataAccess.DataAccess.Web
{
    public class ImportExcel
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public ImportExcel() { }
        public static void ImportExcelToDatabase(string path, ImportExcelType type)
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            DataSet result = excelReader.AsDataSet();
            switch (type)
            {
                case ImportExcelType.PHUHUYNH: { importPH(result); break; }
                case ImportExcelType.HOCSINH: { importHS(result); break; }
            }
        }
        public static void importPH(DataSet result)
        {
            foreach (DataTable dt in result.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string[] format = new string[]{
                                          "dd-MM-yyyy",
                                          "dd/MM/yyyy",
                                      };
                    PhuHuynh ph = new PhuHuynh
                    {
                        IDThe = dr[0].ToString(),
                        Ten = dr[1].ToString(),
                        DiaChi = dr[2].ToString(),
                        NgaySinh = DateTime.ParseExact(dr[3].ToString(), format, null, System.Globalization.DateTimeStyles.None).ToString("yyyy-MM-dd"),
                        GioiTinh = dr[4].ToString()
                    };
                    SqlParameter[] param = new SqlParameter[]{
                        new SqlParameter("@IDThe", ph.IDThe),
                        new SqlParameter("@TenPhuHuynh", ph.Ten),
                        new SqlParameter("@DiaChi", ph.DiaChi),
                        new SqlParameter("@NgaySinh", ph.NgaySinh),
                        new SqlParameter("@GioiTinh", ph.GioiTinh)
                    };
                    db.ExecuteNonQuery("sp_WebUniTag_ThemPHTuExcel", param);
                }
            }
        }
        public static void importHS(DataSet result)
        {
            foreach (DataTable dt in result.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string[] format = new string[]{
                                          "dd-MM-yyyy",
                                          "dd/MM/yyyy",
                                      };
                    HocSinh hs = new HocSinh
                    {
                        IDLop = int.Parse(dr[0].ToString()),
                        Ten = dr[1].ToString(),
                        DiaChi = dr[2].ToString(),
                        NgaySinh = DateTime.ParseExact(dr[3].ToString(), format, null, System.Globalization.DateTimeStyles.None).ToString("yyyy-MM-dd"),
                        GioiTinh = dr[4].ToString()
                    };
                    SqlParameter[] param = new SqlParameter[]{
                        new SqlParameter("@IDLop", hs.IDLop),
                        new SqlParameter("@TenHocSinh", hs.Ten),
                        new SqlParameter("@DiaChi", hs.DiaChi),
                        new SqlParameter("@NgaySinh", hs.NgaySinh),
                        new SqlParameter("@GioiTinh", hs.GioiTinh)
                    };
                    db.ExecuteNonQuery("sp_WebUniTag_ThemHSTuExcel", param);
                }
            }
        }
    }
    class PhuHuynh
    {
        public string IDThe { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
    }
    class HocSinh
    {
        public int IDLop { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
    }
}
