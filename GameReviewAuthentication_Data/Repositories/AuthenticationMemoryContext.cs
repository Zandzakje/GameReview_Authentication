using System;
using System.Collections.Generic;
using System.Text;
using GameReviewAuthentication_Data.Dtos;
using GameReviewAuthentication_Data.Interfaces;

namespace GameReviewAuthentication_Data.Repositories
{
    public class AuthenticationMemoryContext : IAuthenticationContext
    {
        public void CreateUser(LoginDto newUser)
        {
            List<LoginDto> mockDb = new List<LoginDto>();
            mockDb.Add(new LoginDto { UserId = 1, Username = "Padoru", Password = "umu!", Administrator = 1 });
            mockDb.Add(new LoginDto { UserId = 2, Username = "Test", Password = "test123", Administrator = 0 });
            mockDb.Add(new LoginDto { UserId = 3, Username = "Saber", Password = "ArtoriaPendragon", Administrator = 0 });
            mockDb.Add(new LoginDto { UserId = 4, Username = newUser.Username, Password = newUser.Password, Administrator = 0 });
        }

        public LoginDto GetUserById(int userId)
        {
            List<LoginDto> mockDb = new List<LoginDto>();
            mockDb.Add(new LoginDto { UserId = 1, Username = "Padoru", Password = "umu!", Administrator = 1 });
            mockDb.Add(new LoginDto { UserId = 2, Username = "Test", Password = "test123", Administrator = 0 });
            mockDb.Add(new LoginDto { UserId = 3, Username = "Saber", Password = "ArtoriaPendragon", Administrator = 0 });
            LoginDto result = mockDb.Find(a => a.UserId == userId);
            return result;
        }

        public LoginDto GetUserByInput(string username, string password)
        {
            List<LoginDto> mockDb = new List<LoginDto>();
            mockDb.Add(new LoginDto { UserId = 1, Username = "Padoru", Password = "umu!", Administrator = 1 });
            mockDb.Add(new LoginDto { UserId = 2, Username = "Test", Password = "test123", Administrator = 0 });
            mockDb.Add(new LoginDto { UserId = 3, Username = "Saber", Password = "ArtoriaPendragon", Administrator = 0 });
            LoginDto result = mockDb.Find(e => e.Username == username && e.Password == password);
            return result;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
