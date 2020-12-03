using GameReviewAuthentication_Data.Dtos;
using GameReviewAuthentication_Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameReviewAuthentication_Data.Repositories
{
    public class AuthenticationSqlContext : IAuthenticationContext
    {
        private readonly AuthenticationDbContext _context;

        public AuthenticationSqlContext(AuthenticationDbContext context)
        {
            _context = context;
        }

        public LoginDto GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == userId);
        }

        public LoginDto GetUserByInput(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void CreateUser(LoginDto user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Add(user);
        }

        public void UpdateUser(LoginDto user)
        {
            // Nothing
            //throw new NotImplementedException();
        }
    }
}
