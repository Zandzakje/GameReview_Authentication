using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameReviewAuthentication.Models;
using GameReviewAuthentication_Data.Repositories;
using GameReviewAuthentication_Data.Dtos;
using GameReviewAuthentication_Data.Interfaces;
using Microsoft.AspNetCore.Cors;
using GameReviewAuthentication_Logic.Logic;

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
        public ActionResult<Login> GetUserById(int id)
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

        //POST api/authentication/login
        [EnableCors]
        [HttpPost("login")]
        public ActionResult<Login> GetUserByInput(Login user)
        {
            LoginDto result = _repository.GetUserByInput(user.Username, user.Password);
            Login matchingUser;
            IActionResult response = Unauthorized();

            if (result != null)
            {
                matchingUser = new Login(result.UserId, result.Username, result.Administrator);
                AuthenticationLogic authenticationLogic = new AuthenticationLogic();
                string tokenStr = authenticationLogic.GenerateJSONWebToken(matchingUser.UserId, matchingUser.Username, matchingUser.Password);
                response = Ok(new { token = tokenStr });
            }

            matchingUser = new Login();
            return matchingUser;
        }

        //POST api/authentication
        [HttpPost]
        public ActionResult<Login> CreateUser(Register potentialUser)
        {
            if (potentialUser.Password != potentialUser.ConfirmPassword)
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
            if (oldUser == null)
            {
                return NotFound();
            }

            if (!TryValidateModel(updatedUser))
            {
                return ValidationProblem(ModelState);
            }

            _repository.UpdateUser(updatedUser);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/authentication/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            LoginDto user = _repository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            _repository.DeleteUser(user);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
