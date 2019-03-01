using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Concrete;

namespace iottie.Controllers
{
    public class LoginController : Controller
    {

        private IAuthentication authenticationRepo = new Authentication();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult isValidUser(string userId, string password)
        {
            return Json(new { result = this.authenticationRepo.isValidUser(userId, password) }, JsonRequestBehavior.AllowGet);
        }
    }
}