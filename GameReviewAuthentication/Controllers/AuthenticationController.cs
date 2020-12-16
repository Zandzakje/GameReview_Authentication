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
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace GameReviewAuthentication.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    //[Route("api/[controller]")]
    [Produces("application/json")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationContext _repository;
        public IConfiguration _config;

        public AuthenticationController(IAuthenticationContext repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
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
        public ActionResult/*<Login>*/ GetUserByInput(Login user)
        {
            LoginDto result = _repository.GetUserByInput(user.Username, user.Password);
            ActionResult response = NotFound();

            if (result != null)
            {
                Login matchingUser = new Login(result.UserId, result.Username, result.Administrator, result.Token);
                response = Ok(new { token = matchingUser.Token });
                return response;
            }

            return response;
        }

        // test ivm tutorial, later weghalen
        //POST api/authentication/Post
        [Authorize]
        [HttpPost("Post")]
        public string Post()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            List<Claim> claim = identity.Claims.ToList();
            string username = claim[1].Value;
            return "User currently logged in: " + username;
        }

        // test ivm tutorial, later weghalen
        //GET api/authentication/GetValue
        [Authorize]
        [HttpGet("GetValue")]
        public ActionResult <IEnumerable<string>> Get()
        {
            return new string[] { "Value1", "Value2", "Value3" };
        }

        //POST api/authentication
        [HttpPost]
        public ActionResult<Login> CreateUser(Register newUser)
        {
            if (newUser.Password != newUser.ConfirmPassword || !ModelState.IsValid)
            {
                return NotFound();
            }

            AuthenticationLogic authenticationLogic = new AuthenticationLogic(_config);
            string token = authenticationLogic.GenerateJSONWebToken(newUser.Username);

            LoginDto user = new LoginDto(newUser.Username, newUser.Password, token);
            Login tempUser = new Login(newUser.Username, newUser.Password);

            _repository.CreateUser(user);
            _repository.SaveChanges();

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
