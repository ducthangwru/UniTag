using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniTagDataAccess.DataAccess.Web;
using UniTagDataAccess.Models;
using UniTagDataAccess.Objects.Web;
using UniTagWEB.Common;

namespace UniTagWEB.Controllers
{
    public class ParentsController : Controller
    {
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

        public JsonResult Insert()
        {
            var model = this.DeserializeObject<List<PhuHuynhWebOBJ>>("models");
            bool r = PhuHuynhWebDB.Insert(model.FirstOrDefault());
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

        public JsonResult ActiveThe()
        {
            var model = this.DeserializeObject<PhuHuynhWebOBJ>("models");
            bool r = true; //Chưa làm :( 
            return this.Jsonp(r);
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

        public JsonResult DanhSachHocSinh()
        {
            IEnumerable<HocSinhWebModel> model = new List<HocSinhWebModel>();
            model = HocSinhWebDB.DanhSachHS();
            return this.Jsonp(model);
        }

        public JsonpResult GanHocSinh(string ID_PhuHuynh, string ID_HocSinh)
        {
            bool r = PhuHuynhWebDB.GanHocSinh(ID_PhuHuynh, ID_PhuHuynh);
            return this.Jsonp(r);
        }
    }
}