using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameReviewAuthentication.Models;
//using AutoMapper;

namespace GameReviewAuthentication.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public void TestFunction(Login loginViewModel)
        {
            // username: dbi406383_gmrvwauth, password: EXtremelyS4f3Passw0rd
            Console.WriteLine(loginViewModel.Username + ", " + loginViewModel.Password + " functie wordt aangeroepen! :D");
        }
    }
}
