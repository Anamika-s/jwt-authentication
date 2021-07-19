using AuthAPI.Models;
using AuthAPI.Repository;
using AuthAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repo;
        private readonly ITokenGeneratorService service;
        public UserController(IUserRepository _repo, ITokenGeneratorService _service)
        {
            repo = _repo;
            service = _service;
        }

        [HttpPost]
        [Route("register")]
        public void Register(User user)
        {
            repo.Register(user);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(User user)
        {
            var result = repo.Login(user);
            if (result != null)
            {
                return Ok(service.GenerateJWTToken(result.UserId, result.Role));
            }
            return Unauthorized("Invalid UserId or Password");
        }
    }
}
