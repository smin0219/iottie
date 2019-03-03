using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IAuthentication
    {
        void createUser(string firstName, string lastName, string username, string password, int isDev);
        bool isValidUser(string username, string password);
        bool isValidUser(string username);
    }
}
