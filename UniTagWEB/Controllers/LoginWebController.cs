using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UniTagDataAccess.DataAccess.App;

namespace UniTagWEB.Controllers
{
    [AllowAnonymous]
    public class LoginWebController : Controller
    {
        // GET: LoginWeb
        public ActionResult Index()
        {
            var session = Session[UniTagDataAccess.Utils.Utils.USER_SESSION];
            if (session == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult CheckLogin(string username, string password)
        {
            bool login = TaiKhoanAppDB.ThongTinTaiKhoan(username, password).id > 0;
            if (login)
            {
                Session.Add(UniTagDataAccess.Utils.Utils.USER_SESSION, username);
            }
            return Json(login, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SignOut()
        {
            Session[UniTagDataAccess.Utils.Utils.USER_SESSION] = null;
            return RedirectToAction("Index");
        }
    }
}