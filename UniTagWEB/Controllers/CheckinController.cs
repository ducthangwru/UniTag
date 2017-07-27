using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using UniTagDataAccess.DataAccess.App;
using UniTagDataAccess.Objects.App;

namespace UniTagWEB.Controllers
{
    [RoutePrefix("api/Checkin")]
    public class CheckinController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetThongTinThe(string id, int idLop, int idCa)
        {
            ThongTinGetTheCheckin obj = new ThongTinGetTheCheckin();
            try
            {
                obj.chitiet = PhuHuynhAppDB.GetThongTinPhuHuynhTheoIDThe(id, idLop, idCa);
                if (string.IsNullOrEmpty(obj.chitiet.IDThe))
                {
                    obj.chitiet = new PhuHuynhAppOBJ();
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

        [HttpPost]
        public HttpResponseMessage CheckinPhuHuynh([FromUri] int IDPhuHuynh, [FromUri] int IDHocSinh, [FromUri] int CaDuaDon,
            [FromUri] int Lop, [FromUri] string ThoiGianChup, [FromUri] bool XacNhan)
        {
            int idimage = 0;
            try
            {
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
                    {
                        var file = HttpContext.Current.Request.Files[i];

                        if (file != null && file.ContentLength > 0)
                        {

                            int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB  

                            IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                            var ext = file.FileName.Substring(file.FileName.LastIndexOf('.'));
                            var extension = ext.ToLower();
                            if (!AllowedFileExtensions.Contains(extension))
                            {
                                return Request.CreateResponse(HttpStatusCode.BadRequest, "Yêu cầu tải ảnh dạng .jpg,.gif,.png.");
                            }
                            else if (file.ContentLength > MaxContentLength)
                            {

                                return Request.CreateResponse(HttpStatusCode.BadRequest, "Yêu cầu tải ảnh tối đa 1 Mb.");
                            }
                            else
                            {
                                string date = DateTime.Now.ToString("ddMMyyyyHHmmss");
                                string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/ImagesCheckin/"), date + ext);
                                file.SaveAs(path);
                                idimage = ImagesAppDB.InsertImage("/Images/ImagesCheckin/" + date + ext, ThoiGianChup);
                            }
                        }
                    }
                }

                ThongTinCheckinOBJ OBJ = new ThongTinCheckinOBJ();
                OBJ.siso = LopHocAppDB.ThongTinSiSoTheoCaDuaDon(CaDuaDon, IDHocSinh, Lop, DateTime.Now.ToString("yyyy-MM-dd"));

                if (idimage > 0 && CheckinAppDB.InsertCheckin(IDPhuHuynh, IDHocSinh, Lop, idimage, CaDuaDon, XacNhan))
                {
                    OBJ.status = true;
                    OBJ.siso = LopHocAppDB.ThongTinSiSoTheoCaDuaDon(CaDuaDon, IDHocSinh, Lop, DateTime.Now.ToString("yyyy-MM-dd"));
                    OBJ.msg = UniTagDataAccess.Utils.Utils.MSG_OK;
                    return Request.CreateResponse(HttpStatusCode.OK, OBJ);
                }

                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, OBJ);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public class ThongTinCheckinOBJ
        {
            public ThongTinCheckinOBJ()
            {
                status = false;
                msg = UniTagDataAccess.Utils.Utils.MSG_ERROR;
            }
            public string siso { get; set; }
            public bool status { get; set; }
            public string msg { get; set; }
        }
        public class ThongTinGetTheCheckin
        {
            public ThongTinGetTheCheckin()
            {
                status = false;
                msg = UniTagDataAccess.Utils.Utils.MSG_ERROR;
                chitiet = new PhuHuynhAppOBJ();
            }
            public bool status { get; set; }
            public string msg { get; set; }
            public PhuHuynhAppOBJ chitiet { get; set; }
        }
    }
}
