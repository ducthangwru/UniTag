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
            ThongTinGetNgayCheckin obj = new ThongTinGetNgayCheckin();
            try
            {
                obj.dsngay = NgayCheckinAppDB.DanhSachNgayCheckin();
                if (obj.dsngay.Count > 0)
                {
                    obj.status = true;
                    obj.msg = UniTagDataAccess.Utils.Utils.MSG_OK;
                    return Request.CreateResponse(HttpStatusCode.OK, obj);

                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, obj);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetDanhSachLop([FromUri]string ngay)
        {
            ThongTinGetLopCheckin obj = new ThongTinGetLopCheckin();
            try
            {
                obj.dslop = LopCheckinAppDB.DanhSachLopHocTheoNgay(ngay);
                if (obj.dslop.Count > 0)
                {
                    obj.status = true;
                    obj.msg = UniTagDataAccess.Utils.Utils.MSG_OK;
                    return Request.CreateResponse(HttpStatusCode.OK, obj);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, obj);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetDanhSachCa([FromUri]string ngay, [FromUri]int idlop)
        {
            ThongTinGetCaCheckin obj = new ThongTinGetCaCheckin();
            try
            {
                obj.dsca = CaCheckinDB.DanhSachCaTheoNgay(ngay, idlop);
                if (obj.dsca.Count > 0)
                {
                    obj.status = true;
                    obj.msg = UniTagDataAccess.Utils.Utils.MSG_OK;
                    return Request.CreateResponse(HttpStatusCode.OK, obj);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, obj);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        public HttpResponseMessage getDanhSachCheckinTheoCa([FromUri]string ngay, [FromUri] int idlop, [FromUri] int idca, [FromUri] string timkiem)
        {
            ThongTinGetHocSinhCheckin obj = new ThongTinGetHocSinhCheckin();
            try
            {
                obj.dshs = HocSinhCheckinAppDB.DanhSachCheckinCuoiCungTheoCa(ngay, idlop, idca, timkiem);
                if (obj.dshs.Count > 0)
                {
                    obj.status = true;
                    obj.msg = UniTagDataAccess.Utils.Utils.MSG_OK;
                    return Request.CreateResponse(HttpStatusCode.OK, obj);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, obj);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        public HttpResponseMessage getDanhSachCheckinTheoCa([FromUri]string ngay, [FromUri] int idlop, [FromUri] int idca, [FromUri] int idhs, [FromUri] string timkiem)
        {
            ThongTinGetHocSinhCheckin obj = new ThongTinGetHocSinhCheckin();
            try
            {
                obj.dshs = HocSinhCheckinAppDB.DanhSachHocSinhCheckinTheoCa(ngay, idlop, idca, idhs, timkiem);
                if (obj.dshs.Count > 0)
                {
                    obj.status = true;
                    obj.msg = UniTagDataAccess.Utils.Utils.MSG_OK;
                    return Request.CreateResponse(HttpStatusCode.OK, obj);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, obj);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }

    public class ThongTinGetNgayCheckin
    {
        public ThongTinGetNgayCheckin()
        {
            status = false;
            msg = UniTagDataAccess.Utils.Utils.MSG_ERROR;
            dsngay = new List<NgayCheckinAppOBJ>();
        }
        public bool status { get; set; }
        public string msg { get; set; }
        public List<NgayCheckinAppOBJ> dsngay { get; set; }
    }
    public class ThongTinGetLopCheckin
    {
        public ThongTinGetLopCheckin()
        {
            status = false;
            msg = UniTagDataAccess.Utils.Utils.MSG_ERROR;
            dslop = new List<LopCheckinAppOBJ>();
        }
        public bool status { get; set; }
        public string msg { get; set; }
        public List<LopCheckinAppOBJ> dslop { get; set; }
    }
    public class ThongTinGetCaCheckin
    {
        public ThongTinGetCaCheckin()
        {
            status = false;
            msg = UniTagDataAccess.Utils.Utils.MSG_ERROR;
            dsca = new List<CaCheckinAppOBJ>();
        }
        public bool status { get; set; }
        public string msg { get; set; }
        public List<CaCheckinAppOBJ> dsca { get; set; }
    }
    public class ThongTinGetHocSinhCheckin
    {
        public ThongTinGetHocSinhCheckin()
        {
            status = false;
            msg = UniTagDataAccess.Utils.Utils.MSG_ERROR;
            dshs = new List<HocSinhCheckinAppOBJ>();
        }
        public bool status { get; set; }
        public string msg { get; set; }
        public List<HocSinhCheckinAppOBJ> dshs { get; set; }
    }
}