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


    }
}