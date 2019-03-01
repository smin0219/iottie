using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iottie.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult AddNewProject()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}