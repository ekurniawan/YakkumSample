using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DokumenWebApps.Models;
using DokumenWebApps.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DokumenWebApps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);
            if (user == null)
              return BadRequest(new { message = "Username or password is incorrect" });

            //var user = new User { Username = userParam.Username, Password = userParam.Password };
            return Ok(user);
        }

        [HttpGet("Hello")]
        public IActionResult Hello(string id)
        {
            return Ok($"Hello {id}");
        }
    }
}