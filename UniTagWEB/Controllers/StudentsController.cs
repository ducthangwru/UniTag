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
    public class StudentsController : BaseController
    {
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

        public JsonResult Insert()
        { 
            var model = this.DeserializeObject<List<HocSinhModel>>("models");
            bool r = HocSinhWebDB.Insert(model.FirstOrDefault());
            return this.Jsonp(r);
        }

        public JsonpResult Update()
        {
            var model = this.DeserializeObject<List<HocSinhWebOBJ>>("models");
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
    }
}