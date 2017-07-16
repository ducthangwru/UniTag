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
    [RoutePrefix("api/report")]
    public class ReportController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetDanhSachNgay()
        {
            try
            {
                List<NgayCheckinAppOBJ> list = NgayCheckinAppDB.DanhSachNgayCheckin();
                return Request.CreateResponse(HttpStatusCode.OK, list);
       
            }
            catch (Exception ex){
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetDanhSachLop([FromUri]string ngay)
        {
            try
            {
                List<LopCheckinAppOBJ> OBJ = LopCheckinAppDB.DanhSachLopHocTheoNgay(ngay);
                return Request.CreateResponse(HttpStatusCode.OK, OBJ);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetDanhSachCa([FromUri]string ngay, [FromUri]int idlop)
        {
            try
            {
                List<CaCheckinAppOBJ> list = CaCheckinDB.DanhSachCaTheoNgay(ngay, idlop);
                return Request.CreateResponse(HttpStatusCode.OK, list);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        public HttpResponseMessage getDanhSachCheckinTheoCa([FromUri]string ngay, [FromUri] int idlop, [FromUri] int idca)
        {
            try
            {
                List<HocSinhCheckinAppOBJ> OBJ = HocSinhCheckinAppDB.DanhSachHocSinhCheckinTheoCa(ngay, idlop, idca);
                return Request.CreateResponse(HttpStatusCode.OK, OBJ);
            }
            catch (Exception ex){
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
	}
}