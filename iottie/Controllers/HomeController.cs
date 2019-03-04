using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iottie.Models;
using Domain.Entity;
using Domain.Abstract;
using Domain.Concrete;

namespace iottie.Controllers
{
    public class HomeController : Controller
    {
        private IDashboard dashboardRepo = new Dashboard();
        private IDetail chatRepo = new Detail();
        private IAuthentication authenticationRepo = new Authentication();

        public ActionResult Dashboard(string username)
        {
            DashboardModel model = new DashboardModel();
            List<DashboardEntity> list = dashboardRepo.getDashboardList();
            model.username = username;
            model.dashboardList = list;
            return View(model);
        }

        public ActionResult AddNewProject(string username)
        {
            ViewBag.username = username;
            return View();
        }

        public ActionResult CreateNewProject(string title, string assignee, string createdBy, DateTime? deadline, string status, string priority)
        {
            authenticationRepo.createNewProject(title, assignee, createdBy, deadline, status, priority);
            return RedirectToAction("Dashboard", new { username = createdBy });
        }

        public ActionResult Detail(int list_idnum, string username)
        {
            DashboardEntity model = new DashboardEntity();
            List<ChatEntity> list = chatRepo.getChatList(list_idnum);
            model = dashboardRepo.getDetailInfo(list_idnum);
            model.chatList = list;

            return View(model);
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public JsonResult addChatList(int list_idnum, string writtenBy, string body)
        {
            //chatRepo.setChatList(list_idnum, writtenBy, body);
            return Json(new { result = this.chatRepo.setChatList(list_idnum, writtenBy, body) }, JsonRequestBehavior.AllowGet);
        }
    }
}