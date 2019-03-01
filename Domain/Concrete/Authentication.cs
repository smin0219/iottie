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
        public bool isValidUser(string userId, string password)
        {
            bool result = false;

            using (DBContext context = new DBContext())
            {
                result = (from user in context.Users
                          where user.user_id.Equals(userId) &&
                                user.user_password.Equals(password)

                          select user).Any();
            }

            return result;
        }
    }
}
