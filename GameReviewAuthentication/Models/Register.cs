using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewAuthentication.Models
{
    public class Register : User
    {
        public string ConfirmPassword { get; set; }
    }
}
