using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewAuthentication.Models
{
    public class Register : User
    {
        [Required(ErrorMessage = "Confirm Password is required.")]
        public string ConfirmPassword { get; set; }
    }
}
