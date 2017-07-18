using SERVER_ADEN.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UniTagDataAccess.Utils
{
    public class Utils
    {
        public static string BASEURL = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.PathAndQuery, "");
        public static string MSG_OK = "Thành Công!";
        public static string MSG_ERROR = "Không Thành Công!";
    }
}
