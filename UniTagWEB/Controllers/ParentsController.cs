using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
    public class ParentsController : BaseController
    {
        public static int idAnh { get; set; }
        // GET: Parents
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult DanhSachPH()
        {
            IEnumerable<PhuHuynhWebOBJ> model = new List<PhuHuynhWebOBJ>();
            model = PhuHuynhWebDB.DanhSachPhuHuynh();
            return this.Jsonp(model);
        }

        public JsonResult DanhSachPHLoc(string Ten, string MaThe)
        {
            IEnumerable<PhuHuynhWebOBJ> model = new List<PhuHuynhWebOBJ>();
            model = PhuHuynhWebDB.DanhSachPhuHuynh(Ten, MaThe);
            return this.Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Insert()
        {
            var model = this.DeserializeObject<List<PhuHuynhWebOBJ>>("models");
            bool r = false;
            if (idAnh > 0)
                r = PhuHuynhWebDB.Insert(model.FirstOrDefault(), idAnh);
            return this.Jsonp(r);
        }

        public JsonResult Update()
        {
            var model = this.DeserializeObject<List<PhuHuynhWebOBJ>>("models");
            bool r = PhuHuynhWebDB.Update(model.First());
            return this.Jsonp(r);
        }


        public JsonResult DeletePhuHuynh()
        {
            var model = this.DeserializeObject<PhuHuynhWebOBJ>("models");
            bool r = PhuHuynhWebDB.DeletePhuHuynh(model.ID);
            return this.Jsonp(r);
        }

        public JsonResult UpdateImagePH()
        {
            var model = this.DeserializeObject<PhuHuynhWebOBJ>("models");
            bool r = PhuHuynhWebDB.UpdateImagePhuHuynh(model.ID, model.IDImage);
            return this.Jsonp(r);
        }

        public JsonResult ActiveThe(string IDThe)
        {
            bool r = PhuHuynhWebDB.ActiveThePhuHuynh(IDThe);
            return this.Json(r, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DanhSachMoiQH()
        {
            IEnumerable<MoiQuanHeWebOBJ> model = new List<MoiQuanHeWebOBJ>();
            model = MoiQuanHeWebDB.DanhSachMoiQuanHe();
            return this.Jsonp(model);
        }

        public JsonResult DanhSachLop()
        {
            IEnumerable<ClassWebOBJ> model = new List<ClassWebOBJ>();
            model = ClassWebDB.DanhSachLopHoc();
            return this.Jsonp(model);
        }

        public JsonResult DanhSachHocSinh(int idlop)
        {
            IEnumerable<HocSinhWebModel> model = new List<HocSinhWebModel>();
            model = HocSinhWebDB.DanhSachHSTheoLop(idlop);
            return this.Json(model);
        }

        public JsonResult GanHocSinh(string ID_PhuHuynh, string ID_HocSinh)
        {
            bool r = PhuHuynhWebDB.GanHocSinh(ID_PhuHuynh, ID_PhuHuynh);
            return this.Json(r, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdatePhuHuynh(string base64, int idPH)
        {
            UniTagWEB.Common.Utils.Respon res = Common.Utils.ImageFromBase64(base64);
            if (res == null) return this.Json(0, JsonRequestBehavior.AllowGet);
            string date = DateTime.Now.ToString("ddMMyyyyHHmmss");
            string path = Path.Combine(Server.MapPath("~/Images/ImagesPhuHuynh/"), date + res.extension);
            res.image.Save(path);
            bool r = PhuHuynhWebDB.UpdateAnhPhuHuynh("/Images/ImagesPhuHuynh/" + date + res.extension, idPH);
            return this.Json(r, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ThemAnhPhuHuynh(string base64)
        {
            UniTagWEB.Common.Utils.Respon res = Common.Utils.ImageFromBase64(base64);
            if (res == null) return this.Json(0, JsonRequestBehavior.AllowGet);
            string date = DateTime.Now.ToString("ddMMyyyyHHmmss");
            string path = Path.Combine(Server.MapPath("~/Images/ImagesPhuHuynh/"), date + res.extension);
            res.image.Save(path);
            idAnh = HocSinhWebDB.ThemAnhHocSinh("/Images/ImagesPhuHuynh/" + date + res.extension);
            return this.Json(idAnh, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Import(HttpPostedFileBase myFile)
        {
            if (myFile != null)
            {
                string[] exts = myFile.FileName.Split('.');
                string ext = exts.Last();
                if (ext == "xlsx" || ext == "xls")
                {
                    var filePath = Path.Combine(Server.MapPath("~/" + myFile.FileName));
                    myFile.SaveAs(filePath);
                    ImportExcel.ImportExcelToDatabase(filePath, UniTagDataAccess.Utils.ImportExcelType.PHUHUYNH);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}