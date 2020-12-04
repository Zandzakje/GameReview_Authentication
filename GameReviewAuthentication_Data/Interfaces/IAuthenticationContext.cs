using System;
using System.Collections.Generic;
using System.Text;
using GameReviewAuthentication_Data.Dtos;

namespace GameReviewAuthentication_Data.Interfaces
{
    public interface IAuthenticationContext
    {
        LoginDto GetUserById(int id);
        LoginDto GetUserByInput(string username, string password);
        void CreateUser(LoginDto user);
        void UpdateUser(LoginDto user);
        void DeleteUser(LoginDto user);
        bool SaveChanges();
    }
}
