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
        private IDashboard dashboard = new Dashboard();

        public ActionResult Dashboard(DashboardModel model)
        {
            List<DashboardEntity> list = dashboard.getDashboardList();
            model.dashboardList = list;
            return View(model);
        }

        public ActionResult AddNewProject(int? idnum)
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}