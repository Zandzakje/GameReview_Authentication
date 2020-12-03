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
        public ActionResult <Login> GetUserById(int id)
        {
            LoginDto result = _repository.GetUserById(id);
            Login matchingUser;
            if (result != null)
            {
                matchingUser = new Login(result.UserId, result.Username, result.Password);
            }
            else
            {
                matchingUser = new Login();
            }
            return matchingUser;
        }

        //GET api/authentication/getUserByInput?username=a&password=b
        [HttpGet("getUserByInput")]
        public ActionResult <Login> GetUserByInput(string username, string password)
        {
            LoginDto result = _repository.GetUserByInput(username, password);
            Login matchingUser;
            if(result != null)
            {
                matchingUser = new Login(result.UserId, result.Username, result.Administrator);
            }
            else
            {
                matchingUser = new Login();
            }
            return matchingUser;
        }

        //POST api/authentication
        [HttpPost]
        public ActionResult <Login> CreateUser(Register potentialUser)
        {
            if(potentialUser.Password != potentialUser.ConfirmPassword)
            {
                return NotFound();
            }

            LoginDto user = new LoginDto(potentialUser.Username, potentialUser.Password);
            Login tempUser = new Login(potentialUser.Username, potentialUser.Password);

            _repository.CreateUser(user);
            _repository.SaveChanges();

            //return tempUser;
            return CreatedAtRoute(/*nameof(GetUserById)*/"GetUserById", new { Id = tempUser.UserId }, tempUser);
        }

        //PUT api/authentication/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, Login user)
        {
            LoginDto updatedUser = new LoginDto(id, user.Username, user.Password);
            LoginDto oldUser = _repository.GetUserById(id);
            if(oldUser == null)
            {
                return NotFound();
            }

            _repository.UpdateUser(updatedUser);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
