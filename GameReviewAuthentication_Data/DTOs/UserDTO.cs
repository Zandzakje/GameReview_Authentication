using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GameReviewAuthentication_Data.Dtos
{
    public class UserDto
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Token { get; set; }

        public int Administrator { get; set; }
    }
}
