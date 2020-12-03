using System;
using System.Collections.Generic;
using System.Text;
using GameReviewAuthentication_Data.Dtos;
using GameReviewAuthentication_Data.Interfaces;

namespace GameReviewAuthentication_Data.Repositories
{
    public class AuthenticationMemoryContext : IAuthenticationContext
    {
        public List<LoginDto> mockDb = new List<LoginDto>
        {
            new LoginDto(1, "Padoru", "umu!", 1),
            new LoginDto(2, "test", "test", 0),
            new LoginDto(3, "Saber", "ArtoriaPendragon", 0)
        };

        public LoginDto GetUserById(int id)
        {
            LoginDto result = mockDb.Find(a => a.UserId == id);
            return result;
        }

        public LoginDto GetUserByInput(string username, string password)
        {
            LoginDto result = mockDb.Find(e => e.Username == username && e.Password == password);
            return result;
        }

        public void CreateUser(LoginDto user)
        {
            mockDb.Add(new LoginDto(4, user.Username, user.Password, user.Administrator));
        }

        public void UpdateUser(LoginDto user)
        {
            LoginDto findUser = mockDb.Find(a => a.UserId == user.UserId);
            if(findUser != null)
            {
                findUser.Username = user.Username;
                findUser.Password = user.Password;
            }
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
