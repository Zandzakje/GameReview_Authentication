using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewAuthentication.Models
{
    public class Login : User
    {
        public Login(int userId, string username, string password)
        {
            UserId = userId;
            Username = username;
            Password = password;
        }

        public Login(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public Login(int userId, string username, int administrator, string token)
        {
            UserId = userId;
            Username = username;
            Administrator = administrator;
            Token = token;
        }

        public Login()
        {

        }
    }
}
