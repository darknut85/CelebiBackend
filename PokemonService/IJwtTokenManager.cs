using System.Security.Claims;

namespace Services
{
    public interface IJwtTokenManager
    {
        string Authenticate(string username, string password, string role = "User");
    }
}
