using System.IdentityModel.Tokens.Jwt;

namespace ShareMemoriesHub.Models.Authentication
{
    public class LoginResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public JwtSecurityToken token { get; set; }
    }
}
