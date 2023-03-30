using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Celebi.Api
{
    public interface IJwtTokenManager
    {
        string Authenticate(string username, string password, string role = "User");
    }
}
