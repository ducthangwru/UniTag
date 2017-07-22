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
            //if (FormsAuthentication.IsEnabled)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            return View();
        }

        public ActionResult CheckLogin(string username, string password)
        {
            bool login = Membership.ValidateUser(username, password);
            if (login)
            {
                FormsAuthentication.SetAuthCookie(username, true);
            }
            return Json(login, JsonRequestBehavior.AllowGet);
        }
    }
}