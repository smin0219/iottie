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
        /**
         *  To get list of projects from DB.
         * */
        List<DashboardEntity> getDashboardList();

        /**
         * To get detail info of a listed project from DB.
         * */
        DashboardEntity getDetailInfo(int idnum);

        /**
         * To update existing data in DB with new value.
         * */
        void updateDetailInfo(int idnum, string title, string assignee, string status, DateTime deadline, string priority);

        /**
         * To remove data from list.
         * */
        void removeList(int idnum);
        
    }
}
