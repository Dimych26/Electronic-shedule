using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseWork.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        //public ActionResult GetUser()
        //{
        //    return View();
        //}

        public ActionResult Login()
        {
            return View();
        }
    }
}
