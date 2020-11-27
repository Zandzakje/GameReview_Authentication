using System;
using System.Collections.Generic;
using System.Text;

namespace GameReviewAuthentication_Data.Dtos
{
    public class RegisterDto : UserDto
    {
        public string ConfirmPassword { get; set; }
    }
}
