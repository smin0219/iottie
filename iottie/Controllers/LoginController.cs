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

        public ActionResult Contact()
        {
            return View();
        } 

        [HttpGet]
        public JsonResult isValidUser(string username, string password)
        {
            return Json(new { result = this.authenticationRepo.isValidUser(username, password) }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult isValidUsername(string username)
        {
            return Json(new { result = this.authenticationRepo.isValidUsername(username) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void SignUp(string firstName, string lastName, string username, string password, int isDev)
        {
            authenticationRepo.createUser(firstName, lastName, username, password, isDev);
        }
    }
}