using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ShareMemoriesHub.Helpers.DBContext;
using ShareMemoriesHub.Interfaces;
using ShareMemoriesHub.Models;
using ShareMemoriesHub.Models.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShareMemoriesHub.Factory
{
    public class UserFactory:IUserFactory
    {
        private ILoggerUtil logger;
        private  ApplicationDbContext context;
        private  UserManager<IdentityUser> userManager;
        private  IConfiguration configuration;
        public UserFactory(ILoggerUtil _logger, ApplicationDbContext _context,UserManager<IdentityUser> _userManager,IConfiguration _configuration)
        {
            logger = _logger;
            context = _context;
            userManager = _userManager;
            configuration = _configuration;
        }



        public async Task<RegisterResponse> RegisterAsync(Register registerDto)
        {
            string status=string.Empty;
            bool hasErrors = false;
            string message=string.Empty;    
            var user = await userManager.FindByNameAsync(registerDto.Email);
            if (user != null)
            {
                status = "Duplicate";
                hasErrors = true;
                message = "User already exists";
            }
            else
            {
                var newUser = new IdentityUser
                {
                    Email = registerDto.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = registerDto.Email,
                };
                var result = await userManager.CreateAsync(newUser, registerDto.Password);
                if (!result.Succeeded)
                {
                    status = "Failed";
                    hasErrors = true;
                    message = "An error occurred while registering the user. Try again";
                }
                else
                {
                    status = "Success";
                    message = "User registered successful";
                }
            }
            
            return new RegisterResponse { Status = status,hasErrors=hasErrors, Message = message,User=registerDto };
        }

        public async Task<LoginResponse> LoginAsync(Login loginDto)
        {
            string status=string.Empty;
            string message=string.Empty;
            JwtSecurityToken authtoken = null;
            var user = await userManager.FindByNameAsync(loginDto.UserName);
            if (user != null && await userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                     {
                         new Claim(ClaimTypes.Name, user.UserName),
                         new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                     };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                status = "Success";
                message = "Login successful";
                authtoken = token;
                
            }
            return new LoginResponse {Status=status,Message = message,token=authtoken };

        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}

