using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniTagDataAccess.DataAccess.Web;
using UniTagDataAccess.Objects.Web;
using UniTagWEB.Common;

namespace UniTagWEB.Controllers
{
    public class ReportCheckinController : BaseController
    {
        // GET: ReportCheckin
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult DanhSachCheckin()
        {
            IEnumerable<CheckinWebOBJ> model = new List<CheckinWebOBJ>();
            model = CheckinWebDB.DanhSachCheckin();
            return this.Jsonp(model);
        }

        public ActionResult DanhSachCheckinLoc(string Ngay, string IDLop, string IDCa)
        {
            IEnumerable<CheckinWebOBJ> model = new List<CheckinWebOBJ>();
            model = CheckinWebDB.DanhSachCheckin(Ngay, IDLop, IDCa);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DanhSachLop()
        {
            IEnumerable<ClassWebOBJ> model = new List<ClassWebOBJ>();
            model = ClassWebDB.DanhSachLopHoc();
            return this.Jsonp(model);
        }


        public JsonResult DanhSachCa()
        {
            IEnumerable<CaDuaDonWebOBJ> model = new List<CaDuaDonWebOBJ>();
            model = CaDuaDonDB.DanhSachCa();
            return this.Jsonp(model);
        }

    }
}