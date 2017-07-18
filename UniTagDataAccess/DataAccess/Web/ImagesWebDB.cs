using SERVER_ADEN.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniTagDataAccess.DataAccess.Web
{
    public class ImagesWebDB
    {
        public static SqlDataHelpers db = new SqlDataHelpers();
        public ImagesWebDB() {}
        public static string GetPathImage(int idimage)
        {
            if(idimage != 0)
                return db.ExecuteScalar("select Path from Images where ID = " + idimage).ToString();
            return "/Images/noimg.png";
        }
    }
}
