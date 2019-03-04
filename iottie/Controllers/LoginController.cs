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

        /**
         * Show login page
         * */
        public ActionResult Index()
        {
            return View();
        }

        /**
         * General contact information
         * */

        public ActionResult Contact()
        {
            return View();
        } 

        /**
         * Check credentials of user before logging in
         * and return to ajax in Index.cshtml.
         * */

        [HttpGet]
        public JsonResult isValidUser(string username, string password)
        {
            return Json(new { result = this.authenticationRepo.isValidUser(username, password) }, JsonRequestBehavior.AllowGet);
        }

        /**
         * Check if there is a duplcation username in DB.
         * and return to ajax in Index.cshtml
         * */
        [HttpGet]
        public JsonResult isValidUsername(string username)
        {
            return Json(new { result = this.authenticationRepo.isValidUsername(username) }, JsonRequestBehavior.AllowGet);
        }

        /**
         * Gather all information from signup page for new users and insert into DB.
         * */

        [HttpPost]
        public void SignUp(string firstName, string lastName, string username, string password, int isDev)
        {
            authenticationRepo.createUser(firstName, lastName, username, password, isDev);
        }
    }
}