using System;
using System.Collections.Generic;
using System.Text;

namespace GameReviewAuthentication_Data.DTOs
{
    public class RegisterDTO : UserDTO
    {
        public string ConfirmPassword { get; set; }
    }
}
