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
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult DanhSachLop()
        {
            IEnumerable<ClassWebOBJ> model = new List<ClassWebOBJ>();
            model = ClassWebDB.DanhSachLopHoc();
            return this.Jsonp(model);
        }
    }
}