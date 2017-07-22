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
    public class ReportCheckinController : Controller
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

    }
}