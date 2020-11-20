using System;
using System.Collections.Generic;
using System.Text;
using GameReviewAuthentication_Data.DTOs;

namespace GameReviewAuthentication_Data.Interfaces
{
    public interface IAuthenticationContext
    {
        LoginDTO GetUserByInput(string username, string password);
    }
}
