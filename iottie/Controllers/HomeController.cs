using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iottie.Models;
using Domain.Entity;
using Domain.Abstract;
using Domain.Concrete;
using iottie.Others;

namespace iottie.Controllers
{
    public class HomeController : Controller
    {
        private IDashboard dashboardRepo = new Dashboard();
        private IDetail chatRepo = new Detail();
        private IAuthentication authenticationRepo = new Authentication();

        public ActionResult Dashboard(string username)
        {
            if (username != null)
            {
                Global.CURRENT_USER = username;
            }
            DashboardModel model = new DashboardModel();
            List<DashboardEntity> list = dashboardRepo.getDashboardList();
            model.username = username;
            model.dashboardList = list;
            return View(model);
        }

        public ActionResult AddNewProject()
        {
            ViewBag.username = Global.CURRENT_USER;
            return View();
        }

        public ActionResult CreateNewProject(string title, string assignee, string createdBy, DateTime deadline, string status, string priority)
        {
            authenticationRepo.createNewProject(title, assignee, createdBy, deadline, status, priority);
            return RedirectToAction("Dashboard", new { username = createdBy });
        }

        public ActionResult Detail(int list_idnum)
        {
            bool isDev = authenticationRepo.isDev(Global.CURRENT_USER);
            DashboardEntity model = new DashboardEntity();
            List<ChatEntity> list = chatRepo.getChatList(list_idnum);
            model = dashboardRepo.getDetailInfo(list_idnum);
            model.chatList = list;
            ViewBag.username = Global.CURRENT_USER;
            ViewBag.isDev = isDev;

            return View(model);
        }

        public ActionResult Edit(int idnum, string title, string assignee, string status, DateTime deadline, string priority)
        {
            DashboardEntity model = new DashboardEntity();
            model.idnum = idnum;
            model.title = title;
            model.status = status;
            model.createdBy = Global.CURRENT_USER;
            model.assignee = assignee;
            model.deadline = deadline;
            model.priority = priority;

            return View(model);
        }

        public ActionResult EditProject(int idnum, string title, string assignee, string status, DateTime deadline, string priority)
        {
            dashboardRepo.updateDetailInfo(idnum, title, assignee, status, deadline, priority);
            return RedirectToAction("Detail", "Home", new { list_idnum = idnum});
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