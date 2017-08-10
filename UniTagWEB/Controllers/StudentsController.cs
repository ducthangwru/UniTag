using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniTagDataAccess.DataAccess.Web;
using UniTagDataAccess.Models;
using UniTagDataAccess.Objects.Web;
using UniTagWEB.Common;

namespace UniTagWEB.Controllers
{
    public class StudentsController : BaseController
    {
        public static int idAnh { get; set; }
        // GET: Students
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult DanhSachHS()
        {
            IEnumerable<HocSinhWebOBJ> model = new List<HocSinhWebOBJ>();
            model = HocSinhWebDB.DanhSachHocSinh();
            return this.Jsonp(model);
        }

        public ActionResult DanhSachHocSinhLoc(string Ten, string IDLop)
        {
            IEnumerable<HocSinhWebOBJ> model = new List<HocSinhWebOBJ>();
            model = HocSinhWebDB.DanhSachHocSinh(Ten, IDLop);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonpResult Insert()
        {
            var model = this.DeserializeObject<List<HocSinhModel>>("models");
            int r = 0;
            if (idAnh > 0)
            {
                r = HocSinhWebDB.Insert(model.First(), idAnh);
            }
            
            return this.Jsonp(r);
        }

        public JsonpResult Update()
        {
            var model = this.DeserializeObject<List<HocSinhWebOBJ>>("model");
            bool r = HocSinhWebDB.Update(model.First());
            return this.Jsonp(r);
        }

        public JsonResult Delete()
        {
            var model = this.DeserializeObject<HocSinhWebOBJ>("models");
            bool r = HocSinhWebDB.DeleteHocSinh(model.ID);
            return this.Jsonp(r);
        }

        public JsonResult DanhSachLop()
        {
            IEnumerable<ClassWebOBJ> model = new List<ClassWebOBJ>();
            model = ClassWebDB.DanhSachLopHoc();
            return this.Jsonp(model);
        }
        public JsonResult UpdateHocSinh(string base64, int idHS)
        {
            UniTagWEB.Common.Utils.Respon res = Common.Utils.ImageFromBase64(base64);
            if (res == null) return this.Json(0, JsonRequestBehavior.AllowGet);
            string date = DateTime.Now.ToString("ddMMyyyyHHmmss");
            string path = Path.Combine(Server.MapPath("~/Images/ImagesHocSinh/"), date + res.extension);
            res.image.Save(path);
            bool r = HocSinhWebDB.UpdateAnhHocSinh("/Images/ImagesHocSinh/" + date + res.extension, idHS);
            return this.Json(r, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ThemAnhHocSinh(string base64)
        {
            UniTagWEB.Common.Utils.Respon res = Common.Utils.ImageFromBase64(base64);
            if (res == null) return this.Json(0, JsonRequestBehavior.AllowGet);
            string date = DateTime.Now.ToString("ddMMyyyyHHmmss");
            string path = Path.Combine(Server.MapPath("~/Images/ImagesHocSinh/"), date + res.extension);
            res.image.Save(path);
            idAnh = HocSinhWebDB.ThemAnhHocSinh("/Images/ImagesHocSinh/" + date + res.extension);
            return this.Json(idAnh, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Import(HttpPostedFileBase myFile)
        {
            if (myFile != null)
            {
                var filePath = Path.Combine(Server.MapPath("~/" + myFile.FileName));
                myFile.SaveAs(filePath);
                string[] exts = myFile.FileName.Split('.');
                string ext = exts.Last();
                if (ext == "xlsx" || ext == "xls")
                {
                    ImportExcel.ImportExcelToDatabase(filePath, UniTagDataAccess.Utils.ImportExcelType.HOCSINH);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
            }
            return View();
        }
    }
}