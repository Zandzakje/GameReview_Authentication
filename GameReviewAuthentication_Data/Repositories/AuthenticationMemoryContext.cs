using System;
using System.Collections.Generic;
using System.Text;
using GameReviewAuthentication_Data.Dtos;
using GameReviewAuthentication_Data.Interfaces;

namespace GameReviewAuthentication_Data.Repositories
{
    public class AuthenticationMemoryContext : IAuthenticationContext
    {
        public LoginDto GetUserByInput(string username, string password)
        {
            List<LoginDto> mockDb = new List<LoginDto>();
            mockDb.Add(new LoginDto { UserId = 1, Username = "Santa", Password = "christmas" });
            mockDb.Add(new LoginDto { UserId = 2, Username = "Padoru", Password = "umu!" });
            mockDb.Add(new LoginDto { UserId = 3, Username = "Cat", Password = "meow" });
            LoginDto result = mockDb.Find(e => e.Username == username && e.Password == password);
            return result;
            //return new LoginDTO { UserId = 1, Username = "Padoru", Password = "umu!" };
        }
    }
}
