using GameReviewAuthentication_Data.DTOs;
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

        public LoginDTO GetUserByInput(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            //throw new NotImplementedException();
        }
    }
}
