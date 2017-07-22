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
    [Authorize]
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            return View();
        }
        
        public JsonResult DanhSachHS()
        {
            //model hoc sinh la gi
            IEnumerable<HocSinhWebOBJ> model = new List<HocSinhWebOBJ>();
            model = HocSinhWebDB.DanhSachHocSinh();
            return this.Jsonp(model);
        }

        public JsonResult InsertOrUpdateHocSinh()
        {
            var model = this.DeserializeObject<HocSinhWebOBJ>("models");
            bool r = HocSinhWebDB.InsertOrUpdateHocSinh(model);
            return this.Jsonp(r);
        }
    }
}