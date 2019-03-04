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
    }
}
