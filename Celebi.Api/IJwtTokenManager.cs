namespace Celebi.Api
{
    public interface IJwtTokenManager
    {
        string Authenticate(string username, string password);
    }
}
