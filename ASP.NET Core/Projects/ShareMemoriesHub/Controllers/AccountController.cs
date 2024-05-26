using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ShareMemoriesHub.Factory;
using ShareMemoriesHub.Helpers.DBContext;
using ShareMemoriesHub.Interfaces;
using ShareMemoriesHub.Models;
using ShareMemoriesHub.Models.Authentication;
using System.IdentityModel.Tokens.Jwt;

namespace ShareMemoriesHub.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUserFactory userFactory;
        public AccountController(ApplicationDbContext _context, UserManager<IdentityUser> _userManager, IUserFactory _userFactory)
        {
            userFactory = _userFactory;
        }

        [HttpPost("register", Name = "register")]
        public async Task<IActionResult> Register(Register registerDto)
        {
            var response =  await userFactory.RegisterAsync(registerDto);
            if(response.Status.Equals("Failed"))
            {
                return Ok(response);
            }
            else if (response.Equals("Duplicate"))
            {
                return Ok(response);
            }

            return Ok(response);
        }

        [HttpPost("login", Name = "login")]
        public async Task<IActionResult> Login(Login loginDto)
        {
            var response = await userFactory.LoginAsync(loginDto);
            if (response.Status.Equals("Success"))
            {
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(response.token),
                    expiration = response.token.ValidTo
                });
            }
            return Unauthorized();
        }

    }
}

