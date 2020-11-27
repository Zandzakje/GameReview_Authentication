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
            Login matchingUser;
            if(result != null)
            {
                matchingUser = new Login
                {
                    Username = result.Username,
                    Administrator = result.Administrator
                };
            }
            else
            {
                matchingUser = new Login();
            }
            return matchingUser;
            //return Ok(matchingUser);
        }
    }
}
