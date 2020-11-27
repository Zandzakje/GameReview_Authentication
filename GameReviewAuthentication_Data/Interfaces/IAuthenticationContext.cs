using System;
using System.Collections.Generic;
using System.Text;
using GameReviewAuthentication_Data.Dtos;

namespace GameReviewAuthentication_Data.Interfaces
{
    public interface IAuthenticationContext
    {
        LoginDto GetUserByInput(string username, string password);
    }
}
