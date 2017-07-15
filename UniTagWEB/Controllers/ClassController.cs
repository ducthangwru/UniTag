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
            List<LopHocAppOBJ> dslop = LopHocAppDB.DanhSachLopHoc();
            if(dslop.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, dslop);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, dslop);
        }
    }
}
