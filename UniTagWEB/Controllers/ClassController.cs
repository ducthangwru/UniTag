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
    [RoutePrefix("api/class")]
    public class ClassController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage DanhSachLopHoc()
        {
            OBJ obj = new OBJ();
            obj.dslop = LopHocAppDB.DanhSachLopHoc();
            if (obj.dslop.Count > 0)
            {
                obj.status = true;
                obj.msg = UniTagDataAccess.Utils.Utils.MSG_OK;
                return Request.CreateResponse(HttpStatusCode.OK, obj);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, obj);
        }
    }
    public class OBJ
    {
        public OBJ()
        {
            status = false;
            msg = UniTagDataAccess.Utils.Utils.MSG_ERROR;
            dslop = new List<LopHocAppOBJ>();
        }
        public bool status { get; set; }
        public string msg { get; set; }
        public List<LopHocAppOBJ> dslop { get; set; }
    }
}