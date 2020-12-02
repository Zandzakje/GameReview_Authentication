using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameReviewAuthentication.Models;
using GameReviewAuthentication_Data.Repositories;
using GameReviewAuthentication_Data.Dtos;
using GameReviewAuthentication_Data.Interfaces;

namespace GameReviewAuthentication.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    //[Route("api/[controller]")]
    [Produces("application/json")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationContext _repository;

        public AuthenticationController(IAuthenticationContext repository)
        {
            _repository = repository;
        }

        //GET apí/authentication/{id}
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult <Login> GetUserById(int userId)
        {
            LoginDto result = _repository.GetUserById(userId);
            Login matchingUser;
            if (result != null)
            {
                matchingUser = new Login
                {
                    UserId = result.UserId,
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

        //GET api/authentication/getUserByInput?username=a&password=b
        [HttpGet("getUserByInput")]
        public ActionResult <Login> GetUserByInput(string username, string password)
        {
            LoginDto result = _repository.GetUserByInput(username, password);
            Login matchingUser;
            if(result != null)
            {
                matchingUser = new Login
                {
                    UserId = result.UserId,
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

        //POST api/authentication
        [HttpPost]
        public ActionResult <Login> CreateUser(Register potentialUser)
        {
            if(potentialUser.Password != potentialUser.ConfirmPassword)
            {
                return NotFound();
            }

            LoginDto newUser = new LoginDto
            {
                Username = potentialUser.Username,
                Password = potentialUser.Password
            };
            Login tempUser = new Login
            {
                Username = potentialUser.Username,
                Password = potentialUser.Password
            };
            _repository.CreateUser(newUser);
            _repository.SaveChanges();

            //return tempUser;
            return CreatedAtRoute(/*nameof(GetUserById)*/"GetUserById", new { Id = tempUser.UserId }, tempUser);
        }
    }
}
