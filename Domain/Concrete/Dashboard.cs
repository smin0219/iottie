using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entity;
using Domain.Context;

namespace Domain.Concrete
{

    /**
     * Brief explanation for each function in the IDashboard.cs
     * */

    public class Dashboard : IDashboard
    {
        public List<DashboardEntity> getDashboardList()
        {
            List<DashboardEntity> list = new List<DashboardEntity>();

            using (DBContext context = new DBContext())
            {
                try
                {
                    list = (from a in context.List
                            select new DashboardEntity
                            {
                                idnum = a.idnum,
                                title = a.title,
                                status = a.status,
                                createdBy = a.createdBy,
                                assignee = a.assignee,
                                deadline = a.deadline,
                                priority = a.priority

                            }).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return list;
            }
        }

        public DashboardEntity getDetailInfo(int idnum)
        {
            DashboardEntity info = new DashboardEntity();

            using (DBContext context = new DBContext())
            {
                try
                {
                    info = (from a in context.List
                            where a.idnum == idnum
                            select new DashboardEntity
                            {
                                idnum = a.idnum,
                                title = a.title,
                                createdBy = a.createdBy,
                                assignee = a.assignee,
                                deadline = a.deadline,
                                status = a.status,
                                priority = a.priority
                            }).SingleOrDefault();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return info;
        }

        public void updateDetailInfo(int idnum, string title, string assignee, string status, DateTime deadline, string priority)
        {
            using (DBContext context = new DBContext())
            {
                try
                {
                    var result = context.List.SingleOrDefault(a => a.idnum == idnum);

                    if (result != null)
                    {
                        result.title = title;
                        result.assignee = assignee;
                        result.deadline = deadline;
                        result.status = status;
                        result.priority = priority;
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public void removeList(int idnum)
        {
            using (DBContext context = new DBContext())
            {
                try
                {
                    var result = context.List.SingleOrDefault(a => a.idnum == idnum);
                    context.List.Remove(result);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

    }
}
