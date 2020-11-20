using System;
using System.Collections.Generic;
using System.Text;
using GameReviewAuthentication_Data.DTOs;
using GameReviewAuthentication_Data.Interfaces;

namespace GameReviewAuthentication_Data.Repositories
{
    public class AuthenticationMemoryContext : IAuthenticationContext
    {
        public LoginDTO GetUserByInput(string username, string password)
        {
            List<LoginDTO> mockDb = new List<LoginDTO>();
            mockDb.Add(new LoginDTO { UserId = 1, Username = "Santa", Password = "christmas" });
            mockDb.Add(new LoginDTO { UserId = 2, Username = "Padoru", Password = "umu!" });
            mockDb.Add(new LoginDTO { UserId = 3, Username = "Cat", Password = "meow" });
            LoginDTO result = mockDb.Find(e => e.Username == username && e.Password == password);
            return result;
            //return new LoginDTO { UserId = 1, Username = "Padoru", Password = "umu!" };
        }
    }
}
