using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameReviewAuthentication.Models;
using GameReviewAuthentication_Data.Repositories;
using GameReviewAuthentication_Data.DTOs;
using GameReviewAuthentication_Data.Interfaces;
//using AutoMapper;

namespace GameReviewAuthentication.Controllers
{
    [ApiController]
    [Route("api/login")]
    //[Route("api/[controller]")]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        // db gegevens
        // username: dbi406383_gmrvwauth, password: EXtremelyS4f3Passw0rd

        //[HttpPost]
        //public void TestFunction(Login loginViewModel)
        //{
        //    Console.WriteLine(loginViewModel.Username + ", " + loginViewModel.Password + " functie wordt aangeroepen! :D");
        //}

        private readonly IAuthenticationContext _repository;

        public LoginController(IAuthenticationContext repository)
        {
            _repository = repository;
        }

        //private readonly AuthenticationMemoryContext _repository = new AuthenticationMemoryContext();

        //GET api/login/findUser?username=a&password=b
        [HttpGet("findUser")]
        public ActionResult <Login> GetUserByInput(string username, string password)
        {
            LoginDTO result = _repository.GetUserByInput(username, password);
            Login matchingUser = new Login
            {
                Username = result.Username,
                Administrator = result.Administrator
            };
            return matchingUser;
            //return Ok(matchingUser);
        }
    }
}
