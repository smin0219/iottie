using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entity;

namespace iottie.Models
{
    public class DashboardModel
    {
        public string username { get; set; }

        public List<DashboardEntity> dashboardList { get; set; }
    }
}