using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UniTagDataAccess.DataAccess.App;
using UniTagDataAccess.Objects.App;

namespace UniTagWEB.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        public class param
        {
            public string username;
            public string password;
        }
        [HttpPost]
        public HttpResponseMessage getThongTinTaiKhoan([FromBody] param p)
        {
            ResponseGetTaiKhoan obj = new ResponseGetTaiKhoan();
            try
            {
                obj.thongtin = TaiKhoanAppDB.ThongTinTaiKhoan(p.username, p.password);
                if (string.IsNullOrEmpty(obj.thongtin.username))
                {
                    obj.thongtin = new TaiKhoanAppOBJ();
                    return Request.CreateResponse(HttpStatusCode.BadRequest, obj);
                }
                obj.status = true;
                obj.msg = UniTagDataAccess.Utils.Utils.MSG_OK;
                return Request.CreateResponse(HttpStatusCode.OK, obj);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public class ResponseGetTaiKhoan
        {
            public ResponseGetTaiKhoan()
            {
                thongtin = new TaiKhoanAppOBJ();
                status = false;
                msg = UniTagDataAccess.Utils.Utils.MSG_ERROR;
            }
            public bool status { get; set; }
            public string msg { set; get; }
            public TaiKhoanAppOBJ thongtin { get; set; }
        }
    }
}
