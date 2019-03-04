using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Context;

namespace Domain.Concrete
{
    //Brief explanation for each function exist in the interface.
    public class Authentication : IAuthentication
    {

        public bool isValidUser(string username, string password)
        {
            bool result = false;

            using (DBContext context = new DBContext())
            {
                result = (from user in context.Users
                          where user.username.Equals(username) &&
                                user.password.Equals(password)
                          select user).Any();
            }

            return result;
        }
        public bool isValidUsername(string username)
        {
            bool result = false;

            using (DBContext context = new DBContext())
            {
                result = (from user in context.Users
                          where user.username.Equals(username)
                          select user).Any();

                return result;
            }
        }
        public bool isDev(string username)
        {
            int? isDev = 0;
            bool result = false;

            using (DBContext context = new DBContext())
            {
                isDev = (from user in context.Users
                          where user.username.Equals(username)
                          select user.isDev).Single();
            }

            if(isDev == 1)
            {
                result = true;
            }
            else{
                result = false;
            }
            return result;
        }
        public void createUser(string firstName, string lastName, string username, string password, int isDev)
        {
            Users user = new Users
            {
                username = username,
                password = password,
                first_name = firstName,
                last_name = lastName,
                isDev = isDev
            };

            try
            {
                DBContext context = new DBContext();
                context.Users.Add(user);
                context.SaveChanges();

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void createNewProject(string title, string assignee, string createdBy, DateTime deadline, string status, string priority)
        {
            List list = new List
            {
                title = title,
                status = status,
                assignee = assignee,
                deadline = deadline,
                createdBy = createdBy,
                priority = priority
            };

            try
            {
                DBContext context = new DBContext();
                context.List.Add(list);
                context.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
