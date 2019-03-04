using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Abstract
{
    public interface IDashboard
    {
        List<DashboardEntity> getDashboardList();
        DashboardEntity getDetailInfo(int idnum);
        void updateDetailInfo(int idnum, string title, string assignee, string status, DateTime deadline, string priority);
    }
}
