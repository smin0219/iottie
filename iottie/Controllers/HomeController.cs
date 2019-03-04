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

        /**
         * Get list of projects and display in table
         * */
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

        /**
         *  Move to creating new project list page
         * */
        public ActionResult AddNewProject()
        {
            ViewBag.username = Global.CURRENT_USER;
            return View();
        }

        /** 
         *  Gather all values from new project list page 
         *  to create a new project list and insert it into DB.
         * */
        public ActionResult CreateNewProject(string title, string assignee, string createdBy, DateTime deadline, string status, string priority)
        {
            authenticationRepo.createNewProject(title, assignee, createdBy, deadline, status, priority);
            return RedirectToAction("Dashboard", new { username = createdBy });
        }

        /**
         *  Show detail page which includes a detail information of a project list.
         *  including chat feature.
         * */
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

        /**
         * In Detail page, only developer and the user who created the post can edit the selected list of project.
         * Other than them, no one can see the edit button in Detail page.
         * */

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

        /**
         * Gather all information to update an existing list of project and update DB.
         * */

        public ActionResult EditProject(int idnum, string title, string assignee, string status, DateTime deadline, string priority)
        {
            dashboardRepo.updateDetailInfo(idnum, title, assignee, status, deadline, priority);
            return RedirectToAction("Detail", "Home", new { list_idnum = idnum});
        }

        public ActionResult Remove(int idnum)
        {
            dashboardRepo.removeList(idnum);
            return RedirectToAction("Dashboard", "Home");
        }

        /**
         * General contact information.
         * */

        public ActionResult Contact()
        {
            return View();
        }

        /**
         * Return history of chatting list to ajax in Detail.cshtml.
         * */

        [HttpGet]
        public JsonResult addChatList(int list_idnum, string writtenBy, string body)
        {
            return Json(new { result = this.chatRepo.setChatList(list_idnum, writtenBy, body) }, JsonRequestBehavior.AllowGet);
        }
    }
}