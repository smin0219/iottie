using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IAuthentication
    {
        // To create and insert user into DB
        void createUser(string firstName, string lastName, string username, string password, int isDev);
        // To create and insert new project into DB
        void createNewProject(string title, string assignee, string createdBy, DateTime? deadline, string status, string priority);
        // To check whether the user's username and password is correct or not.
        bool isValidUser(string username, string password);
        // To check if the username is already exist in DB.
        bool isValidUsername(string username);

    }
}
