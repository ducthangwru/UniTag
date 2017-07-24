using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniTagWEB.Controllers
{
    public class AttendanceController : BaseController
    {
        // GET: Attendance
        public ActionResult Index()
        {
            return View();
        }
    }
}