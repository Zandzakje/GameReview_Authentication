using System;
using System.Collections.Generic;
using System.Text;

namespace GameReviewAuthentication_Data.Dtos
{
    public class LoginDto : UserDto
    {
        public LoginDto(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public LoginDto(int userId, string username, string password)
        {
            UserId = userId;
            Username = username;
            Password = password;
        }

        public LoginDto(string username, string password, string token)
        {
            Username = username;
            Password = password;
            Token = token;
        }

        public LoginDto(int userId, string username, string password, int administrator)
        {
            UserId = userId;
            Username = username;
            Password = password;
            Administrator = administrator;
        }
    }
}
